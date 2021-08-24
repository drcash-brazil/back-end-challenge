using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace BackEnd.Models
{
    public class Generous:Base
    {
        [Required(ErrorMessage="name is required")]
        public string name{get;set;}
        public ICollection<Books> books { get;set;}
    }
       

}