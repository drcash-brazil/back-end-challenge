using DrCash.Teste.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Interfaces
{
    public interface IGeneroService : IDisposable
    {
        Task Adicionar(Genero genero);
    }
}

