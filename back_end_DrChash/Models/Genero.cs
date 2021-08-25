using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_DrChash.Models
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Definicao { get; set; }

        //Relacionamentos...
        public virtual Livro Livros { get; set; }
        
        public int LivroId { get; set; }
    }
}
