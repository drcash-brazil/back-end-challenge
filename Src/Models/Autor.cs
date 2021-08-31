using System;
using System.Collections.Generic;

namespace BibliotecaDrCash.Models{

    public class Autor{
        public Guid Id {get;set;}
        public string Nome {get;set;}

        public  ICollection<Livro> Livros {get;set;}
    }

    public class AutorDTO{
        public Guid Id {get;set;}
        public string Nome {get;set;}

    }
}