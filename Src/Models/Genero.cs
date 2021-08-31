using System;
using System.Collections.Generic;

namespace BibliotecaDrCash.Models{

    public class Genero{
        public Guid Id {get;set;}
        public string Nome {get;set;}

        public  ICollection<Livro> Livros {get;set;}
    }

       public class GeneroDTO{
        public Guid Id {get;set;}
        public string Nome {get;set;}

    }

}