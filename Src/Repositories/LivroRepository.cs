using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BibliotecaDrCash.Repository{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IEnumerable<Livro>> FilterBy(Func<Livro, bool> predicate);
    }

    public class LivroRepository : BaseRepository, ILivroRepository
    {
        public LivroRepository(AppDbContext context,ILogger<BaseRepository> logger) : base(context,logger)
        {
        }

        public async Task<IEnumerable<Livro>> ListAsync()
        {
            return await _context.Set<Livro>().Include(x => x.Autores).Include(x => x.Generos).ToListAsync();
        }

        public async Task<Livro> GetAsync(Guid id)
        {
            return await _context.Set<Livro>().FindAsync(id);
        }

        public async Task UpdateAsync(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task AddAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await SaveAsync();
        }

        public async Task<Livro> RemoveAsync(Guid id)
        {
            Livro livro = await GetAsync(id);
            if (livro != null)
            {
                _context.Livros.Remove(livro);
                await SaveAsync();
            }
            return livro;
        }
        public async Task RemoveAsync(Livro livro)
        {
            _context.Livros.Remove(livro);
            await SaveAsync();
        }

        public async Task<IEnumerable<Livro>> FilterBy(Func<Livro, bool> predicate)
        {
             return _context.Set<Livro>().Include(x => x.Autores).Include(x => x.Generos).Where(predicate).ToList();
        }
    }
}