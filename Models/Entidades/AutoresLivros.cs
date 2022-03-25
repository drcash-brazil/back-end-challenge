using System;
using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class AutoresLivros : Base
    {
        public string livroId {get; set; }
        public Livro Livro { get; set; }
        public string autorId { get; set;  }
        public Autor Autor { get; set; }
    }
}