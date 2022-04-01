using BookStore.Domain.Entities;
using BookStore.Domain.Infra.Context;
using BookStore.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Domain.Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DataContext _context;

    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Book entity)
    {
        _context.Book!.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Book> GetAll()
    {

        return _context.Book!
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .AsNoTracking().ToList();
    }

    public Book GetById(Guid id)
    {
        return _context.Book!
            .Include(x => x.Author)
            .Include(x => x.Genre)
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Book entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public bool Delete(Guid id)
    {
        var book = _context.Book!.FirstOrDefault(x => x.Id == id);

        if (book == null)
            return false;

        _context.Book!.Remove(book);

        _context!.SaveChanges();

        return true;
    }
}