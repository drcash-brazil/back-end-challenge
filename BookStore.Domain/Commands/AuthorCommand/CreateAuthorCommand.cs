using BookStore.Domain.Commands.Contracts;

namespace BookStore.Domain.Commands.AuthorCommand;

public class CreateAuthorCommand : ICommand
{
    public CreateAuthorCommand(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = String.Empty;

    public bool Validate()
    {
        bool state = true;

        if (Name.Length < 4)
            state = false;

        return state;
    }
}