using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using BibliotecaDrCash.Repository;

namespace BibliotecaDrCash.Services{
    public class GeneroService : IService<Genero>
    {
        private readonly IGeneroRepository _repository;
        private readonly ILivroService _livroService;

        public GeneroService(IGeneroRepository repository,ILivroService livroService) {
            _repository = repository;
            _livroService = livroService;
        }

        public async Task AddAsync(Genero entry)
        {
            await _repository.AddAsync(entry);
        }

        public async Task<Genero> DeleteAsync(Guid id)
        {
            Genero genero =  await _repository.GetAsync(id);
            
            

            var livros = await _livroService.FilterByGenero(genero);

            foreach(var livro in livros){
                if(livro.Autores.Count == 0){
                    await _livroService.DeleteAsync(livro.Id);
                }
            }

            await _repository.RemoveAsync(genero);
            
            return genero;
        }

        public async Task<Genero> FindAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Genero>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(Genero entry)
        {
            await _repository.UpdateAsync(entry);
        }
    }
}