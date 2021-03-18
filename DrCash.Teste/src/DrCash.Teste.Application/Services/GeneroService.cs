using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Interfaces;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Services
{
    public class GeneroService : BaseService, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository autorRepository,
                              INotificador notificador) : base(notificador)
        {
            _generoRepository = autorRepository;
        }

        public async Task Adicionar(Genero genero)
        {
            await _generoRepository.Adicionar(genero);
        }
        public void Dispose()
        {
            _generoRepository?.Dispose();
        }
    }
}
