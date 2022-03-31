using BookStore.Domain.Commands;
using BookStore.Domain.Commands.BooksCommand;
using BookStore.Domain.Commands.Contracts;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;

namespace BookStore.Domain.Handlers;

public class BookHandler :
    IHandler<CreateBookCommand>,
    IHandler<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public BookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public ICommandResult Handle(CreateBookCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var bookRequestDTO = new Book(
            title: command.Title,
            authorId: command.AuthorId,
            author: command.Author,
            genreId: command.GenreId,
            genre: command.Genre,
            numberOfCopies: command.NumberOfCopies
        );

        _bookRepository.Create(bookRequestDTO);

        return new GenericCommandResult(true, "Book successfully created", bookRequestDTO);
    }

    public ICommandResult Handle(UpdateBookCommand command)
    {
        if (!command.Validate())
            return new GenericCommandResult(false, "Ops!, Please verify that the data is completely correct", null);

        var filteredBookRequestDTO = _bookRepository.GetById(command.Id);

        filteredBookRequestDTO.UpdateBook(
            title: command.Title,
            authorId: command.AuthorId,
            author: command.Author,
            genreId: command.GenreId,
            genre: command.Genre,
            numberOfCopies: command.NumberOfCopies
        );

        _bookRepository.Update(filteredBookRequestDTO);

        return new GenericCommandResult(true, "Book successfully updated", filteredBookRequestDTO);
    }
}