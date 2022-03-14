using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO.Autor;
using Biblioteca.Service.DTO.Genero;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Service.DTO.Livro
{
    [Display(Name = "Livro")]
    public class LivroDTO
    {
        public LivroDTO()
        {

        }

        public LivroDTO(Domain.Entities.Livro objeto)
        {
            LivroId = objeto.LivroId;
            Titulo = objeto.Titulo;
            AutorDTO = new AutorDTO { AutorId = objeto.Autor.AutorId, Nome = objeto.Autor.Nome };
            GeneroDTO = new GeneroDTO { GeneroId = objeto.Genero.GeneroId, Descricao = objeto.Genero.Descricao };
        }

        public Guid LivroId { get; set; }
        public string Titulo { get; set; }
        public int Quantidade { get; set; }

        [Display(Name = "Autor")]
        public AutorDTO AutorDTO { get; set; }
        [Display(Name = "Genero")]
        public GeneroDTO GeneroDTO { get; set; }
    }
}