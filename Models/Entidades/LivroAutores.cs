using System;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class LivroAutores
    {
        public string livroId {get; set; }
        public Livro Livro { get; set; }
        public string autorId { get; set;  }
        public Autor Autor { get; set; }
    }
}