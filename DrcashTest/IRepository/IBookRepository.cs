using System.Collections.Generic;
using System.Threading.Tasks;
using back_end_challenge.Models;

namespace DrcashTest.IRepository
{
    public interface IBookRepository
    {
        Task<IList<Books>> GetAll();
        
        Task<Books> GetById(int id);
        
        Task<Books> GetBookByName(string name);
        
        Task<Books> Insert(Books entity);
        
        Task<bool> Update(Books entity);
        
        Task<bool> Delete(int id, Books entity);
    }
}