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
    public class GeneroRepositorio : BaseRepositorio, IGeneroRepositorio
    {
        private readonly BookStoreContext _contexto;

        public GeneroRepositorio(BookStoreContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<GeneroDto>> ObterGenerosAsync()
        {
            return await _contexto.generos.Select(x => new GeneroDto {
                id = x.Id,
                genero = x.genero
            }).ToListAsync();
        }

        public async Task<Genero> ObterGeneroPeloIdAsync(string id)
        {
            return await _contexto.generos.Where(x=>x.Id == id).FirstOrDefaultAsync();
        }
    }
}