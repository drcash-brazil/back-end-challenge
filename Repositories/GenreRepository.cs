using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;
namespace BackEnd.Repositories
{
    public class GenreRepository:RepositoryBase<Generous>,IGenreRepository
    {
        private readonly BackEndContext _context;
        public  GenreRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
       
        
    }
}