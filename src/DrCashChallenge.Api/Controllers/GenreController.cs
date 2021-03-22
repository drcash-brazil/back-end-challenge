using AutoMapper;
using DrCashChallenge.Api.ViewModels;
using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrCashChallenge.Api.Controllers
{
    [Route("api/genres")]
    public class GenreController : BaseController
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper,
                               IGenreService genreService,
                               INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<ActionResult<GenreViewModel>> Create(GenreViewModel genreViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _genreService.Create(_mapper.Map<Genre>(genreViewModel));

            return CustomResponse(genreViewModel);
        }

    }
}
