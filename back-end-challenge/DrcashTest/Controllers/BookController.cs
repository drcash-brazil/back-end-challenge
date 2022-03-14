using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrcashTest.IRepository;
using DrcashTest.Models;
using DrcashTest.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrcashTest.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly ILogger<BookController> _logger;
    private readonly IMapper _mapper;
    private readonly IBookRepository _repository;


    public BookController(IBookRepository repository, ILogger<BookController> logger, IMapper mapper)
    {
      _repository = repository;
      _logger = logger;
      _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    { 
      var result = await _repository.GetAll();
      return Ok(_mapper.Map<IList<BooksReadDto>>(result));
    }


    [HttpGet("{id:int}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
      var result = await  _repository.GetById(id);
      return Ok(_mapper.Map<BooksReadDto>(result));
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetBookByName(string name)
    {
      var result = await _repository.GetBookByName(name);
      return Ok(_mapper.Map<IList<BooksReadDto>>(result));
    }

    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBook([FromBody] BookCreateDto entityDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(GetBookById)}");
        return BadRequest(ModelState);
      }

      var entity = _mapper.Map<Books>(entityDto);
      var result = await _repository.Insert(entity);
      
      return CreatedAtRoute(nameof(GetBookById), new { Id = result.Id }, result);
    }


    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookUpdateDto bookDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var book = await _repository.GetById(id);

      if (book is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(bookDto, book);

      var success = await _repository.Update(book);

      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar atualizar livro");
    }


    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBook(int id)
    {
      if (id < 1) return BadRequest();

      var book = await _repository.GetById(id);

      if (book is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      var success = await _repository.Delete(id, book);
      
      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar eliminar livro selecionada");

    }

  }
}