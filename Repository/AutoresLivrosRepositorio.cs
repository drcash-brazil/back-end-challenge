using BookStoreCrudWebApi.Context;
using BookStoreCrudWebApi.Repository.Interfaces;

namespace BookStoreCrudWebApi.Repository
{
    public class AutoresLivrosRepositorio : BaseRepositorio, IAutoresLivrosRepositorio
    {
        private readonly BookStoreContext _contexto;

        public AutoresLivrosRepositorio(BookStoreContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}