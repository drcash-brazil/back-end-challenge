using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Domain.Entities
{
    public class Autor
    {
        protected Autor()
        {

        }

        //adicionar
        public Autor(string nome)
        {
            Guid.NewGuid();
            Nome = nome;
        }

        public Guid AutorId { get; private set; }
        public string Nome { get; private set; }

        public List<Livro> Livros { get; private set; }

        public void Editar(string nome)
        {            
            Nome = nome;
        }
    }
}