using System;
using System.Collections.Generic;
using System.Linq;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace back_end_challenge.Repositories
{
  public class BooksRepo : IBookRepo
  {
    public DataContext _context { get; }
    public BooksRepo(DataContext context)
    {
      _context = context;
    }

    public Books GetBookById(int id)
    {
      return _context.Books
                  .Include(e => e.Authors)
                  .Include(e => e.Categories)
                  .AsNoTracking()
                  .FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Books> GetBooks()
    {
      var result = _context.Books
                  .Include(e => e.Authors)
                  .Include(e => e.Categories)
                  .AsNoTracking()
                  .ToList();
      return result;
      // return _context.Books
      // .OrderByDescending(x => x.Id).ToList();
    }

    public bool SavaChanges()
    {
      return (_context.SaveChanges() >= 0);
    }

    public void CreateBook(Books book)
    {
      if (book is null) throw new ArgumentNullException(nameof(book));
      _context.Add(book);
    }

    public void UpdateBook(Books book)
    {
      // Do not have to do anything here
    }

    public void DeleteBook(Books book)
    {
      if (book is null) throw new ArgumentNullException(nameof(book));
      _context.Books.Remove(book);
    }
  }
}