using BackEnd.DbConfig;
using BackEnd.Interface;
using BackEnd.Models;

namespace BackEnd.Repositories
{
    public class MovementRepository:RepositoryBase<Movement>,IMovementRepository
    {
        private readonly BackEndContext _context;
        public  MovementRepository( BackEndContext context):base(context)
        {
            _context=context;
        }
       
        
    }
}