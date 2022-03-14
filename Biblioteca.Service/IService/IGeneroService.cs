using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Genero;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.IService
{
    public interface IGeneroService: ICRUDService<GeneroDTO>
    {
        Task<ResultadoDTO<GeneroDTO>> Adicionar(AdicionarGeneroDTO objetoEntrada);
        Task<ResultadoDTO<GeneroDTO>> Atualizar(AtualizarGeneroDTO objetoEntrada);
    }
}