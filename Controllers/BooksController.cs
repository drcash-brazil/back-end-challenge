using System.Collections.Generic;
using back_end_challenge.Repositories;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using back_end_challenge.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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
    [HttpGet("{id}", Name = "GetBookById")]
    public ActionResult<IEnumerable<BooksReadDto>> GetBookById(int id)
    {
      var bookItem = _repository.GetBookById(id);
      if (bookItem is null) return NotFound();
      return Ok(_mapper.Map<BooksReadDto>(bookItem));
    }

    //POST api/books/
    [HttpPost]
    public ActionResult<BooksReadDto> CreateBook(BooksCreateDto book)
    {
      var bookItem = _mapper.Map<Books>(book);
      _repository.CreateBook(bookItem);
      _repository.SavaChanges();

      var bookReadDto = _mapper.Map<BooksReadDto>(bookItem);

      return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);
    }

    //PUT api/books/{id}
    [HttpPut("{id}")]
    public ActionResult<BooksReadDto> UpdateBook(int id, BooksUpdateDto booksUpdateDto)
    {

      var bookItem = _repository.GetBookById(id);
      if (bookItem is null) return NotFound();

      _mapper.Map(booksUpdateDto, bookItem);
      _repository.UpdateBook(bookItem);
      _repository.SavaChanges();

      var bookReadDto = _mapper.Map<BooksReadDto>(bookItem);
      return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);
    }

    //PATCH api/books/{id}
    [HttpPatch("{id}")]
    public ActionResult<BooksReadDto> PartialBookUpdate(int id, JsonPatchDocument<BooksUpdateDto> patchDoc)
    {
      var bookItem = _repository.GetBookById(id);
      if (bookItem is null) return NotFound();

      var bookToPatch = _mapper.Map<BooksUpdateDto>(bookItem);
      patchDoc.ApplyTo(bookToPatch, ModelState);

      if (!TryValidateModel(bookToPatch))
        return ValidationProblem(ModelState);

      _mapper.Map(bookToPatch, bookItem);
      _repository.UpdateBook(bookItem);
      _repository.SavaChanges();

      var bookReadDto = _mapper.Map<BooksReadDto>(bookItem);
      return CreatedAtRoute(nameof(GetBookById), new { Id = bookReadDto.Id }, bookReadDto);
    }

  }
}