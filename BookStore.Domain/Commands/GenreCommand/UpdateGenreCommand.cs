using BookStore.Domain.Commands.Contracts;

namespace BookStore.Domain.Commands.GenreCommand;

public class UpdateGenreCommand : ICommand
{
    public UpdateGenreCommand(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public bool Validate()
    {
        bool state = true;

        if (
            Name.Length < 4 ||
            Id == Guid.Empty
            )
            state = false;

        return state;
    }
}