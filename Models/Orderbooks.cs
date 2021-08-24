using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class OrderBooks:Base
    {
        public string bookId{get;set;}
        public string status{get;set;}
        public DateTime? orderDate{get;set;}
        public long orderQuantity{get;set;}
        [ForeignKey("bookId")]
        public virtual Books books{get;set;}

    }
}