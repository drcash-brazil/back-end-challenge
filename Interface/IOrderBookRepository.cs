using System.Threading.Tasks;
using BackEnd.Models;
namespace BackEnd.Interface
{
    public interface IOrderBookRepository:IRepositoryBase<OrderBooks>
    {
         Task<Response> AddOrderBook(OrderBooks obj);
          Task<Response> OrderBookProcess(string id);
         Task<Response> CanceledOrder(string id);
         Task<ResponseView> OrderBooks(int page,int limit);
    }
}