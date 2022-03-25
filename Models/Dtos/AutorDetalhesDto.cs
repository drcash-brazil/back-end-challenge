using System;
using System.Collections.Generic;
using BookStoreCrudWebApi.Models.Entidades;
namespace BookStoreCrudWebApi.Models.Dtos
{
    public class AutorDetalhesDto
    {
        public string Id { get; set; }
        public string NomeAutor {get; set; }
        public List<Livro> Livros { get; set; }
    }
}