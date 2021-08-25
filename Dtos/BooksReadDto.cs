
using back_end_challenge.Models;

namespace back_end_challenge.Dtos
{
  public class BooksReadDto
  {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumCopias { get; set; }
    // public int AutorId { get; set; }
    public Authors Autor { get; set; }
    // public int GeneroId { get; set; }
    public Category Genero { get; set; }

  }
}