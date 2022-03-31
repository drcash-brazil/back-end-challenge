using BookStore.Domain.Commands.Contracts;

namespace BookStore.Domain.Commands;

public class GenericCommandResult : ICommandResult
{
    public GenericCommandResult()
    { }
    public GenericCommandResult(bool success, string message, object? data)
    {
        this.success = success;
        Message = message;
        Data = data;
    }

    public bool success { get; set; }
    public string Message { get; set; } = String.Empty;
    public object? Data { get; set; }
}