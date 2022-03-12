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
    public class GenreController : ControllerBase
    {
        private BookContext _BookContext;

        public GenreController(BookContext context)
        {
            _BookContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> Get()
        {
            try
            {
                return await _BookContext.Genres.ToListAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            } 
        }
        [HttpGet("{GenreId}")]
        public async Task<ActionResult<IEnumerable<Genre>>> Get(Guid GenreId)
        {
            try
            {
                var data = await _BookContext.Genres
                .Where(b => b.GenreId == GenreId)
                .ToListAsync();
                return data;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<ActionResult<Genre>> Post([FromBody] Genre genre)
        {
            try
            {
                var data = _BookContext.Genres.Add(genre);
                await _BookContext.SaveChangesAsync();
                return data.Entity;
            }
            catch (DbUpdateException)
            {

                throw;
            }
        }
        [HttpPut]
        public async Task<ActionResult> Put(Genre genre)
        {
            try
            {
                _BookContext.Entry(genre).State = EntityState.Modified;
                await _BookContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{GenreId}")]
        public async Task<ActionResult> Delete(Guid GenreId)
        {
            try
            {
                var data = await _BookContext.Genres.FindAsync(GenreId);

                if (data == null)
                    return NotFound();

                _BookContext.Genres.Remove(data);
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
