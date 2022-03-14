using System.Collections.Generic;
using System.Threading.Tasks;
using DrcashTest.IRepository;
using DrcashTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DrcashTest.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly DataContext _context;

        public GeneroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IList<Genero>> GetAll() =>
            await _context.Genero.AsNoTracking().ToListAsync();

        public async Task<Genero> GetById(int id) =>
            await _context.Genero.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Genero> Insert(Genero entity)
        {
            _context.Genero.Add (entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Update(Genero entity)
        {
            _context.Genero.Update (entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id, Genero entity)
        {
            _context.Genero.Remove (entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
