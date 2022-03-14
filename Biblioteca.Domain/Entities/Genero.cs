using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Entities
{
    public class Genero
    {
        protected Genero()
        {

        }

        //adicionar
        public Genero(string descricao)
        {
            GeneroId = Guid.NewGuid();
            Descricao = descricao;
        }

        public Guid GeneroId { get; private set; }
        public string Descricao { get; private set; }

        public List<Livro> Livros { get; private set; }

        public void Editar(string descricao)
        {
            Descricao = descricao;
        }
    }
}