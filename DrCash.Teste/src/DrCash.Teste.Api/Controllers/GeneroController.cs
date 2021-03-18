using AutoMapper;
using DrCash.Teste.Api.ViewModel;
using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrCash.Teste.Api.Controllers
{
    [Route("api/generos")]
    public class GeneroController : MainController
    {
        private readonly IGeneroService _generoService;
        private readonly IMapper _mapper;

        public GeneroController(IMapper mapper,
                               IGeneroService generoService,
                               INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _generoService = generoService;
        }

        [HttpPost]
        public async Task<ActionResult<GeneroViewModel>> Adicionar(GeneroViewModel generoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _generoService.Adicionar(_mapper.Map<Genero>(generoViewModel));

            return CustomResponse(generoViewModel);
        }

    }
}
