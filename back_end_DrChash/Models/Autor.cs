using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_DrChash.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        //Relacionamentos...
        public virtual Livro Livros { get; set; }

        public int LivroId { get; set; }
    }
}
