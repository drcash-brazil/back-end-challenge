using DrCash.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Interfaces
{
    public interface ILivroService : IDisposable
    {
        Task Adicionar(Livro livro);
        Task Atualizar(Livro livro);
        Task Remover(Guid id);
    }
}
