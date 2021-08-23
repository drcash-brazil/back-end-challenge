using System.Collections.Generic;
using System.Linq;
using back_end_challenge.Models;

namespace back_end_challenge.Data
{
  public class SqlBooksRepo : IBookRepo
  {
    public CoreContext _context { get; }
    public SqlBooksRepo(CoreContext context)
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
  }
}