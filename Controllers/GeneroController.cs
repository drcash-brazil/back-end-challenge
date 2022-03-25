using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookStoreCrudWebApi.Models.Entidades;
using BookStoreCrudWebApi.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using BookStoreCrudWebApi.Models.Dtos;
using AutoMapper;

namespace BookStoreCrudWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
      private readonly IGeneroRepositorio _repositorio;
        private readonly IMapper _mapeador;

        public GeneroController(IGeneroRepositorio repositorio, IMapper mapeador)
        {
            _repositorio = repositorio;
            _mapeador = mapeador;
        }

        [HttpGet("/Listar-Todos-Generos")]
        public async Task<IActionResult> Get(){

            var generos = await _repositorio.ObterGenerosAsync();
            return generos.Any()
                        ? Ok(generos)
                        : NotFound("Não encontrado nenhum genero");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterGeneroPeloId(string id)
        {
            var genero = await _repositorio.ObterGeneroPeloIdAsync(id);
            
            var generoRetorno = _mapeador.Map<GeneroDto>(genero);

            return generoRetorno != null
                        ? Ok(generoRetorno)
                        : NotFound("Este Genero não foi encontrado");
        }
        [HttpPost("/Cadastrar-Genero")]
        public async Task<IActionResult> CadastrarGenero(GeneroCadastrarDto genero){

            if( genero == null)return BadRequest("Dados Inválidos");

            var generoAdicionar = _mapeador.Map<Genero>(genero);

            _repositorio.Adicionar(generoAdicionar);

            return await _repositorio.Salvar()
                    ? Ok("Genero Cadastrado com Sucesso")
                    : BadRequest("Erro ao Cadastrar o Genero");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarGenero(string id, GeneroAtualizarDto GeneroAtualizar)
        {
            if( id == null) BadRequest("Livro não informado");

            var genero = await _repositorio.ObterGeneroPeloIdAsync(id);
            
            var generoAtualizar = _mapeador.Map(GeneroAtualizar, genero);
            _repositorio.Atualizar(generoAtualizar);

            return await _repositorio.Salvar()
                        ? Ok("Genero Atualizado com sucesso")
                        : BadRequest("Erro ao Atualizar o genero");
        }  
    }
}