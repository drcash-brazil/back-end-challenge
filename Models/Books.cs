using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Books:Base
    {
        
        public string title{get;set;}
        public string authorId{get;set;}
        public string genreId{get;set;}
        public long quantity{get;set;}
        [ForeignKey("authorId")]
        public virtual Authors authors{get;set;}
        [ForeignKey("genreId")]
        public virtual Generous generous{get;set;}
      
    }
}