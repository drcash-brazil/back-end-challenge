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
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio _repository;
        private readonly IMapper _mapper;

        public AutorController(IAutorRepositorio repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/Listar-Todos-Autores")]
        public async Task<IActionResult> Get(){

            var autores = await _repository.ObterAutoresAsync();
            return autores.Any()
                        ? Ok(autores)
                        : BadRequest("Nenhum Autor encontrado");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterAutorPeloId(string id)
        {
            var autor = await _repository.ObterAutorPeloIdAsync(id);
            
            var autorRetorno = _mapper.Map<AutorDetalhesDto>(autor);

            return autorRetorno != null
                        ? Ok(autorRetorno)
                        : BadRequest("Este Autor não existe");
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAutor(AutorCadastrarDto autor){

            if( autor == null)return BadRequest("Dados Inválidos");

            var autorAdicionar = _mapper.Map<Autor>(autor);

            _repository.Adicionar(autorAdicionar);

            return await _repository.Salvar()
                    ? Ok("Autor Cadastrado com Sucesso")
                    : BadRequest("Erro ao Cadastrar Autor");
        }
    }
}