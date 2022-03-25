using System.Collections.Generic;

namespace BookStoreCrudWebApi.Models.Dtos
{
    public class LivroAutorCadastrar
    {
        public string Titulo { get; set;  }
        public long QuantidadeCopias{get; set; }
        public List<AutorCadastrarDto> Autores { get; set; }
        public List<GeneroCadastrarDto> Genero { get; set; }
    }
}