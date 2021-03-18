using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Context;
using DrCash.Teste.Infra.Interfaces;

namespace DrCash.Teste.Infra.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(MeuDbContext context) : base(context) { }
    }
}
