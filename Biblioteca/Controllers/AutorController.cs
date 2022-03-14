using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Autor;
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
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromForm] AdicionarAutorDTO objetoEntrada)
        {
            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<AutorDTO>(false, mensagem, null));
            }

            var resultado = await _autorService.Adicionar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.AutorId });

                return Created(url, resultado);
            }

            return StatusCode(500, resultado);
        }       

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromForm] AtualizarAutorDTO objetoEntrada)
        {
            if (objetoEntrada.AutorId == Guid.Empty)
                ModelState.AddModelError("AutorId", "Autorid is required");

            if (!ModelState.IsValid)
            {
                var mensagem = ModelStateUtils.ObterMensagemDeErrosPorModelState(ModelState);

                return BadRequest(new ResultadoDTO<AutorDTO>(false, mensagem, null));
            }

            var resultado = await _autorService.Atualizar(objetoEntrada);

            if (resultado.Sucesso)
            {
                var url = Url.Action(nameof(BuscarPorId), new { id = resultado.Saida.AutorId });

                return Ok(resultado);
            }

            return StatusCode(500, resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(Guid id) 
        {
            var resultado = await _autorService.BuscarPorId(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return NotFound(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _autorService.Listar();

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var resultado = await _autorService.Remover(id);

            if (resultado.Sucesso)
                return Ok(resultado);

            return BadRequest(resultado);
        }
    }
}