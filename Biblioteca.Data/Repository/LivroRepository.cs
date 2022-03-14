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
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _context;
        protected DbSet<Livro> _dbSet;

        public LivroRepository(BibliotecaContext context)
        {
            _context = context;
            _dbSet = _context.Set<Livro>();
        }

        public async Task<bool> Adicionar(Livro objeto)
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

        public async Task<bool> Atualizar(Livro objeto)
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

        public async Task<Livro> BuscarPorId(Guid id)
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Include(l => l.Autor)
                                 .Include(l => l.Genero)
                                 .Where(l => l.LivroId == id);

            var resultado = await consulta.FirstOrDefaultAsync();

            return resultado;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Livro>> Encontrar(Expression<Func<Livro, bool>> expressao, int quantidade = 100)
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Include(c => c.Autor)
                                 .Include(c => c.Genero)
                                 .Where(expressao)
                                 .Take(quantidade);

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<List<Livro>> Listar()
        {
            var consulta = _dbSet.AsNoTracking()
                                 .Include(l => l.Autor)
                                 .Include(l => l.Genero);

            var resultado = await consulta.ToListAsync();

            return resultado;
        }

        public async Task<bool> Remover(Livro objeto)
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