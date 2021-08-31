using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BibliotecaDrCash.Repository{
    public interface IGeneroRepository:IRepository<Genero>
    {

    }

    public class GeneroRepository : BaseRepository, IGeneroRepository
    {
        public GeneroRepository(AppDbContext context,ILogger<BaseRepository> logger) : base(context,logger)
        {
        }

        public async Task<IEnumerable<Genero>> ListAsync()
        {
            return await _context.Set<Genero>().ToListAsync();
        }

        public async Task<Genero> GetAsync(Guid id)
        {
            return await _context.Set<Genero>().FindAsync(id);
        }

        public async Task UpdateAsync(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task AddAsync(Genero genero)
        {
            _context.Generos.Add(genero);
            await SaveAsync();
        }

        public async Task<Genero> RemoveAsync(Guid id)
        {
            Genero genero = await GetAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
               await SaveAsync();
            }
            return genero;
        }
        public async Task RemoveAsync(Genero genero)
        {
            _context.Generos.Remove(genero);
            await SaveAsync();
        }
    }
}