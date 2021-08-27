using System.Linq;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using back_end_challenge.Models;
using X.PagedList;

namespace back_end_challenge.IRepository
{
  public interface IGenericRepository<T> where T : class
  {
    Task<IList<T>> GetAll(
      Expression<Func<T, bool>> expression = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      List<string> includes = null
    );

    Task<IPagedList<T>> GetAll(
      RequestParams requestParams,
      Expression<Func<T, bool>> expression = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      List<string> includes = null
    );

    Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
    Task Insert(T entity);
    Task InsertRange(IEnumerable<T> entities);
    void Update(T entity);
    Task Delete(int id);
    void DeleteRange(IEnumerable<T> entities);

  }
}