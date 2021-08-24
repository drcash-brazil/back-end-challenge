using BackEnd.Models;

namespace BackEnd.Interface
{
    public interface ITokenService
    {
        string GenerateToken(Users user);
    }
}