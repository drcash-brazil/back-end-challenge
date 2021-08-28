using System.Threading.Tasks;
using back_end_challenge.Dtos;

namespace back_end_challenge.Services
{
  public interface IAuthManager
  {
    Task<bool> ValidateUser(LoginUserDto userDto);
    Task<string> CreateToken();
  }
}