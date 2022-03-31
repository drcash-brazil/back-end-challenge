using BookStore.Domain.Commands.Contracts;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Commands.BooksCommand;

public class CreateBookCommand : ICommand
{

    public CreateBookCommand()
    { }
    public CreateBookCommand(string title, Guid authorId, Author? author, Guid genreId, Genre? genre, int numberOfCopies)
    {
        Title = title;
        AuthorId = authorId;
        Author = author;
        GenreId = genreId;
        Genre = genre;
        NumberOfCopies = numberOfCopies;
    }

    public string Title { get; set; } = String.Empty;
    public Guid AuthorId { get; set; }
    public Author? Author { get; set; }
    public Guid GenreId { get; set; }
    public Genre? Genre { get; set; }
    public int NumberOfCopies { get; set; }

    public bool Validate()
    {
        bool state = true;

        if (
            Title.Length < 4 ||
            Author?.Id == Guid.Empty ||
            Genre?.Id == Guid.Empty
            )
            state = false;

        return state;
    }
}