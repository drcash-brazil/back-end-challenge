using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Livro
{
    public class AdicionarLivroDTO
    {
        [Required]
        [StringLength(200)]
        public string Titulo { get;  set; }
        [Required]
        public int Quantidade { get;  set; }

        [Required]
        public Guid AutorId { get;  set; }
        [Required]
        public Guid GeneroId { get;  set; }
    }
}