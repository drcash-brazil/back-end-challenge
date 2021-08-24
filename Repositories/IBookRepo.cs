using System.Collections.Generic;
using back_end_challenge.Models;

namespace back_end_challenge.Repositories
{
  public interface IBookRepo
  {
    bool SavaChanges();
    IEnumerable<Books> GetBooks();
    Books GetBookById(int id);
    void CreateBook(Books book);
    void UpdateBook(Books book);
    void DeleteBook(Books book);

  }
}