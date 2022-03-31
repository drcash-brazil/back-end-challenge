using BookStore.Domain.Commands;
using BookStore.Domain.Commands.AuthorCommand;
using BookStore.Domain.Commands.Contracts;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;

namespace BookStore.Domain.Handlers;

public class AuthorHandler :
    IHandler<CreateAuthorCommand>,
    IHandler<UpdateAuthorCommand>
{

    private readonly IAuthorRepository _authorRepository;

    public AuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public ICommandResult Handle(CreateAuthorCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var authorRequestDTO = new Author(
            name: command.Name
        );

        _authorRepository.Create(authorRequestDTO);

        return new GenericCommandResult(true, "Author successfully created", authorRequestDTO);
    }

    public ICommandResult Handle(UpdateAuthorCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var filteredAuthorRequestDTO = _authorRepository.GetById(command.Id);

        filteredAuthorRequestDTO.UpdateAuthor(command.Name);

        _authorRepository.Update(filteredAuthorRequestDTO);

        return new GenericCommandResult(true, "Author successfully updated", filteredAuthorRequestDTO);
    }

}