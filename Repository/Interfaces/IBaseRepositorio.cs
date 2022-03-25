using System.Threading.Tasks;

namespace BookStoreCrudWebApi.Repository.Interfaces
{
    public interface IBaseRepositorio
    {
        public void Adicionar<T>(T entity) where T : class;
        public void Atualizar<T>(T entity) where T : class;
        public void Eliminar<T>(T entity) where T : class;
        Task<bool> Salvar();
        Task<T> AdicionarAsync<T>(T entidade) where T : class;
    }
}