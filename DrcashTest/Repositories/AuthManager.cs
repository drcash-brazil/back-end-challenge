using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using back_end_challenge.Models;
using back_end_challenge.Models.Dtos;
using back_end_challenge.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DrcashTest.Repositories
{
  public class AuthManager : IAuthManager
  {
    private readonly UserManager<Users> _userManager;
    private readonly IConfiguration _configuration;
    private Users _user;

    public AuthManager(UserManager<Users> userManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _configuration = configuration;
    }

    public async Task<string> CreateToken()
    {
      var signinCredentials = GetSigninCredentials();
      var claims = await GetClaims();
      var token = GenerateTokenOptions(signinCredentials, claims);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
    {
      var jwtSettings = _configuration.GetSection("Jwt");

      var expiration = DateTime.Now.AddMinutes(Double.Parse(jwtSettings.GetSection("lifetime").Value));

      var token = new JwtSecurityToken(
        issuer: jwtSettings.GetSection("Issuer").Value,
        claims: claims,
        expires: expiration,
        signingCredentials: signinCredentials
      );

      return token;
    }

    private async Task<List<Claim>> GetClaims()
    {
      var claims = new List<Claim>{
        new Claim(ClaimTypes.Name, _user.UserName)
      };

      var roles = await _userManager.GetRolesAsync(_user);

      claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
      
      return claims;
    }

    private SigningCredentials GetSigninCredentials()
    {
      var jwtSettings = _configuration.GetSection("Jwt");
      var key = jwtSettings.GetSection("Secret").Value;
      var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

      return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public async Task<bool> ValidateUser(LoginUserDto userDto)
    {
      _user = await _userManager.FindByNameAsync(userDto.Email);
      return (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
    }
  }
}