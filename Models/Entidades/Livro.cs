using System;
using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class Livro : Base
    {
        public string Titulo { get; set;  }
        public long QuantidadeCopias{get; set; } 
        public ICollection<LivroAutores> LivroAutores { get; set; }
        public ICollection<GeneroLivro> GeneroLivro { get; set; }
    }

}