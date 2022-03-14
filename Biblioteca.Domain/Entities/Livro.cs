using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Entities
{
    public class Livro
    {
        protected Livro()
        {

        }

        //adicionar
        public Livro(string titulo, int quantidade, Guid autorId, Guid generoId)
        {
            LivroId = Guid.NewGuid();
            Titulo = titulo;
            Quantidade = quantidade;
            AutorId = autorId;
            GeneroId = generoId;
        }

        public Guid LivroId { get; private set; }
        public string Titulo { get; private set; }
        public int Quantidade { get; private set; }

        public Guid AutorId { get; private set; }
        public Autor Autor { get; private set; }

        public Guid GeneroId { get; private set; }
        public Genero Genero { get; private set; }

        public void Editar(string titulo, int quantidade, Guid autorId, Guid generoId)
        {
            Titulo = titulo;
            Quantidade = quantidade;
            AutorId = autorId;
            GeneroId = generoId;
        }
    }
}