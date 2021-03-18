using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Interfaces;
using System;
using System.Threading.Tasks;

namespace DrCash.Teste.Application.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository,
                              INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
        }

        public async Task Adicionar(Livro livro)
        {
            await _livroRepository.Adicionar(livro);
        }

        public async Task Atualizar(Livro livro)
        {
            await _livroRepository.Atualizar(livro);
        }

        public async Task Remover(Guid id)
        {
            await _livroRepository.Remover(id);
        }

        public void Dispose()
        {
            _livroRepository?.Dispose();
        }
    }
}
