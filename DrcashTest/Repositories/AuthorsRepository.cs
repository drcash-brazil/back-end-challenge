using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.IRepository;
using DrcashTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DrcashTest.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DataContext _context;

        public AuthorsRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IList<Authors>> GetAll() => await _context.Authors.AsNoTracking().ToListAsync();

        public async Task<Authors> GetById(int id) => await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
       
        public async Task<Authors> GetByAuthorWithBooks(int id) => 
            await _context.Authors.Include(b => b.Books)
                .ThenInclude(b=>b.Categories)
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Authors> GetByName(string name) =>
            await _context.Authors.FirstOrDefaultAsync(x => x.nome.Contains(name));

        public async Task<Authors> Insert(Authors entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Authors entity)
        {
            _context.Authors.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Delete(int id, Authors entity)
        {
            _context.Authors.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}