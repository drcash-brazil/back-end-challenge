using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IAuthorRepository :IRepositoryBase<Authors>
    {
        Task<ResponseView> Authors(string _search=null,int page=0,int limit =0);
       
    }
}