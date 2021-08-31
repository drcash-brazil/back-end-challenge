using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using BibliotecaDrCash.Filters;
using BibliotecaDrCash.Services;

namespace BibliotecaDrCash.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController: ControllerBase{
        private readonly IService<Genero> _service;
       
        public GenerosController(IService<Genero> service){ 
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDTO>>> GetGeneros(){
            
            var generos = await _service.ListAsync();
            var generosDTO = generos.Select(x=> new GeneroDTO(){Id = x.Id,Nome=x.Nome});

            return Ok(generosDTO);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Genero>))]
        public ActionResult<GeneroDTO> GetGenero(Guid id){
            
            Genero genero = HttpContext.Items["entity"] as Genero;
            return Ok(new GeneroDTO(){Id = genero.Id,Nome=genero.Nome});
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Genero>))]
        public async Task<IActionResult> PutGenero(Guid id,string genero){
            
            Genero _genero = HttpContext.Items["entity"] as Genero;
            
            _genero.Nome = genero;

            await _service.UpdateAsync(_genero);

            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<GeneroDTO>> PostGenero(string genero){
            
            Genero _genero = new(){Nome = genero};
           
            await _service.AddAsync(_genero);

            return CreatedAtAction("GetGenero",new {id = _genero.Id},new GeneroDTO(){Id =_genero.Id,Nome = _genero.Nome } );
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Genero>))]
        public async Task<IActionResult> DeleteGenero(Guid id){
            
            await _service.DeleteAsync(id);

            return NoContent();
        }

    }
}