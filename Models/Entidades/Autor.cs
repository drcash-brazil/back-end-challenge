using System;
using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class Autor : Base
    {
        public string NomeAutor {get; set; }
        public ICollection<LivroAutores> LivroAutores { get; set; }
    }
}