using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreCrudWebApi.Models.Entidades;
namespace BookStoreCrudWebApi.Models.Dtos
{
    public class LivroDto
    {
        public string Id { get; set; }
        public string Titulo { get; set;  }
        public long QuantidadeCopias{get; set; } 
        public List<Autor> Autores { get; set; }
        public List<Genero> Genero { get; set; }
    }
}