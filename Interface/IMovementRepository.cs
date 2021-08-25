using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IMovementRepository:IRepositoryBase<Movement>
    {
       Task<Response> AddSale(Movement obj);
     
       Task<ResponseView> Sales(string _search=null,int page = 0, int limit = 0);
       Task<ResponseView> Deposits(string _search=null,int page = 0, int limit = 0);
       Task<ResponseView> Movements(string _search=null,int page = 0, int limit = 0);
      
    }
}