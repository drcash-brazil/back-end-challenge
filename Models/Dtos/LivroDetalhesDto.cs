using BookStoreCrudWebApi.Models.Entidades;
using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Dtos
{
    public class LivroDetalhesDto
    {
        public string Titulo { get; set;  }
        public long QuantidadeCopias{get; set; } 
        public List<AutorDto> Autores { get; set; }
        public List<GeneroDto> Genero { get; set; }
    }
}