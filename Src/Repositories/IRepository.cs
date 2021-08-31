using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaDrCash.Repository{
    public interface IRepository<T> where T:class{

        Task AddAsync(T autor);
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
        Task<T> RemoveAsync(Guid id);
        Task RemoveAsync(T autor);
        Task UpdateAsync(T autor);
    }
}