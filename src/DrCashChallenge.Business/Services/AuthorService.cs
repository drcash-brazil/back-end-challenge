using System;
using System.Threading.Tasks;
using System.Linq;
using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;

namespace DrCashChallenge.Business.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository,
                              INotificator notificator) : base(notificator)
        {
            _authorRepository = authorRepository;
        }

        public async Task Create(Author author)
        {
            author.Id = Guid.Empty;
            var exists = await _authorRepository.Get(a => a.Name.Equals(author.Name));
            var authorDb = exists.FirstOrDefault(a => a.Name == author.Name);
            if (authorDb == null)
                await _authorRepository.Create(author);
            else Notificate("Author Already Exists");
        }
        public void Dispose()
        {
            _authorRepository?.Dispose();
        }
    }
}
