using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.Models;

namespace DrcashTest.IRepository
{
    public interface IAccountRepository
    {
        Task<IList<Authors>> GetAll();
        Task<Authors> GetById();
        Task Insert(Authors entity);
        void Update(Authors entity);
        Task Delete(int id);
    }
}