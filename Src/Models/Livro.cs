using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaDrCash.Models{
    public class Livro{
        public Guid Id {get;set;}
        public string Titulo {get;set;}
        public int NumCopias {get;set;}

        public  ICollection<Genero> Generos {get;set;}
        public  ICollection<Autor> Autores {get;set;}

    }

    public class LivroInDTO {
        public string Titulo {get;set;}
        public int NumCopias {get;set;}

        public ICollection<Guid> Generos {get;set;}
        public ICollection<Guid> Autores {get;set;}

    }

}