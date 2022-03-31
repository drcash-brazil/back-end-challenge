namespace BookStore.Domain.Commands.Contracts;

public interface ICommand
{
    bool Validate();
}