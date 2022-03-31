using BookStore.Domain.Entities;
using BookStore.Domain.Infra.Context;
using BookStore.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Domain.Infra.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly DataContext _context;

    public AuthorRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Author entity)
    {
        _context.Author!.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Author> GetAll()
    {
        return _context.Author!.AsNoTracking().ToList();
    }

    public Author GetById(Guid id)
    {
        return _context.Author
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Author entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public bool Delete(Guid id)
    {
        var author = _context.Author!.FirstOrDefault(x => x.Id == id);

        if (author == null)
            return false;

        _context.Author!.Remove(author);

        _context!.SaveChanges();

        return true;
    }

}