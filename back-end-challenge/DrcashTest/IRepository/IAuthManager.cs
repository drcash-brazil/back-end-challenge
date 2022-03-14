using System.Threading.Tasks;
using DrcashTest.Models.Dtos;

namespace DrcashTest.IRepository
{
  public interface IAuthManager
  {
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
  }
}