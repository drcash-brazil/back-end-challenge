using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Interfaces;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Services
{
    public class AutorService : BaseService, IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository,
                              INotificador notificador) : base(notificador)
        {
            _autorRepository = autorRepository;
        }

        public async Task Adicionar(Autor autor)
        {
            await _autorRepository.Adicionar(autor);
        }
        public void Dispose()
        {
            _autorRepository?.Dispose();
        }
    }
}
