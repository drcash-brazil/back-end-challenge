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
  [Route("api/generos")]
  [ApiController]
  public class GeneroController : ControllerBase
  {
    private readonly ILogger<GeneroController> _logger;
    private readonly IMapper _mapper;
    private readonly IGeneroRepository _repository;


    public GeneroController(IGeneroRepository repository, ILogger<GeneroController> logger, IMapper mapper)
    {
      _repository = repository;
      _logger = logger;
      _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllGeneros()
    { 
      var result = await _repository.GetAll();
      return Ok(_mapper.Map<IList<GeneroReadDto>>(result));
    }


    [HttpGet("{id:int}", Name = "GetGeneroById")]
    public async Task<IActionResult> GetGeneroById(int id)
    {
      var result = await  _repository.GetById(id);
      return Ok(_mapper.Map<GeneroReadDto>(result));
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateGenero([FromBody] GeneroCreateDto entityDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(GetGeneroById)}");
        return BadRequest(ModelState);
      }

      var entity = _mapper.Map<Genero>(entityDto);
      var result = await _repository.Insert(entity);
      
      return CreatedAtRoute(nameof(GetGeneroById), new { Id = result.Id }, result);
    }


    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateGenero(int id, [FromBody] GeneroUpdateDto GeneroDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var genero = await _repository.GetById(id);

      if (genero is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(GeneroDto, genero);

      var success = await _repository.Update(genero);

      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar atualizar categoria");
    }


    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteGenero(int id)
    {
      if (id < 1) return BadRequest();

      var genero = await _repository.GetById(id);

      if (genero is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      var success = await _repository.Delete(id, genero);
      
      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar eliminar categoria selecionada");

    }

  }
}