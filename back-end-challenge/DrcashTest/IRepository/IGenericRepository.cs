using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrcashTest.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id, T entity);
    }
}