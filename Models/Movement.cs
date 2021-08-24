using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Movement:Base
    {
        public double value{get;set;}
        public long quantity{get;set;}
        public string bookId{get;set;}
        public DateTime? dateCreated{get;set;}
        [ForeignKey("bookId")]
        public Books book {get;set;} 
    }
}