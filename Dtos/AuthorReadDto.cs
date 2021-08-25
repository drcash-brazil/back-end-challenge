using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{
  public class AuthorReadDto
  {
    public int Id { get; set; }
    public string nome { get; set; }
    public IList<BooksReadDto> Books { get; set; }
  }
}