using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrcashTest.Models
{
    public class Books
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "This field must have only 50 character.")]
        [MinLength(3, ErrorMessage = "This field must have at least 3 character.")]
        public string Titulo { get; set; }

        [ForeignKey(nameof(Authors))]
        public int AutorId { get; set; }

        public Authors Authors { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }

        public Genero Categories { get; set; }
    }
}
