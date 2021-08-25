using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface IRepositoryBase<T> where T:Base
    {
          Task<Response> add(T model);
          Task<Response> update(T model);
          Task<Response> delete(string id);
          Task<T> get(string search);
          Task<ResponseView> search(string search,int page=0,int limit=0);
          Task<List<T>> search(string search);
          Task<ResponseView> get(int page=0,int limit=0);

    }
}