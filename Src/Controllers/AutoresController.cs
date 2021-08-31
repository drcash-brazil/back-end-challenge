using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BibliotecaDrCash.Filters;
using Microsoft.Extensions.Logging;
using BibliotecaDrCash.Services;

namespace BibliotecaDrCash.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController: ControllerBase{
        private readonly IService<Autor> _service;
        

        public AutoresController(IService<Autor> service) {
             _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> GetAutores(){
           
            var autores = await _service.ListAsync();
            var autoresDTO = autores.Select(x => new AutorDTO(){Id = x.Id,Nome = x.Nome});

            return Ok(autoresDTO);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Autor>))]
        public ActionResult<AutorDTO> GetAutor(Guid id){
           
            Autor autor = HttpContext.Items["entity"] as Autor;
            
            return Ok(new AutorDTO(){Id = autor.Id,Nome = autor.Nome});
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Autor>))]
        public async Task<IActionResult> PutAutor(Guid id,string autor){
                       
            Autor _autor = HttpContext.Items["entity"] as Autor;

            _autor.Nome = autor;
            await _service.UpdateAsync(_autor);

            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<AutorDTO>> PostAutor(string autor){
           
            Autor _autor = new(){Nome = autor};

            await _service.AddAsync(_autor);

            return CreatedAtAction("GetAutor",new {id = _autor.Id},new AutorDTO(){Id = _autor.Id,Nome = _autor.Nome});
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Autor>))]
        public async Task<IActionResult> DeleteAutor(Guid id){
            
            await _service.DeleteAsync(id);

            return NoContent();
        }

    }
}