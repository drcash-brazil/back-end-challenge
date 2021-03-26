using System;
using System.Threading.Tasks;
using System.Linq;
using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;

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
            genre.Id = Guid.Empty;
            var exists = await _genreRepository.Get(g => g.Name.Equals(genre.Name));
            var genreDb = exists.FirstOrDefault(g => g.Name == genre.Name);
            if (genreDb == null)
                await _genreRepository.Create(genre);
            else Notificate("Genre Already Exists");
        }
        public void Dispose()
        {
            _genreRepository?.Dispose();
        }
    }
}