using System.Collections.Generic;
using back_end_challenge.Models;

namespace back_end_challenge.Data
{
  public class BooksMockRepo : IBookRepo
  {
    public Books GetBookById(int id)
    {
      return new Books { Id = 1, Titulo = "Titulo 1", Autor = "Dércio Derone", Genero = "Romance", NumCopias = 2 };
    }

    public IEnumerable<Books> GetBooks()
    {
      var books = new List<Books>(){
        new Books { Id = 1, Titulo="Titulo 1", Autor = "Dércio Derone", Genero = "Romance", NumCopias=2 },
        new Books { Id = 2, Titulo="Titulo 2", Autor = "Dr. Cash", Genero = "IT", NumCopias=3 },
        new Books { Id = 3, Titulo="Titulo 3", Autor = "Kiari Code", Genero = "Empreendedorismo", NumCopias=6 },
      };
      return books;
    }
  }
}