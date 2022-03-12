using DrcashTest.Data;
using DrcashTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DrcashTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookContext _BookContext;

        public BookController(BookContext context)
        {
            _BookContext = context;
        }
        private static readonly Expression<Func<Book,BookDetailDto>> AsBookDto =
            x => new BookDetailDto
            {
                BookId = x.BookId,
                Title = x.Title,
                Author = x.Author.name,
                NumberCopies = x.NumberCopies,
                AuthorId = x.AuthorId,
                GenreId = x.GenreId,
                Genre = x.Genre.name
            };
        [HttpGet]
        public IQueryable<BookDetailDto> Get()
        {
            try
            {
                return  _BookContext.Books.Include(b => b.Author).Select(AsBookDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpGet("{BookId}")]
        public async Task<ActionResult<IEnumerable<Book>>> Get(Guid BookId)
        {
            try
            {
                var book = await (from x in _BookContext.Books.Include(b => b.Author)
                                  where x.BookId == BookId
                                  select new BookDetailDto
                                  {
                                      BookId=x.BookId,
                                      Title = x.Title,
                                      Author = x.Author.name,
                                      NumberCopies = x.NumberCopies,
                                      AuthorId = x.AuthorId,
                                      GenreId = x.GenreId,
                                      Genre = x.Genre.name
                                  }).FirstOrDefaultAsync();

                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            try
            {
                var data = _BookContext.Books.Add(book);
                await _BookContext.SaveChangesAsync();
                return data.Entity;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Book book)
        {
            try
            {
                _BookContext.Entry(book).State = EntityState.Modified;
                await _BookContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{BookId}")]
        public async Task<ActionResult> Delete(Guid BookId)
        {
            try
            {
                var data = await _BookContext.Books.FindAsync(BookId);

                if (data == null)
                    return NotFound();

                _BookContext.Books.Remove(data);
                await _BookContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            return NoContent();
        }
    }
}