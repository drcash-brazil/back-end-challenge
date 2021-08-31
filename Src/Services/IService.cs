using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaDrCash.Services{
    public interface IService<T> where T:class{
        Task<IEnumerable<T>> ListAsync();
        Task<T> FindAsync(Guid id);
        Task UpdateAsync(T entry);
        Task AddAsync(T entry);
        Task<T> DeleteAsync(Guid id);
    }
}