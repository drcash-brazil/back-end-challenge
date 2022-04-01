using System.Text.Json.Serialization;

namespace BookStore.Domain.Entities;

public class Book : Entity
{
    public Book(string title, Guid authorId, Guid genreId, int numberOfCopies)
    {
        Title = title;
        AuthorId = authorId;
        GenreId = genreId;
        NumberOfCopies = numberOfCopies;
    }

    public string Title { get; private set; } = String.Empty;

    [JsonIgnore]
    public Guid AuthorId { get; set; }

    public Author Author { get; private set; }

    [JsonIgnore]
    public Guid GenreId { get; set; }
    public Genre Genre { get; private set; }
    public int NumberOfCopies { get; private set; }

    public void UpdateBook(
        string title,
        Guid authorId,
        Guid genreId,
        int numberOfCopies
    )
    {
        Title = title;
        AuthorId = authorId;
        GenreId = genreId;
        NumberOfCopies = numberOfCopies;
    }
}