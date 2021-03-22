using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _authorRepository.Create(author);
        }
        public void Dispose()
        {
            _authorRepository?.Dispose();
        }
    }
}
