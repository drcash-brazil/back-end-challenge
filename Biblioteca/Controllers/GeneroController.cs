using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Genero;
using Biblioteca.Service.IService;
using Biblioteca.Service.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GeneroController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] AdicionarGeneroDTO objetoEntrada)
        {
            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<GeneroDTO>(false, mensagem, null));
            }

            var resultado = await _generoService.Adicionar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.GeneroId });

                return Created(url, resultado);
            }

            return StatusCode(500, resultado);
        }       

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromForm] AtualizarGeneroDTO objetoEntrada)
        {
            if (objetoEntrada.GeneroId == Guid.Empty)
                ModelState.AddModelError("GeneroId", "Generoid is required");

            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<GeneroDTO>(false, mensagem, null));
            }

            var resultado = await _generoService.Atualizar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.GeneroId });

                return Ok(resultado);
            }

            return StatusCode(500, resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id) 
        {
            var resultado = await _generoService.BuscarPorId(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return NotFound(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _generoService.Listar();

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var resultado = await _generoService.Remover(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return StatusCode(500, resultado);
        }
    }
}