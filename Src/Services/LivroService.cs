using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaDrCash.Models;
using BibliotecaDrCash.Repository;

namespace BibliotecaDrCash.Services{

    public interface ILivroService: IService<Livro>{
        Task<IEnumerable<Livro>> FilterByAutor(Autor autor);
        Task<IEnumerable<Livro>> FilterByGenero(Genero genero);
    }
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository) => _repository = repository;

        public async Task AddAsync(Livro entry)
        {
            await _repository.AddAsync(entry);
        }

        public async Task<Livro> DeleteAsync(Guid id)
        {
            return await _repository.RemoveAsync(id);
        }

        public async Task<Livro> FindAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<Livro>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(Livro entry)
        {
            await _repository.UpdateAsync(entry);
        }

        public async Task<IEnumerable<Livro>> FilterByAutor(Autor autor){
            return await _repository.FilterBy(livro => livro.Autores.Contains(autor));
        }

        public async Task<IEnumerable<Livro>> FilterByGenero(Genero genero){
            return await _repository.FilterBy(livro => livro.Generos.Contains(genero));
        }


    }
}