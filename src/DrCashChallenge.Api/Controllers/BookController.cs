using AutoMapper;
using DrCashChallenge.Api.ViewModels;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrCashChallenge.Api.Controllers
{
    [Route("api/books")]
    public class BookController : BaseController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository,
                                      IMapper mapper,
                                      IBookService bookService,
                                      INotificator notificador) : base(notificador)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> GetById(Guid id)
        {
            var book = await GetBook(id);

            if (book == null) return NotFound();

            return book;
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<BookViewModel>> Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _bookService.Create(_mapper.Map<Book>(bookViewModel));

            return CustomResponse(bookViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> Update(Guid id, BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id)
            {
                NotificateError("The id not match");
                return CustomResponse(bookViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _bookService.Update(_mapper.Map<Book>(bookViewModel));

            return CustomResponse(bookViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BookViewModel>> Delete(Guid id)
        {
            var bookViewModel = await GetBook(id);

            if (bookViewModel == null) return NotFound();

            await _bookService.Remove(id);

            return CustomResponse(bookViewModel);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<BookViewModel> GetBook(Guid id)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetById(id));
        }
    }
}
