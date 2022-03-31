using BookStore.Domain.Commands;
using BookStore.Domain.Commands.GenreCommand;
using BookStore.Domain.Entities;
using BookStore.Domain.Handlers;
using BookStore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Domain.Api.Controllers;

[ApiController]
[Route("v1/genres")]
public class GenreController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public IEnumerable<Genre> GetAll(
            [FromServices] IGenreRepository repository
        )
    {
        return repository.GetAll();
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public Genre GetById(
        Guid id,
        [FromServices] IGenreRepository repository
    )
    {
        return repository.GetById(id);
    }

    [HttpPost]
    [Route("add")]
    public GenericCommandResult Create(
        [FromBody] CreateGenreCommand command,
        [FromServices] GenreHandler handler
    )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpPut]
    [Route("update")]
    public GenericCommandResult Update(
        [FromBody] UpdateGenreCommand command,
        [FromServices] GenreHandler handler
    )
    {
        var result = handler.Handle(command);
        return (GenericCommandResult)result;
    }

    [HttpDelete]
    [Route("delete/{id:Guid}")]
    public GenericCommandResult Delete(
        Guid id,
        [FromServices] IGenreRepository repository
    )
    {
        bool status = repository.Delete(id);

        if (!status)
            return new GenericCommandResult(true, "Genre is not exists!", null);

        return new GenericCommandResult(true, "Genre successfully deleted!", null);
    }
}