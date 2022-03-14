using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Genero
{
    public class GeneroDTO
    {
        public Guid GeneroId { get; set; }
        public string Descricao { get; set; }
    }
}