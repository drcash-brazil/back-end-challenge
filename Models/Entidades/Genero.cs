using System;
using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class Genero : Base
    {
        public string genero {get; set; }
        public ICollection<GeneroLivro> GeneroLivro {get; set;}
    }
}