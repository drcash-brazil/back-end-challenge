using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrcashTest.IRepository;
using DrcashTest.Models;
using DrcashTest.Models.Dtos;
using DrcashTest.Services;
using DrcashTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DrcashTest.Controllers
{
  [Route("api/account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<Users> _userManager;
    private readonly ILogger<AccountController> _logger;
    private readonly IMapper _mapper;
    private readonly IAuthManager _authManager;


    public AccountController(UserManager<Users> userManager,
        ILogger<AccountController> logger,
        IAuthManager authManager,
        IMapper mapper)
    {
      _userManager = userManager;
      _authManager = authManager;
      _logger = logger;
      _mapper = mapper;
    }

    [HttpPost]
    [Route("register")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Register([FromBody] UserCreateDto userDto)
    {
      _logger.LogInformation($"Registro para {userDto.Email}");

      if (!ModelState.IsValid) return BadRequest(ModelState);

      try
      {
        var user = _mapper.Map<Users>(userDto);
        user.UserName = userDto.Email;
        var result = await _userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError(error.Code, error.Description);
          }
          return BadRequest(ModelState);
        }

        await _userManager.AddToRolesAsync(user, userDto.Roles);
        return Accepted();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(Register)}");
        return StatusCode(500, "Ocorreu um erro interno. Por favor tente mais tarde");
      }
    }


    [HttpPost]
    [Route("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
    {
      _logger.LogInformation($"Login para {userDto.Email}");

      if (!ModelState.IsValid) return BadRequest(ModelState);

      try
      {
        if (!await _authManager.ValidateUser(userDto)) return Unauthorized();

        return Accepted(new { Token = await _authManager.CreateToken() });
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, $"Ocorreu um erro em {nameof(Login)}");
        return StatusCode(500, "Ocorreu um erro interno. Por favor tente mais tarde");
      }
    }

  }
}