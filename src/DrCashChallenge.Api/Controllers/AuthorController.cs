using AutoMapper;
using DrCashChallenge.Api.ViewModels;
using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrCashChallenge.Api.Controllers
{
    [Route("api/authors")]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IMapper mapper,
                               IAuthorService authorService,
                               INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorViewModel>> Create(AuthorViewModel autorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _authorService.Create(_mapper.Map<Author>(autorViewModel));

            return CustomResponse(autorViewModel);
        }
    }
}
