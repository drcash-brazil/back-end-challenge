using BookStore.Domain.Commands;
using BookStore.Domain.Commands.Contracts;
using BookStore.Domain.Commands.GenreCommand;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;

namespace BookStore.Domain.Handlers;

public class GenreHandler :
    IHandler<CreateGenreCommand>,
    IHandler<UpdateGenreCommand>
{

    private readonly IGenreRepository _genreRepository;

    public GenreHandler(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public ICommandResult Handle(CreateGenreCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var ganreRequestDTO = new Genre(
            name: command.Name
        );

        _genreRepository.Create(ganreRequestDTO);

        return new GenericCommandResult(true, "Ganre successfully created", ganreRequestDTO);
    }

    public ICommandResult Handle(UpdateGenreCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var filteredGenreRequestDTO = _genreRepository.GetById(command.Id);

        filteredGenreRequestDTO.UpdateGenre(command.Name);

        _genreRepository.Update(filteredGenreRequestDTO);

        return new GenericCommandResult(true, "Genre successfully updated", filteredGenreRequestDTO);
    }
}