using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.Models;

namespace DrcashTest.IRepository
{
    public interface IAuthorsRepository
    {
        Task<IList<Authors>> GetAll();
        Task<Authors> GetById(int id);
        
        Task<Authors> GetByAuthorWithBooks(int id);
        
        Task<Authors> GetByName(string name);

        Task<Authors> Insert(Authors entity);
        Task<bool> Update(Authors entity);
        Task<bool> Delete(int id, Authors entity);
    }
}