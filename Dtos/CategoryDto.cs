using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{
  public class CategoryDTO
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "This field must have only 100 character.")]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    public string nome { get; set; }
  }
}