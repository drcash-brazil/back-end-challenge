using System.Threading.Tasks;
using back_end_challenge.Models.Dtos;

namespace DrcashTest.Services
{
  public interface IAuthManager
  {
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
  }
}