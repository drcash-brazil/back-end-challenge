using System.Collections.Generic;
using back_end_challenge.Models;

namespace back_end_challenge.Data
{
  public interface IBookRepo
  {
    IEnumerable<Books> GetBooks();
    Books GetBookById(int id);
  }
}