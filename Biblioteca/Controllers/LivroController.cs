using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Livro;
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
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] AdicionarLivroDTO objetoEntrada)
        {
            if (objetoEntrada.AutorId == Guid.Empty)
                ModelState.AddModelError("AutorId", "AutorId is required");

            if (objetoEntrada.GeneroId == Guid.Empty)
                ModelState.AddModelError("GeneroId", "GeneroId is required");

            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<LivroDTO>(false, mensagem, null));
            }

            var resultado = await _livroService.Adicionar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.LivroId });

                return Created(url, resultado);
            }

            return StatusCode(500, resultado);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromForm] AtualizarLivroDTO objetoEntrada)
        {
            if (objetoEntrada.LivroId == Guid.Empty)
                ModelState.AddModelError("LivroId", "Livroid is required");

            if (objetoEntrada.AutorId == Guid.Empty)
                ModelState.AddModelError("AutorId", "AutorId is required");

            if (objetoEntrada.GeneroId == Guid.Empty)
                ModelState.AddModelError("GeneroId", "GeneroId is required");

            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<LivroDTO>(false, mensagem, null));
            }

            var resultado = await _livroService.Atualizar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.LivroId });

                return Ok(resultado);
            }

            return StatusCode(500, resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id)
        {
            var resultado = await _livroService.BuscarPorId(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return NotFound(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _livroService.Listar();

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var resultado = await _livroService.Remover(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }
    }
}