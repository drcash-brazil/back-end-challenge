using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back_end_challenge.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BooksController> _logger;
    private readonly IMapper _mapper;

    public BooksController(IUnitOfWork unitOfWork, ILogger<BooksController> logger, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _mapper = mapper;
    }

    //GET api/books/
    [HttpGet]
    public async Task<IActionResult> GetAllBooks([FromQuery] RequestParams requestParams)
    {
      var entities = await _unitOfWork.Books.GetAll(
          requestParams: requestParams,
          includes: new List<string> { "Authors", "Categories" },
          orderBy: q => q.OrderByDescending(x => x.Id)
        );

      var result = _mapper.Map<IList<BooksReadDto>>(entities);
      return Ok(result);
    }

    //GET api/books/{id}
    [HttpGet("{id:int}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
      var entity = await _unitOfWork.Books.Get(x => x.Id == id, new List<string> { "Authors", "Categories" });
      var result = _mapper.Map<BooksReadDto>(entity);
      return Ok(result);
    }


    //POST api/books/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var entity = _mapper.Map<Books>(bookDto);
      await _unitOfWork.Books.Insert(entity);
      await _unitOfWork.ToSave();

      return CreatedAtRoute(nameof(GetBookById), new { Id = entity.Id }, entity);
    }

    //PUT api/books/
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto bookDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var book = await _unitOfWork.Books.Get(q => q.Id == id);
      if (book is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(bookDto, book);
      _unitOfWork.Books.Update(book);
      await _unitOfWork.ToSave();

      return NoContent();
    }


    //DELETE api/books/
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBook(int id)
    {
      if (id < 1) return BadRequest();

      var book = await _unitOfWork.Books.Get(q => q.Id == id);

      if (book is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      await _unitOfWork.Books.Delete(id);
      await _unitOfWork.ToSave();

      return NoContent();
    }

  }
}