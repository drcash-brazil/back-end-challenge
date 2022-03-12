using DrcashTest.Data;
using DrcashTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrcashTest.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private BookContext _BookContext;

        public  AuthorController (BookContext context)
        {
            _BookContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            try
            {
                return await _BookContext.Authors.ToListAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpGet("{AuthorId}")]
        public async Task<ActionResult<IEnumerable<Author>>> Get(Guid AuthorId)
        {
            try
            {
                var data = await _BookContext.Authors
                .Where(b => b.AuthorId == AuthorId)
                .ToListAsync();
                return data;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Author>> Post([FromBody] Author author)
        {
            try
            {
                var data = _BookContext.Authors.Add(author);
                await _BookContext.SaveChangesAsync();
                return data.Entity;
            }
            catch (DbUpdateException)
            {
               
                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Author author)
        {
            try
            {
                _BookContext.Entry(author).State = EntityState.Modified;
                await _BookContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
        [HttpDelete("{authorId}")]
        public async Task<ActionResult> Delete(Guid authorId)
        {
            try
            {
                var data = await _BookContext.Authors.FindAsync(authorId);

                if (data == null)
                    return NotFound();

                _BookContext.Authors.Remove(data);
                await _BookContext.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
    }
}