using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Books:Base
    {
        [Required(ErrorMessage="title is required")]
        public string title{get;set;}
        public string authorId{get;set;}
        public string genreId{get;set;}
        [Required(ErrorMessage="quantity is required")]
        public long quantity{get;set;}
        [ForeignKey("authorId")]
        public virtual Authors authors{get;set;}
        [ForeignKey("genreId")]
        public virtual Generous generous{get;set;}
        public ICollection<Movement> movement{get;set;}
        public ICollection<OrderBooks> orderBooks{get;set;}
      
    }
}