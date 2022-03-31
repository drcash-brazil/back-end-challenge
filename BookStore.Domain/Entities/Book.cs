namespace BookStore.Domain.Entities;

public class Book : Entity
{
    public Book(string title, int authorId, Author? author, int genreId, Genre? genre, int numberOfCopies)
    {
        Title = title;
        AuthorId = authorId;
        Author = author;
        GenreId = genreId;
        Genre = genre;
        NumberOfCopies = numberOfCopies;
    }

    public string Title { get; private set; } = String.Empty;
    public int AuthorId { get; set; }
    public Author? Author { get; private set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; private set; }
    public int NumberOfCopies { get; private set; }

    public void UpdateBook(
        string title,
        int authorId,
        Author? author,
        int genreId,
        Genre? genre,
        int numberOfCopies
    )
    {
        Title = title;
        AuthorId = authorId;
        Author = author;
        GenreId = genreId;
        Genre = genre;
        NumberOfCopies = numberOfCopies;
    }
}