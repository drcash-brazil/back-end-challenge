using System.Collections.Generic;
using back_end_challenge.Repositories;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end_challenge.Controllers
{
  [Route("api/books")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    private readonly IBookRepo _repository;
    public BooksController(IBookRepo repository)
    {
      _repository = repository;
    }

    // GET api/books/
    [HttpGet]
    public ActionResult<IEnumerable<Books>> GetAllBooks()
    {
      var bookItems = _repository.GetBooks();
      return Ok(bookItems);
    }

    // GET api/books/1
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Books>> GetABookById(int id)
    {
      var bookItem = _repository.GetBookById(id);
      return Ok(bookItem);
    }
  }
}