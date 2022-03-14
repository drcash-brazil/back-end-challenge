using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
using back_end_challenge.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrcashTest.Controllers
{
  [Route("api/authors")]
  [ApiController]
  public class AuthorsController : ControllerBase
  {
    private readonly ILogger<AuthorsController> _logger;
    private readonly IMapper _mapper;
    private readonly IAuthorsRepository _repository;


    public AuthorsController(IAuthorsRepository repository, ILogger<AuthorsController> logger, IMapper mapper)
    {
      _repository = repository;
      _logger = logger;
      _mapper = mapper;
    }


    //GET api/authors/
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    { 
      var result = await _repository.GetAll();
      return Ok(_mapper.Map<IList<AuthorReadDto>>(result));
    }


    //GET api/authors/{id}
    [HttpGet("{id:int}", Name = "GetAuthorById")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
      var result = await  _repository.GetById(id);
      return Ok(_mapper.Map<AuthorReadDto>(result));
    }


    //GET api/authors/{search}
    [HttpGet("{name}")]
    public async Task<IActionResult> GetAuthorByName(string name)
    {
      var result = await _repository.GetByName(name);
      return Ok(_mapper.Map<IList<AuthorReadDto>>(result));
    }


    //GET api/authors/{id}/books
    [HttpGet("{id:int}/books")]
    public async Task<IActionResult> GetAuthorWithBooks(int id)
    {
      var result = await _repository.GetByAuthorWithBooks(id);
      return Ok(_mapper.Map<AuthorReadDto>(result));
    }


    //POST api/authors/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateDto entityDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(GetAuthorById)}");
        return BadRequest(ModelState);
      }

      var entity = _mapper.Map<Authors>(entityDto);
      var result = await _repository.Insert(entity);
      
      return CreatedAtRoute(nameof(GetAuthorById), new { Id = result.Id }, result);
    }



    //POST api/authors/
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto authorDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var author = await _repository.GetById(id);

      if (author is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(authorDto, author);

      var success = await _repository.Update(author);

      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar atualizar os dados do autor");
    }


    //DELETE api/authors/
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
      if (id < 1) return BadRequest();

      var author = await _repository.GetById(id);

      if (author is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      var success = await _repository.Delete(id, author);
      
      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar eliminar autor selecionado");

    }

  }
}