using Biblioteca.Data.IRepository;
using Biblioteca.Data.Repository;
using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Autor;
using Biblioteca.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Service
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;

        public AutorService(IAutorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultadoDTO<AutorDTO>> Adicionar(AdicionarAutorDTO objetoEntrada)
        {
            var objeto = new Autor(objetoEntrada.Nome);

            var sucesso = await _repository.Adicionar(objeto);

            if (sucesso)
            {
                var objetoSaida = new AutorDTO() { AutorId = objeto.AutorId, Nome = objeto.Nome };

                return new ResultadoDTO<AutorDTO>(sucesso, null, objetoSaida);
            }

            return new ResultadoDTO<AutorDTO>(sucesso, "Ocorreu um problema ao adicionar o objeto", null);
        }

        public async Task<ResultadoDTO<AutorDTO>> Atualizar(AtualizarAutorDTO objetoEntrada)
        {
            var objeto = await _repository.BuscarPorId(objetoEntrada.AutorId);

            if (objeto is null)
                return new ResultadoDTO<AutorDTO>(false, "Objeto não encontrado", null);

            objeto.Editar(objetoEntrada.Nome);

            var sucesso = await _repository.Atualizar(objeto);

            if (sucesso)
            {
                var objetoSaida = new AutorDTO() { AutorId = objeto.AutorId, Nome = objeto.Nome };

                return new ResultadoDTO<AutorDTO>(sucesso, null, objetoSaida);
            }

            return new ResultadoDTO<AutorDTO>(sucesso, "Ocorreu um problema ao editar o objeto", null);
        }

        public async Task<ResultadoDTO<AutorDTO>> BuscarPorId(Guid id)
        {
            var resultado = await _repository.BuscarPorId(id);

            if (resultado is null)
                return new ResultadoDTO<AutorDTO>(false, "Objeto não encontrado", null);

            var objetoSaida = new AutorDTO() { AutorId = resultado.AutorId, Nome = resultado.Nome };

            return new ResultadoDTO<AutorDTO>(true, null, objetoSaida);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ResultadoDTO<List<AutorDTO>>> Listar()
        {
            var resultado = await _repository.Listar();

            if (resultado is null || resultado.Count == 0)
                return new ResultadoDTO<List<AutorDTO>>(false, "A lista está vazia", new List<AutorDTO>());

            var objetosSaida = new List<AutorDTO>();

            foreach (var item in resultado)
            {
                var objetoSaida = new AutorDTO() { AutorId = item.AutorId, Nome = item.Nome };

                objetosSaida.Add(objetoSaida);
            }

            return new ResultadoDTO<List<AutorDTO>>(true, null, objetosSaida);
        }

        public async Task<ResultadoDTO<AutorDTO>> Remover(Guid id)
        {
            var objeto = await _repository.BuscarPorId(id);

            if (objeto is null)
                return new ResultadoDTO<AutorDTO>(false, "Objeto não encontrado", null);

            var sucesso = await _repository.Remover(objeto);

            if (sucesso)
                return new ResultadoDTO<AutorDTO>(true, "Objeto removido com sucesso", null);

            return new ResultadoDTO<AutorDTO>(false, "Ocorreu um problema ao remover o objeto", null);
        }
    }
}
