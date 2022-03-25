using System;
using System.Collections.Generic;
using BookStoreCrudWebApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using BookStoreCrudWebApi.Models.Dtos;
using BookStoreCrudWebApi.Models.Entidades;

namespace BookStoreCrudWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _repository;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){

            var livros = await _repository.ObterLivrosAsync();
            return livros.Any()
                        ? Ok(livros)
                        : NotFound("Nenhum Livro Encontrado");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLivroPeloId(string id)
        {
            var livro = await _repository.ObterLivroPeloIdAsync(id);
            
            var livroRetorno = _mapper.Map<LivroDetalhesDto>(livro);

            return livroRetorno != null
                        ? Ok(livroRetorno)
                        : NotFound("Este Livro não foi encontrado");
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarLivro([FromBody] LivroCadastrarDto livro, [FromQuery] List<string> autoresId, [FromQuery] List<string> generosId){

            if( livro == null)return BadRequest("Dados Inválidos");

            var livroAdicionar = _mapper.Map<Livro>(livro);

            var result = await  _repository.CadastrarLivroComAutorEGeneroExistente(livroAdicionar,autoresId,generosId);

             return result?
                 Ok("Livro Cadastrado com Sucesso")
              : BadRequest("Erro ao Cadastrar o Livro");
        }
        
        [HttpPost("/Cadastrar-livro-autores-generos")]
        public async Task<IActionResult> CadastrarLivroAutoresGeneros([FromBody] LivroAutorCadastrar obj){

            if( obj == null)return BadRequest("Dados Inválidos");
           
            var result = await  _repository.CadastrarLivroComAutorEGeneroEnexistente(obj);
            return result ? Ok("Livro Cadastrado com Sucesso")
                : BadRequest("Erro ao Cadastrar o Livro");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(string id, LivroAtualizarDto DadosAtualizar)
        {
            if( id == null) BadRequest("Livro não informado");

            var livro = await _repository.ObterLivroPeloIdAsync(id);
            
            var livroAtualizar = _mapper.Map(DadosAtualizar, livro);

            _repository.Atualizar(livroAtualizar);

            return await _repository.Salvar()
                        ? Ok("Livro Atualizado com sucesso")
                        : BadRequest("Este Livro não existe");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarLivro(string id)
        {
            if( id  == null) BadRequest("Livro Inválido");

            var livro = await _repository.ObterLivroPeloIdAsync(id);
            if (livro == null) return NotFound("Este identificador não Existe");

            _repository.Eliminar(livro);

            return await _repository.Salvar()
                        ? Ok("Livro Eminado com Sucesso")
                        : BadRequest("Este Livro não existe");
        }
    }
}