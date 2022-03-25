using System;

namespace BookStoreCrudWebApi.Models.Entidades
{
    public class GeneroLivro
    {
       public string livroId { get; set; }
       public Livro Livro { get; set; }
       public string generoId { get; set; } 
       public Genero Genero { get; set; }
    }
}