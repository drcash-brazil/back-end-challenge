using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
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
    public async Task<IActionResult> GetBooks()
    {
      try
      {
        var entities = await _unitOfWork.Books.GetAll(includes: new List<string> { "Authors", "Categories" });
        var result = _mapper.Map<IList<BooksReadDto>>(entities);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetBooks)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //GET api/books/{id}
    [HttpGet("{id:int}", Name = "GetBookById")]
    public async Task<IActionResult> GetBookById(int id)
    {
      try
      {
        var entity = await _unitOfWork.Books.Get(x => x.Id == id, new List<string> { "Authors", "Categories" });
        var result = _mapper.Map<BooksReadDto>(entity);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetBookById)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }


    //POST api/books/
    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] BooksDto bookDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(CreateBook)}");
        return BadRequest(ModelState);
      }
      try
      {
        var entity = _mapper.Map<Books>(bookDto);
        await _unitOfWork.Books.Insert(entity);
        await _unitOfWork.ToSave();

        // var result = _mapper.Map<BooksReadDto>(entity);
        return CreatedAtRoute(nameof(GetBookById), new { Id = entity.Id }, entity);
        // var result = _mapper.Map<BooksReadDto>(entity);
        // return CreatedAtRoute(nameof(GetBookById), new { Id = entity.Id }, entity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(CreateBook)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

  }
}