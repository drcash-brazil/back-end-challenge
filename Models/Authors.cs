using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Authors:Base
    {
        
        public string name{get;set;}
     
        public ICollection<Books> books { get;set;}
    }
}