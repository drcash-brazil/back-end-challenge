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
    public class GeneroRepository:  IGeneroRepository
    {
        private readonly BibliotecaContext _context;
        protected DbSet<Genero> _dbSet;

        public GeneroRepository(BibliotecaContext context)
        {
            _context = context;
            _dbSet = _context.Set<Genero>();
        }

        public async Task<bool> Adicionar(Genero objeto)
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

        public async Task<bool> Atualizar(Genero objeto)
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

        public async Task<Genero> BuscarPorId(Guid id)
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Where(l => l.GeneroId == id);

            var resultado = await consulta.FirstOrDefaultAsync();

            return resultado;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Genero>> Encontrar(Expression<Func<Genero, bool>> expressao, int quantidade = 100)
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Where(expressao)
                                 .Take(quantidade);

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<List<Genero>> Listar()
        {
            var consulta = _dbSet.AsNoTracking();

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<bool> Remover(Genero objeto)
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