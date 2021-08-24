using System.Threading.Tasks;
using BackEnd.Interface;
using BackEnd.Models;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackEnd.Controllers
{
            [ApiController]
            [Route("[controller]")]
            public class UserController : ControllerBase
            {
                        private readonly IUserRepository _user;
                        private readonly ITokenService _tokenService;
                        private readonly ILogger<UserController> _logger;
                        public UserController(ILogger<UserController> logger, IUserRepository user,ITokenService tokenService)
                        {
                                    _user = user;
                                    _logger = logger;
                                    _tokenService=tokenService;
                        }
                        [HttpPost]
                        [Route("authenticate")]
                        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Users model)
                        {
                                 var user = await _user.getUser(model.username, model.password);
                                 if (user == null)
                                             return NotFound(new { message = "Usuário ou senha inválidos" });
                                 var token = _tokenService.GenerateToken(user);
                                 return new
                                 {
                                             user = user,
                                             token = token
                                 };
                        }
                        [HttpPost]
                        [Route("add")]
                        public async Task<Response> add([FromBody] Users model)
                        {
                            //model.password=
                            return await _user.add(model);
   
                        }

            }
}