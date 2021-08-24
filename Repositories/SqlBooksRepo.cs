using System;
using System.Collections.Generic;
using System.Linq;
using back_end_challenge.Models;

namespace back_end_challenge.Repositories
{
  public class SqlBooksRepo : IBookRepo
  {
    public AppDbContext _context { get; }
    public SqlBooksRepo(AppDbContext context)
    {
      _context = context;
    }

    public Books GetBookById(int id)
    {
      return _context.Books.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<Books> GetBooks()
    {
      return _context.Books.ToList();
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
  }
}