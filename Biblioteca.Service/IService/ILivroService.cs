using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Livro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.IService
{
    public interface ILivroService: ICRUDService<LivroDTO>
    {
        Task<ResultadoDTO<LivroDTO>> Adicionar(AdicionarLivroDTO objetoEntrada);
        Task<ResultadoDTO<LivroDTO>> Atualizar(AtualizarLivroDTO objetoEntrada);
    }
}