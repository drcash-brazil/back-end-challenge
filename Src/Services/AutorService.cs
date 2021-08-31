using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using BibliotecaDrCash.Repository;

namespace BibliotecaDrCash.Services{
    public class AutorService : IService<Autor>
    {
        private readonly IAutorRepository _repository;
        private readonly ILivroService _livroService;

        public AutorService(IAutorRepository repository,ILivroService livroService){
            _repository = repository;
            _livroService = livroService;
        }
    
        public async Task AddAsync(Autor entry)
        {
            await _repository.AddAsync(entry);
        }

        public async Task<Autor> DeleteAsync(Guid id)
        {
            Autor autor =  await _repository.GetAsync(id);
            
            

            var livros = await _livroService.FilterByAutor(autor);

            foreach(var livro in livros){
                if(livro.Autores.Count == 0){
                    await _livroService.DeleteAsync(livro.Id);
                }
            }

            await _repository.RemoveAsync(autor);
            
            return autor;
        }

        public async Task<Autor> FindAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Autor>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(Autor entry)
        {
            await _repository.UpdateAsync(entry);
        }
    }
}