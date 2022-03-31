using BookStore.Domain.Entities;
using BookStore.Domain.Infra.Context;
using BookStore.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace BookStore.Domain.Infra.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly DataContext _context;

    public GenreRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Genre entity)
    {
        _context.Genre!.Add(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Genre> GetAll()
    {
        return _context.Genre!.AsNoTracking().ToList();
    }

    public Genre GetById(Guid id)
    {
        return _context.Genre
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
    }

    public void Update(Genre entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public bool Delete(Guid id)
    {
        var genre = _context.Genre!.FirstOrDefault(x => x.Id == id);

        if (genre == null)
            return false;

        _context.Genre!.Remove(genre);

        _context!.SaveChanges();

        return true;
    }
}