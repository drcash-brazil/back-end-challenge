using BookStore.Domain.Commands;
using BookStore.Domain.Commands.AuthorCommand;
using BookStore.Domain.Entities;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Domain.Api.Controllers;

[ApiController]
[Route("v1/authors")]
public class AuthorController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IEnumerable<Author> GetAll(
        [FromServices] IAuthorRepository repository
    )
    {
        return repository.GetAll();
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public Author GetById(
        Guid id,
        [FromServices] IAuthorRepository repository
    )
    {
        return repository.GetById(id);
    }

    [HttpPost]
    [Route("add")]
    public GenericCommandResult Create(
        [FromBody] CreateAuthorCommand command,
        [FromServices] AuthorHandler handler
    )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpPut]
    [Route("update")]
    public GenericCommandResult Update(
        [FromBody] UpdateAuthorCommand command,
        [FromServices] AuthorHandler handler
    )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpDelete]
    [Route("delete/{id:Guid}")]
    public GenericCommandResult Delete(
        Guid id,
        [FromServices] IAuthorRepository repository
    )
    {
        bool status = repository.Delete(id);

        if (!status)
            return new GenericCommandResult(true, "Author is not exists!", null);

        return new GenericCommandResult(true, "Author successfully deleted!", null);
    }
}