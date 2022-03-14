using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrcashTest.Models
{
  public class Authors
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "This field must have only 100 character.")]
    [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
    public string nome { get; set; }

    public virtual IList<Books> Books { get; set; }
  }
}