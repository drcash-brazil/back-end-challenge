using BookStoreCrudWebApi.Repository.Interfaces;
using BookStoreCrudWebApi.Context;
using System.Threading.Tasks;

namespace BookStoreCrudWebApi.Repository
{
    public class BaseRepositorio : IBaseRepositorio
    {
        private readonly BookStoreContext _contexto;
        public BaseRepositorio(BookStoreContext contexto)
        {
            _contexto = contexto;
        }

        public BookStoreContext Context { get; }

        public void Adicionar<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
        }
        public async Task<T> AdicionarAsync<T>(T entidade) where T : class
        {
            _contexto.Add(entidade);
            await Salvar();
            return entidade;
        }

        public void Eliminar<T>(T entidade) where T : class
        {
            _contexto.Remove(entidade);
        }

        public async Task<bool> Salvar()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            _contexto.Update(entidade);
        }
    }
}