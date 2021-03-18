using AutoMapper;
using DrCash.Teste.Api.ViewModel;
using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DrCash.Teste.Api.Controllers
{
    [Route("api/autores")]
    public class AutorController : MainController
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutorController(IMapper mapper,
                               IAutorService autorService,
                               INotificador notificador) : base(notificador)
        {
            _mapper = mapper;
            _autorService = autorService;
        }

        [HttpPost]
        public async Task<ActionResult<AutorViewModel>> Adicionar(AutorViewModel autorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _autorService.Adicionar(_mapper.Map<Autor>(autorViewModel));

            return CustomResponse(autorViewModel);
        }

    }
}
