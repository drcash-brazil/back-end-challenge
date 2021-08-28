using System.Threading.Tasks;
using System;
using back_end_challenge.Models;

namespace back_end_challenge.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<Authors> Authors { get; }
    IGenericRepository<Category> Categories { get; }
    IGenericRepository<BookSales> BookSales { get; }
    IGenericRepository<Books> Books { get; }
    Task ToSave();
  }
}