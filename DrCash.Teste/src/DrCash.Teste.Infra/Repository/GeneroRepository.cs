using DrCash.Teste.Domain.Entities;
using DrCash.Teste.Infra.Context;
using DrCash.Teste.Infra.Interfaces;

namespace DrCash.Teste.Infra.Repository
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        public GeneroRepository(MeuDbContext context) : base(context) { }
    }
}