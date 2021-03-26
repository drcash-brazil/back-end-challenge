using System;
using System.ComponentModel.DataAnnotations;

namespace DrCashChallenge.Api.ViewModels
{
    public class AuthorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(255, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
