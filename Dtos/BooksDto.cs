using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{
  public class BooksDto
  {
    [Required]
    [MaxLength(50)]
    public string Titulo { get; set; }

    [Required]
    [MaxLength(100)]
    public string Autor { get; set; }

    [Required]
    [MaxLength(20)]
    public string Genero { get; set; }

    [Required]
    public int NumCopias { get; set; }

  }
}