using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Data.IRepository
{
    public interface ILivroRepository: ICRUD<Livro>
    {
    }
}