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
  [Route("api/categories")]
  [ApiController]
  public class CategoryController : ControllerBase
  {
    private readonly ILogger<CategoryController> _logger;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _repository;


    public CategoryController(ICategoryRepository repository, ILogger<CategoryController> logger, IMapper mapper)
    {
      _repository = repository;
      _logger = logger;
      _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    { 
      var result = await _repository.GetAll();
      return Ok(_mapper.Map<IList<CategoryReadDto>>(result));
    }


    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
      var result = await  _repository.GetById(id);
      return Ok(_mapper.Map<CategoryReadDto>(result));
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto entityDto)
    {
      if (!ModelState.IsValid)
      {
        _logger.LogError($"Ocorreu um erro em {nameof(GetCategoryById)}");
        return BadRequest(ModelState);
      }

      var entity = _mapper.Map<Category>(entityDto);
      var result = await _repository.Insert(entity);
      
      return CreatedAtRoute(nameof(GetCategoryById), new { Id = result.Id }, result);
    }


    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var category = await _repository.GetById(id);

      if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(categoryDto, category);

      var success = await _repository.Update(category);

      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar atualizar categoria");
    }


    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      if (id < 1) return BadRequest();

      var category = await _repository.GetById(id);

      if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      var success = await _repository.Delete(id, category);
      
      return success ? NoContent() : StatusCode(500, "Ocorreu um erro interno ao tentar eliminar categoria selecionada");

    }

  }
}