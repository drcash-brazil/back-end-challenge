using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Repository.Interfaces
{
    public interface IAutorRepositorio : IBaseRepositorio
    {
         Task<IEnumerable<AutorDto>> ObterAutoresAsync();
         Task<Autor> ObterAutorPeloIdAsync(string id);
    }
}