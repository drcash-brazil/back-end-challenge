using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Genero
{
    public class AtualizarGeneroDTO
    {
        [Required]
        public Guid GeneroId { get; set; }
        [Required]
        [StringLength(200)]
        public string Descricao { get; set; }
    }
}
