using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IUserRepository:IRepositoryBase<Users>
    {
         Task<Users> getUser(string username,string password);
    }
}