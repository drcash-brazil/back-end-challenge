using System.Collections.Generic;
using back_end_challenge.Models;

namespace back_end_challenge.Data
{
  public class BooksMockRepo : IBookRepo
  {
    public Books GetBookById(int id)
    {
      return new Books { Id = 1, Autor = "Dércio Derone", Genero = "Romance" };
    }

    public IEnumerable<Books> GetBooks()
    {
      var books = new List<Books>(){
        new Books { Id = 1, Autor = "Dércio Derone", Genero = "Romance" },
        new Books { Id = 2, Autor = "Dr. Cash", Genero = "IT" },
        new Books { Id = 3, Autor = "Kiari Code", Genero = "Empreendedorismo" },
      };
      return books;
    }
  }
}