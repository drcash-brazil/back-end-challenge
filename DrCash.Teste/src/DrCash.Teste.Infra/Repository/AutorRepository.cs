using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Context;
using DrCash.Teste.Infra.Interfaces;

namespace DrCash.Teste.Infra.Repository
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(MeuDbContext context) : base(context) { }
    }
}