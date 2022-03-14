using System.Collections.Generic;
using System.Threading.Tasks;
using back_end_challenge.Models;

namespace DrcashTest.IRepository
{
    public interface ICategoryRepository
    {
        Task<IList<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<Category> Insert(Category entity);
        Task<bool> Update(Category entity);
        Task<bool> Delete(int id, Category entity);
    }
}