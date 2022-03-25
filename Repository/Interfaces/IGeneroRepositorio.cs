using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Repository.Interfaces
{
    public interface IGeneroRepositorio:IBaseRepositorio 
    {
        Task<IEnumerable<GeneroDto>> ObterGenerosAsync();
        Task<Genero> ObterGeneroPeloIdAsync(string id);
    }
}