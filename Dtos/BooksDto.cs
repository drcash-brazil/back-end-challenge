using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{
  public class BooksDto
  {

    [Required]
    [MaxLength(50, ErrorMessage = "This field must have only 50 character.")]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    public string Titulo { get; set; }

    [Required]
    public int NumCopias { get; set; }

    public int AutorId { get; set; }

    public int GeneroId { get; set; }
  }
}