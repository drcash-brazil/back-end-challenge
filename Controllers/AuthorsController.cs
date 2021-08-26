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
  [Route("api/authors")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BooksController> _logger;
    private readonly IMapper _mapper;

    public AuthorsController(IUnitOfWork unitOfWork, ILogger<BooksController> logger, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _mapper = mapper;
    }

    //GET api/authors/
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
      try
      {
        var entities = await _unitOfWork.Authors.GetAll(includes: new List<string> { "Books" });
        var result = _mapper.Map<IList<AuthorReadDto>>(entities);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetAllAuthors)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //GET api/authors/{id}
    [HttpGet("{id:int}", Name = "GetAuthorById")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
      try
      {
        var entity = await _unitOfWork.Authors.Get(x => x.Id == id, new List<string> { "Books" });
        var result = _mapper.Map<AuthorReadDto>(entity);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetAuthorById)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }


    //POST api/authors/
    [HttpPost]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto entityDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(GetAuthorById)}");
        return BadRequest(ModelState);
      }
      try
      {
        var entity = _mapper.Map<Authors>(entityDto);
        await _unitOfWork.Authors.Insert(entity);
        await _unitOfWork.ToSave();

        return CreatedAtRoute(nameof(GetAuthorById), new { Id = entity.Id }, entity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(CreateAuthor)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

  }
}