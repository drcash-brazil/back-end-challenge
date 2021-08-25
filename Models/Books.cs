using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Models
{
  public class Books
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "This field must have only 50 character.")]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    public string Titulo { get; set; }

    [Required]
    public int NumCopias { get; set; }

    [ForeignKey(nameof(Authors))]
    public int AutorId { get; set; }
    public Authors Authors { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category Categories { get; set; }

  }
}