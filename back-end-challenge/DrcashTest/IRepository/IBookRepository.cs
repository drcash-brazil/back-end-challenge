using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.Models;

namespace DrcashTest.IRepository
{
    public interface IBookRepository : IGenericRepository<Books>
    {
        Task<IList<Books>> GetBookByName(string name);
    }
}