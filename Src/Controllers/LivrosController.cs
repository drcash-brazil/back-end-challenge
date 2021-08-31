using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using BibliotecaDrCash.Filters;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using BibliotecaDrCash.Services;

namespace BibliotecaDrCash.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController: ControllerBase{
        private readonly ILivroService _serviceLivro;
        private readonly IService<Genero> _serviceGenero;
        private readonly IService<Autor> _serviceAutor;
       
        public LivrosController(ILivroService serviceLivro,IService<Genero> serviceGenero,IService<Autor> serviceAutor) {
            _serviceLivro = serviceLivro;
            _serviceGenero = serviceGenero;
            _serviceAutor = serviceAutor;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros(){
        
            var livros = await _serviceLivro.ListAsync();
            
            return Ok(livros);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Livro>))]
        public ActionResult<Livro> GetLivro(Guid id){
           
            Livro livro = HttpContext.Items["entity"] as Livro;
            
            return Ok(livro);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Livro>))]

        public async Task<IActionResult> PutLivro(Guid id,[FromBody]LivroInDTO livro){
           
            Livro _livro = HttpContext.Items["entity"] as Livro;

            _livro.Titulo = livro.Titulo;
            _livro.NumCopias = livro.NumCopias;
            
            await _serviceLivro.UpdateAsync(_livro);

            return NoContent();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<Livro>> PostLivro(LivroInDTO livro){
 
          
            Livro _livro = new(){
                Titulo = livro.Titulo,
                NumCopias = livro.NumCopias,
                Autores = livro.Autores.Select(x => _serviceAutor.FindAsync(x).Result).ToArray(),
                Generos = livro.Generos.Select(x => _serviceGenero.FindAsync(x).Result).ToArray()
            };

            await _serviceLivro.AddAsync(_livro);
            
            return CreatedAtAction("GetLivro",new {id = _livro.Id},_livro);
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationEntityExistAttribute<Livro>))]
        public async Task<IActionResult> DeleteLivro(Guid id){
            
            await _serviceLivro.DeleteAsync(id);

            return NoContent();
        }

    }
}