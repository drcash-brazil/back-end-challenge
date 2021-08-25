using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_DrChash.Models
{
    public class Livro
    {

        [Key]
        public int LivroId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [Required]
        public int NCopias { get; set; }

        //Relacionamentos...
        public virtual ICollection<Autor> Autores { get; set; }
        public virtual ICollection<Genero> Generos { get; set; }
    }
}
