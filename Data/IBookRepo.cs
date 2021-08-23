using System.Collections.Generic;
namespace back_end_challenge.Data
{
  public interface IBookRepo
  {
    IEnumerable<IBookRepo> GetBooks();
  }
}