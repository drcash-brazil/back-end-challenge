using System.Collections.Generic;
using back_end_challenge.Repositories;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using back_end_challenge.Dtos;

namespace back_end_challenge.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IBookRepo _repository;
    private readonly IMapper _mapper;

    public BooksController(IBookRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //GET api/books/
    [HttpGet]
    public ActionResult<IEnumerable<BooksReadDto>> GetAllBooks()
    {
      var bookItems = _repository.GetBooks();
      return Ok(_mapper.Map<IEnumerable<BooksReadDto>>(bookItems));
    }

    //GET api/books/{id}
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<BooksReadDto>> GetABookById(int id)
    {
      var bookItem = _repository.GetBookById(id);
      if (bookItem is null) return NotFound();
      return Ok(_mapper.Map<BooksReadDto>(bookItem));
    }

    //POST api/books/
    [HttpPost]
    public ActionResult<BooksReadDto> CreateBooks(BooksCreateDto book)
    {
      var bookItem = _mapper.Map<Books>(book);
      _repository.CreateBook(bookItem);
      _repository.SavaChanges();
      return Ok(bookItem);
    }

  }
}