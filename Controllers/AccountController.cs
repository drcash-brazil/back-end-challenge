using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using back_end_challenge.Dtos;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace back_end_challenge.Controllers
{
  [Route("api/authors")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    // private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<Users> _userManager;
    private readonly ILogger<AccountController> _logger;
    private readonly IMapper _mapper;


    public AccountController(UserManager<Users> userManager,
        ILogger<AccountController> logger,
        IMapper mapper)
    {
      _userManager = userManager;
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


    // [HttpPost]
    // [Route("login")]
    // public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
    // {
    //   _logger.LogInformation($"Login para {userDto.Email}");

    //   if (!ModelState.IsValid) return BadRequest(ModelState);

    //   try
    //   {
    //     var result = await _sigInManager.PasswordSignInAsync(userDto.Email, userDto.Password, false, false);
    //     if (!result.Succeeded) return Unauthorized(userDto);
    //     return Accepted();
    //   }
    //   catch (Exception ex)
    //   {
    //     _logger.LogError(ex, $"Ocorreu um erro em {nameof(Login)}");
    //     return StatusCode(500, "Ocorreu um erro interno. Por favor tente mais tarde");
    //   }
    // }

  }
}