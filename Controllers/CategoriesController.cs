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
    public async Task<IActionResult> GetAllCategories([FromQuery] RequestParams requestParams)
    {
      var entities = await _unitOfWork.Categories.GetAll(
          requestParams: requestParams,
          orderBy: q => q.OrderByDescending(x => x.Id)
      );

      var result = _mapper.Map<IList<CategoryReadDto>>(entities);
      return Ok(result);
    }


    //GET api/categories/{id}
    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
      var entity = await _unitOfWork.Categories.Get(x => x.Id == id, new List<string> { "Books" });
      var result = _mapper.Map<CategoryReadDto>(entity);
      return Ok(result);
    }


    //GET api/categories/{name}
    [HttpGet("{name}")]
    public async Task<IActionResult> GetCategoryByName(string name, [FromQuery] RequestParams requestParams)
    {
      var entities = await _unitOfWork.Categories.GetAll(
        requestParams: requestParams,
        expression: (x => x.nome.Contains(name)),
        orderBy: q => q.OrderByDescending(x => x.Id)
      );

      var result = _mapper.Map<IList<CategoryReadDto>>(entities);
      return Ok(result);
    }


    //GET api/categories/{id}/books
    [HttpGet("{id:int}/books")]
    public async Task<IActionResult> GetCategoryWithBooks(int id)
    {
      var entity = await _unitOfWork.Categories.Get(x => x.Id == id, new List<string> { "Books", "Books.Authors" });
      var result = _mapper.Map<CategoryReadDto>(entity);
      return Ok(result);
    }


    //POST api/categories/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto entityDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var entity = _mapper.Map<Category>(entityDto);
      await _unitOfWork.Categories.Insert(entity);
      await _unitOfWork.ToSave();

      return CreatedAtRoute(nameof(GetCategoryById), new { Id = entity.Id }, entity);
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

      var category = await _unitOfWork.Categories.Get(q => q.Id == id);
      if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      _mapper.Map(categoryDto, category);
      _unitOfWork.Categories.Update(category);
      await _unitOfWork.ToSave();

      return NoContent();
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

      var category = await _unitOfWork.Categories.Get(q => q.Id == id);
      if (category is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      await _unitOfWork.Categories.Delete(id);
      await _unitOfWork.ToSave();

      return NoContent();
    }

  }
}