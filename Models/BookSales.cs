using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace back_end_challenge.Models
{
  public class BookSales
  {
    [Key]
    public int Id { get; set; }

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

    [ForeignKey(nameof(Books))]
    public int BookId { get; set; }
    public Books Book { get; set; }

  }
}