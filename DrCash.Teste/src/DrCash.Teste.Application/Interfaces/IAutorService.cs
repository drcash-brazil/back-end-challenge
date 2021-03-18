using DrCash.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Interfaces
{
    public interface IAutorService : IDisposable
    {
        Task Adicionar(Autor autor);
    }
}
