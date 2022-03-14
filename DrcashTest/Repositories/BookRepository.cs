using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.IRepository;
using DrcashTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DrcashTest.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IList<Books>> GetAll() => await _context.Books
            .AsNoTracking()
            .Include(a=>a.Authors)
            .Include(c=>c.Categories)
            .ToListAsync();

        public async Task<Books> GetById(int id) => await _context.Books
            .Include(a=>a.Authors)
            .Include(c=>c.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<Books> GetBookByName(string name) => await _context.Books
            .Include(a=>a.Authors)
            .Include(c=>c.Categories)
            .FirstOrDefaultAsync(x => x.Titulo.Contains(name));

        public async Task<Books> Insert(Books entity)
        {
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Books entity)
        {
            _context.Books.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Delete(int id, Books entity)
        {
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}