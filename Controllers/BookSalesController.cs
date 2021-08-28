using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back_end_challenge.Controllers
{
  [Route("api/sales")]
  [ApiController]
  public class BookSalesController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BookSalesController> _logger;
    private readonly IMapper _mapper;

    public BookSalesController(IUnitOfWork unitOfWork, ILogger<BookSalesController> logger, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _logger = logger;
      _mapper = mapper;
    }


    //GET api/sales/
    [HttpGet]
    public async Task<IActionResult> GetAllBookSales([FromQuery] RequestParams requestParams)
    {
      var entities = await _unitOfWork.BookSales.GetAll(
          requestParams: requestParams,
          includes: (new List<string> { "Book", "Book.Authors", "Book.Categories" }),
          orderBy: q => q.OrderByDescending(x => x.Id)
      );

      var result = _mapper.Map<IList<BookSalesReadDto>>(entities);
      return Ok(result);
    }


    //GET api/sales/{id}
    [HttpGet("{id:int}", Name = "GetSaleById")]
    public async Task<IActionResult> GetSaleById(int id)
    {
      var entity = await _unitOfWork.BookSales.Get(x => x.Id == id, (new List<string> { "Book", "Book.Authors", "Book.Categories" }));

      var result = _mapper.Map<BookSalesReadDto>(entity);
      return Ok(result);
    }



    //POST api/sales/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateBookSales([FromBody] BookSalesCreateDto bookSaleDto)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      if (bookSaleDto.QuantityToReduce <= 0)
      {
        return BadRequest("Informe uma quantidade de livro a comprar maior que 0 para concluir a operação");
      }

      var book = await _unitOfWork.Books.Get(x => x.Id == bookSaleDto.BookId);

      if (book is null) return NotFound($"Não foi encontrado nenhum livro com ID {bookSaleDto.BookId}");

      book.NumCopias -= bookSaleDto.QuantityToReduce;
      _unitOfWork.Books.Update(book);

      var entity = _mapper.Map<BookSales>(bookSaleDto);
      await _unitOfWork.BookSales.Insert(entity);
      await _unitOfWork.ToSave();

      return CreatedAtRoute(nameof(GetSaleById), new { Id = entity.Id }, entity);
    }


    //DELETE api/sales/
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteBookSale(int id)
    {
      if (id < 1) return BadRequest();

      var bookSales = await _unitOfWork.BookSales.Get(q => q.Id == id);
      if (bookSales is null) return NotFound($"Não foi encontrado um registo com ID {id}");

      await _unitOfWork.BookSales.Delete(id);
      await _unitOfWork.ToSave();

      return NoContent();
    }

  }
}