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
    public class LivroRepositorio : BaseRepositorio, ILivroRepositorio
    {
        private readonly BookStoreContext _contexto;
        private readonly IAutoresLivrosRepositorio _autoresLivrosRepositorio;
        private readonly IAutorRepositorio _autorRepositorio;
        private readonly IGeneroRepositorio _generoRepositorio;

        public LivroRepositorio(BookStoreContext contexto, IAutoresLivrosRepositorio autoresLivrosRepositorio, IGeneroRepositorio generoRepositorio,IAutorRepositorio autorRepositorio) : base(contexto)
        {
            _contexto = contexto;
            _autorRepositorio = autorRepositorio;
            _generoRepositorio = generoRepositorio;
            _autoresLivrosRepositorio = autoresLivrosRepositorio;
        }
        public async Task<List<Livro>> ObterLivrosAsync()
        {
            return await _contexto.livros
                .Include(a => a.LivroAutores)
                .ThenInclude(x=>x.Autor)
                .Include(g=>g.GeneroLivro)
                .ThenInclude(x=>x.Genero).ToListAsync();
        }
        public async Task<bool> CadastrarLivroComAutorEGeneroExistente(Livro obj, List<string> autores, List<string> generos)
        {
            var dadosLivro = IncluirDadosLivroPorId(obj, autores, generos);
            Adicionar(dadosLivro);
            return  await  Salvar();
        }
        public async Task<bool> CadastrarLivroComAutorEGeneroEnexistente(LivroAutorCadastrar obj)
        {
             var dadosLivro = IncluirDadosLivro(obj);
             Adicionar(dadosLivro);
             return await  Salvar();
        }

        public async Task<Livro> ObterLivroPeloIdAsync(string id)
        {
            return await _contexto.livros.Include(x => x.LivroAutores).ThenInclude(x=>x.Autor).Include(x=>x.GeneroLivro).ThenInclude(x=>x.Genero).AsNoTracking().Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        #region Auxiliar
        public Livro IncluirDadosLivro(LivroAutorCadastrar obj)
        {
            var livroAutores = new List<LivroAutores>();
            var generoLivros = new List<GeneroLivro>();
            var autores = _autorRepositorio.ObterAutoresAsync().Result;
            var generos = _generoRepositorio.ObterGenerosAsync().Result;
            foreach (var aut in obj.Autores)
            {
                var autor = autores.FirstOrDefault(x => x.NomeAutor == aut.NomeAutor);
                if(autor == null)
                  livroAutores.Add(new LivroAutores{ Autor = new Autor{NomeAutor = aut.NomeAutor}});
                else
                {
                    livroAutores.Add(new LivroAutores{ autorId = autor.Id}); 
                }
            }
            foreach (var gen in obj.Genero)
            {
                var genero = generos.FirstOrDefault(x => x.genero == gen.genero);
                if(genero == null)
                    generoLivros.Add(new GeneroLivro{ Genero = new Genero{genero = gen.genero}});
                else
                {
                    generoLivros.Add(new GeneroLivro{ generoId = genero.id});
                }
                
            }

            return new Livro
            {
                Titulo = obj.Titulo,
                QuantidadeCopias = obj.QuantidadeCopias,
                LivroAutores = livroAutores,
                GeneroLivro = generoLivros
            };
        }
        public Livro IncluirDadosLivroPorId(Livro obj, List<string> autores, List<string> generos)
        {
            var idLivro = Guid.NewGuid().ToString();
            var livroAutores = new List<LivroAutores>();
            var generoLivros = new List<GeneroLivro>();
           
            foreach (var autorId in autores)
            {
                livroAutores.Add( new  LivroAutores{
                    autorId = autorId,
                    livroId = idLivro
                });
            }
            foreach (var generoId in generos)
            {
                generoLivros.Add( new  GeneroLivro
                {
                    generoId = generoId,
                    livroId = idLivro
                });  
            }

            return new Livro
            {
                Id = idLivro,
                Titulo = obj.Titulo,
                QuantidadeCopias = obj.QuantidadeCopias,
                LivroAutores = livroAutores,
                GeneroLivro = generoLivros
            };
        }
        #endregion
    }
}