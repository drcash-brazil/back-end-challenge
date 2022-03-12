using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrcashTest.Models
{
    public class Genre
    {
        [Key()]
        public Guid GenreId { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string name { get; set; }
    }
}
