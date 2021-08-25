using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IBookRepository :IRepositoryBase<Books>
    {
         Task<Response> AddBook(Books obj);
         Task<ResponseView> Books(string _search=null,int page=0,int limit =0);
         
    }
    
}