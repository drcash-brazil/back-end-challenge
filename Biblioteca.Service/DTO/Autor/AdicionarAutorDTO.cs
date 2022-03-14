using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Autor
{
    public class AdicionarAutorDTO
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
    }
}
