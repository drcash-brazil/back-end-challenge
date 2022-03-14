using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.Models;

namespace DrcashTest.IRepository
{
    public interface IAuthorsRepository : IGenericRepository<Authors>
    {
        Task<Authors> GetByAuthorWithBooks(int id);
        Task<IList<Authors>> GetByName(string name);
    }
}