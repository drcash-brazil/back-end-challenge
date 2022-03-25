using System;
using System.Collections.Generic;
using BookStoreCrudWebApi.Models.Entidades;
using BookStoreCrudWebApi.Repository.Interfaces;
using System.Threading.Tasks;

using BookStoreCrudWebApi.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookStoreCrudWebApi.Models.Dtos;

namespace BookStoreCrudWebApi.Repository
{
    public class AutorRepositorio : BaseRepositorio, IAutorRepositorio
    {
        private readonly BookStoreContext _contexto;
        public AutorRepositorio(BookStoreContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<AutorDto>> ObterAutoresAsync()
        {
            return await _contexto.autores.Select(x => new AutorDto{
                Id = x.Id,
                NomeAutor = x.NomeAutor
            }).ToListAsync();
        }

        public async Task<Autor> ObterAutorPeloIdAsync(string id)
        {
            return await _contexto.autores.Include(x => x.LivroAutores).ThenInclude(x=>x.Livro).Where(x=>x.Id == id).FirstOrDefaultAsync();

        }
    }
}