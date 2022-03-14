using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.IRepository
{
    public interface ICRUD<TEntity> : IDisposable where TEntity : class
    {
        public Task<bool> Adicionar(TEntity objeto);
        public Task<bool> Atualizar(TEntity objeto);
        public Task<TEntity> BuscarPorId(Guid id);
        public Task<List<TEntity>> Encontrar(Expression<Func<TEntity, bool>> expressao, int quantidade = 100);
        Task<List<TEntity>> Listar();
        public Task<bool> Remover(TEntity objeto);
    }
}
