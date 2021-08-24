using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Authors:Base
    {
        [Required(ErrorMessage="name is required")]
        public string name{get;set;}
     
        public ICollection<Books> books { get;set;}
    }
}