using System;
using System.Collections.Generic;
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
  [Route("api/categories")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMapper _mapper;

    public CategoriesController(IUnitOfWork unitOfWork, ILogger<CategoriesController> logger, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _mapper = mapper;
    }

    //GET api/categories/
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
      try
      {
        var entities = await _unitOfWork.Categories.GetAll(includes: new List<string> { "Books" });
        var result = _mapper.Map<IList<CategoryReadDto>>(entities);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetAllCategories)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //GET api/categories/{id}
    [HttpGet("{id:int}", Name = "GetCategoryById")]

    public async Task<IActionResult> GetCategoryById(int id)
    {
      try
      {
        var entity = await _unitOfWork.Categories.Get(x => x.Id == id, new List<string> { "Books" });
        var result = _mapper.Map<CategoryReadDto>(entity);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetCategoryById)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //POST api/categories/
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
      try
      {
        var entity = _mapper.Map<Category>(entityDto);
        await _unitOfWork.Categories.Insert(entity);
        await _unitOfWork.ToSave();

        return CreatedAtRoute(nameof(GetCategoryById), new { Id = entity.Id }, entity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(CreateCategory)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //PUT api/categories/
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      try
      {
        var category = await _unitOfWork.Categories.Get(q => q.Id == id);
        if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

        _mapper.Map(categoryDto, category);
        _unitOfWork.Categories.Update(category);
        await _unitOfWork.ToSave();

        return NoContent();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(UpdateCategory)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

    //DELETE api/categories/
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
      if (id < 1) return BadRequest();
      try
      {
        var category = await _unitOfWork.Categories.Get(q => q.Id == id);
        if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

        await _unitOfWork.Categories.Delete(id);
        await _unitOfWork.ToSave();

        return NoContent();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(DeleteCategory)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }

  }
}