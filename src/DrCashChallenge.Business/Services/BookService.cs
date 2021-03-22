using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Models;
using System;
using System.Threading.Tasks;

namespace DrCashChallenge.Business.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository,
                              INotificator notificator) : base(notificator)
        {
            _bookRepository = bookRepository;
        }

        public async Task Create(Book book)
        {
            await _bookRepository.Create(book);
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }

        public async Task Remove(Guid id)
        {
            await _bookRepository.Remove(id);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
