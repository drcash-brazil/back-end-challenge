using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrCashChallenge.Api.ViewModels
{
    public class BookViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(255, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Title { get; set; }
        public AuthorViewModel AuthorViewModel { get; set; }
        public GenreViewModel GenreViewModel { get; set; }
    }
}
