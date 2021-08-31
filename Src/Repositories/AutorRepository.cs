using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BibliotecaDrCash.Repository{

    public interface IAutorRepository:IRepository<Autor>
    {
       
    }

    public class AutorRepository : BaseRepository, IAutorRepository
    {
        public AutorRepository(AppDbContext context,ILogger<BaseRepository> logger) : base(context,logger)
        {
        }

        public async Task<IEnumerable<Autor>> ListAsync()
        {
            return await _context.Set<Autor>().ToListAsync();
        }

        public async Task<Autor> GetAsync(Guid id)
        {
            return await _context.Set<Autor>().FindAsync(id);
        }

        public async Task UpdateAsync(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task AddAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await SaveAsync();
        }

        public async Task<Autor> RemoveAsync(Guid id)
        {
            Autor autor = await GetAsync(id);

            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await SaveAsync();
            }

            return autor;
        }
        public async Task RemoveAsync(Autor autor)
        {
            _context.Autores.Remove(autor);
            await SaveAsync();
        }
    }
}