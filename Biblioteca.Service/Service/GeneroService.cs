using Biblioteca.Data.IRepository;
using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Genero;
using Biblioteca.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Service
{
    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultadoDTO<GeneroDTO>> Adicionar(AdicionarGeneroDTO objetoEntrada)
        {
            var objeto = new Genero(objetoEntrada.Descricao);

            var sucesso = await _repository.Adicionar(objeto);

            if (sucesso)
            {
                var objetoSaida = new GeneroDTO() { GeneroId = objeto.GeneroId, Descricao = objeto.Descricao };

                return new ResultadoDTO<GeneroDTO>(sucesso, null, objetoSaida);
            }

            return new ResultadoDTO<GeneroDTO>(sucesso, "Ocorreu um problema ao adicionar o objeto", null);
        }

        public Task<ResultadoDTO<GeneroDTO>> Adicionar(GeneroDTO objetoEntrada)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultadoDTO<GeneroDTO>> Atualizar(AtualizarGeneroDTO objetoEntrada)
        {
            var objeto = await _repository.BuscarPorId(objetoEntrada.GeneroId);

            if (objeto is null)
                return new ResultadoDTO<GeneroDTO>(false, "Objeto não encontrado", null);

            objeto.Editar(objetoEntrada.Descricao);

            var sucesso = await _repository.Atualizar(objeto);

            if (sucesso)
            {
                var objetoSaida = new GeneroDTO() { GeneroId = objeto.GeneroId, Descricao = objeto.Descricao };

                return new ResultadoDTO<GeneroDTO>(sucesso, null, objetoSaida);
            }

            return new ResultadoDTO<GeneroDTO>(sucesso, "Ocorreu um problema ao editar o objeto", null);
        }

        public async Task<ResultadoDTO<GeneroDTO>> BuscarPorId(Guid id)
        {
            var resultado = await _repository.BuscarPorId(id);

            if (resultado is null)
                return new ResultadoDTO<GeneroDTO>(false, "Objeto não encontrado", null);

            var objetoSaida = new GeneroDTO() { GeneroId = resultado.GeneroId, Descricao = resultado.Descricao };

            return new ResultadoDTO<GeneroDTO>(true, null, objetoSaida);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ResultadoDTO<List<GeneroDTO>>> Listar()
        {
            var resultado = await _repository.Listar();

            if (resultado is null || resultado.Count == 0)
                return new ResultadoDTO<List<GeneroDTO>>(false, "A lista está vazia", new List<GeneroDTO>());

            var objetosSaida = new List<GeneroDTO>();

            foreach (var item in resultado)
            {
                var objetoSaida = new GeneroDTO() { GeneroId = item.GeneroId, Descricao = item.Descricao };

                objetosSaida.Add(objetoSaida);
            }

            return new ResultadoDTO<List<GeneroDTO>>(true, null, objetosSaida);
        }

        public async Task<ResultadoDTO<GeneroDTO>> Remover(Guid id)
        {
            var objeto = await _repository.BuscarPorId(id);

            if (objeto is null)
                return new ResultadoDTO<GeneroDTO>(false, "Objeto não encontrado", null);

            var sucesso = await _repository.Remover(objeto);

            if (sucesso)
                return new ResultadoDTO<GeneroDTO>(true, "Objeto removido com sucesso", null);

            return new ResultadoDTO<GeneroDTO>(false, "Ocorreu um problema ao remover o objeto", null);
        }
    }
}