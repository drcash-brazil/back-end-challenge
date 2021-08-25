using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IMovementRepository:IRepositoryBase<Movement>
    {
       Task<Response> AddSale(Movement obj);
     
       Task<ResponseView> Sales(int page = 0, int limit = 0);
       Task<ResponseView> Deposits(int page = 0, int limit = 0);
       
       Task<ResponseView> SearchSales(string search, int page = 0, int limit = 0);
       Task<ResponseView> SearchDeposits(string search, int page = 0, int limit = 0);
    }
}