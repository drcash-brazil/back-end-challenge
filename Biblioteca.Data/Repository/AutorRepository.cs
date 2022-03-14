using Biblioteca.Data.Context;
using Biblioteca.Data.IRepository;
using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data.Repository
{
    public class AutorRepository: IAutorRepository
    {
        private readonly BibliotecaContext _context;
        protected DbSet<Autor> _dbSet;

        public AutorRepository(BibliotecaContext context)
        {
            _context = context;
            _dbSet = _context.Set<Autor>();
        }

        public async Task<bool> Adicionar(Autor objeto)
        {
            try
            {
                await _dbSet.AddAsync(objeto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Atualizar(Autor objeto)
        {
            try
            {
                _dbSet.Update(objeto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Autor> BuscarPorId(Guid id)
        {
            var consulta = _dbSet.Where(c => c.AutorId == id);

            var resultado = await consulta.FirstOrDefaultAsync();

            return resultado;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Autor>> Encontrar(Expression<Func<Autor, bool>> expressao, int quantidade = 100)
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Where(expressao)
                                 .Take(quantidade);

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<List<Autor>> Listar()
        {
            var consulta = _dbSet.AsNoTracking();

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<bool> Remover(Autor objeto)
        {
            try
            {
                _dbSet.Remove(objeto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
