using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Repository.Interfaces
{
    public interface ILivroRepositorio : IBaseRepositorio
    {
         Task<List<Livro>> ObterLivrosAsync();
         Task<Livro> ObterLivroPeloIdAsync(string id);
         Task<bool> CadastrarLivroComAutorEGeneroEnexistente(LivroAutorCadastrar obj);
         Task<bool> CadastrarLivroComAutorEGeneroExistente(Livro obj, List<string> autores, List<string> generos);
         
    }
}