using BookStore.Domain.Commands;
using BookStore.Domain.Commands.BooksCommand;
using BookStore.Domain.Entities;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Domain.Api.Controllers;

[ApiController]
[Route("v1/books")]
public class BookController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IEnumerable<Book> GetAll(
        [FromServices] IBookRepository repository
    )
    {
        return repository.GetAll();
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public Book GetById(
        Guid id,
        [FromServices] IBookRepository repository
    )
    {
        return repository.GetById(id);
    }

    [HttpPost]
    [Route("add")]
    public GenericCommandResult Create(
        [FromBody] CreateBookCommand command,
        [FromServices] BookHandler handler
    )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpPut]
    [Route("update")]
    public GenericCommandResult Update(
       [FromBody] UpdateBookCommand command,
       [FromServices] BookHandler handler
   )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpDelete]
    [Route("delete/{id:Guid}")]
    public GenericCommandResult Delete(
        Guid id,
        [FromServices] IBookRepository repository
    )
    {
        bool status = repository.Delete(id);

        if (!status)
            return new GenericCommandResult(true, "Book is not exists!", null);

        return new GenericCommandResult(true, "Book successfully deleted!", null);
    }
}