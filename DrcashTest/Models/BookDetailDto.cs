using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrcashTest.Models
{
    public class BookDetailDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int NumberCopies { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }

        
    }
}
