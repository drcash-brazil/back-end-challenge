using BookStore.Domain.Commands.Contracts;

namespace BookStore.Domain.Handlers;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}