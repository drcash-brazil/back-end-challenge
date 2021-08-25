using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back_end_challenge.Controllers
{
  [Route("api/categories")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BooksController> _logger;
    private readonly IMapper _mapper;

    public CategoriesController(IUnitOfWork unitOfWork, ILogger<BooksController> logger, IMapper mapper)
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
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory(int id)
    {
      try
      {
        var entity = await _unitOfWork.Categories.Get(x => x.Id == id, new List<string> { "Books" });
        var result = _mapper.Map<BooksReadDto>(entity);
        return Ok(result);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(GetCategory)}");
        return StatusCode(500, "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.");
      }
    }
  }
}