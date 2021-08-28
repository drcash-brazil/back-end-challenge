using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace back_end_challenge.Dtos
{
  public class BookSalesCreateDto
  {

    [Required]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    [MaxLength(50, ErrorMessage = "This field must have only 50 character.")]
    public string ClientName { get; set; }

    [Required]
    [MinLength(5, ErrorMessage = "This field must have at least 3 character.")]
    [MaxLength(50, ErrorMessage = "This field must have only 50 character.")]
    [DataType(DataType.EmailAddress)]
    public string ClientEmail { get; set; }

    [Required]
    public int QuantityToReduce { get; set; }

    [Required]
    public int BookId { get; set; }
  }

  public class BookSalesUpdateDto : BookSalesCreateDto { }

  public class BookSalesReadDto : BookSalesCreateDto
  {
    public int Id { get; set; }
    public BooksReadDto Book { get; set; }

  }

}