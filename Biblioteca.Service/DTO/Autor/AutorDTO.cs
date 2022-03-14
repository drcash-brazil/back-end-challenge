using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Autor
{
    public class AutorDTO
    {        
        public Guid AutorId { get; set; }
        public string Nome { get; set; }
    }
}
