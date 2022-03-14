using Biblioteca.Data.IRepository;
using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Autor;
using Biblioteca.Service.DTO.Genero;
using Biblioteca.Service.DTO.Livro;
using Biblioteca.Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultadoDTO<LivroDTO>> Adicionar(AdicionarLivroDTO objetoEntrada)
        {
            var objeto = new Livro(objetoEntrada.Titulo, objetoEntrada.Quantidade, objetoEntrada.AutorId, objetoEntrada.GeneroId);

            var sucesso = await _repository.Adicionar(objeto);

            if (sucesso)
            {
                var resultado = await BuscarPorId(objeto.LivroId);

                return new ResultadoDTO<LivroDTO>(sucesso, null, resultado.Saida);
            }

            return new ResultadoDTO<LivroDTO>(sucesso, "Ocorreu um problema ao adicionar o objeto", null);
        }

        public async Task<ResultadoDTO<LivroDTO>> Atualizar(AtualizarLivroDTO objetoEntrada)
        {
            var objeto = await _repository.BuscarPorId(objetoEntrada.LivroId);

            if (objeto is null)
                return new ResultadoDTO<LivroDTO>(false, "Objeto não encontrado", null);

            objeto.Editar(objetoEntrada.Titulo, objetoEntrada.Quantidade, objetoEntrada.AutorId, objetoEntrada.GeneroId);

            var sucesso = await _repository.Atualizar(objeto);

            if (sucesso)
            {
                var resultado = await BuscarPorId(objeto.LivroId);

                return new ResultadoDTO<LivroDTO>(sucesso, null, resultado.Saida);
            }

            return new ResultadoDTO<LivroDTO>(sucesso, "Ocorreu um problema ao editar o objeto", null);
        }

        public async Task<ResultadoDTO<LivroDTO>> BuscarPorId(Guid id)
        {
            var resultado = await _repository.BuscarPorId(id);

            if (resultado is null)
                return new ResultadoDTO<LivroDTO>(false, "Objeto não encontrado", null);

            var objetoSaida = new LivroDTO(resultado);

            return new ResultadoDTO<LivroDTO>(true, null, objetoSaida);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<ResultadoDTO<List<LivroDTO>>> Listar()
        {
            var resultado = await _repository.Listar();

            if (resultado is null || resultado.Count == 0)
                return new ResultadoDTO<List<LivroDTO>>(false, "A lista está vazia", new List<LivroDTO>());

            var objetosSaida = new List<LivroDTO>();

            foreach (var item in resultado)
            {
                var objetoSaida = new LivroDTO(item);

                objetosSaida.Add(objetoSaida);
            }

            return new ResultadoDTO<List<LivroDTO>>(true, null, objetosSaida);
        }

        public async Task<ResultadoDTO<LivroDTO>> Remover(Guid id)
        {
            var objeto = await _repository.BuscarPorId(id);

            if (objeto is null)
                return new ResultadoDTO<LivroDTO>(false, "Objeto não encontrado", null);

            var sucesso = await _repository.Remover(objeto);

            if (sucesso)
                return new ResultadoDTO<LivroDTO>(true, "Objeto removido com sucesso", null);

            return new ResultadoDTO<LivroDTO>(false, "Ocorreu um problema ao remover o objeto", null);
        }
    }
}
