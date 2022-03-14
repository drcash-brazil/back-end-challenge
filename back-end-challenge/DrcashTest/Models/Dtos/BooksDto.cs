using System.ComponentModel.DataAnnotations;

namespace DrcashTest.Models.Dtos
{
    public class BookCreateDto
    {
        [Required]
        [
            MaxLength(
                50,
                ErrorMessage = "This field must have only 50 character.")
        ]
        [
            MinLength(
                3,
                ErrorMessage = "This field must have at least 3 character.")
        ]
        public string Titulo { get; set; }

        [Required]
        public int AutorId { get; set; }

        [Required]
        public int GeneroId { get; set; }
    }

    public class BookUpdateDto : BookCreateDto { }

    public class BooksReadDto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public AuthorReadDto Authors { get; set; }

        public GeneroReadDto Categories { get; set; }
    }
}
