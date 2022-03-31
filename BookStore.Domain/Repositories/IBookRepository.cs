using BookStore.Domain.Entities;

namespace BookStore.Domain.Repositories;

public interface IBookRepository : IGenericRepository<Book>
{
    IEnumerable<Book> GetBookByAuthor(string author);
}