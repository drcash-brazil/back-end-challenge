using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrcashTest.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [ForeignKey("Authors")]
        [Required(ErrorMessage = "AuthorId is required")]
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("Genres")]
        [Required(ErrorMessage = "GenreId is required")]
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public int NumberCopies { get; set; }
    }
}
