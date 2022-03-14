using System.Collections.Generic;
using System.Threading.Tasks;
using back_end_challenge.IRepository;
using back_end_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace DrcashTest.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<IList<Category>> GetAll() => await _context.Category.AsNoTracking().ToListAsync();

        public async Task<Category> GetById(int id) => await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
        
        public async Task<Category> Insert(Category entity)
        {
            _context.Category.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Category entity)
        {
            _context.Category.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Delete(int id, Category entity)
        {
            _context.Category.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}