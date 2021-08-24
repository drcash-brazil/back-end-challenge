using System.Linq;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;

namespace BackEnd.Repositories
{
    public class UserRepository:RepositoryBase<Users>,IUserRepository
    {
        private readonly BackEndContext _context;
        public  UserRepository( BackEndContext context):base(context)
        {
              _context=context;
        }
        public async Task<Users> getUser(string username,string password)
        {
           var users= await get();
           var user=users.Where(r=>r.username==username &&  r.password==password).FirstOrDefault();
           user.password=null;
           return  user;
        }

    }
}