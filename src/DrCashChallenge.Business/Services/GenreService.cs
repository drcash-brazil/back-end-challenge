using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Services
{
    public class GenreService : BaseService, IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository,
                              INotificator notificator) : base(notificator)
        {
            _genreRepository = genreRepository;
        }

        public async Task Create(Genre genre)
        {
            await _genreRepository.Create(genre);
        }
        public void Dispose()
        {
            _genreRepository?.Dispose();
        }
    }
}