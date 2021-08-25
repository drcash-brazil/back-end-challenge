
using back_end_challenge.Models;

namespace back_end_challenge.Dtos
{
  public class BooksReadDto
  {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumCopias { get; set; }
    public AuthorReadDto Authors { get; set; }
    public CategoryReadDto Categories { get; set; }
  }
}