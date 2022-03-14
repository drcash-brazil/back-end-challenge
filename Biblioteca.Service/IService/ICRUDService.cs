using Biblioteca.Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.IService
{
    public interface ICRUDService<TEntity>: IDisposable where TEntity: class
    {       
        Task<ResultadoDTO<TEntity>> BuscarPorId(Guid id);
        Task<ResultadoDTO<List<TEntity>>> Listar();
        Task<ResultadoDTO<TEntity>> Remover(Guid id);
    }
}