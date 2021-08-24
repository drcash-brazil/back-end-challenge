using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace BackEnd.Models
{
    public class Generous:Base
    {
        public string name{get;set;}
        public ICollection<Books> books { get;set;}
    }
       

}