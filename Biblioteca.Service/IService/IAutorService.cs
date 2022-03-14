using Biblioteca.Domain.Entities;
using Biblioteca.Service.DTO;
using Biblioteca.Service.DTO.Autor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Service.IService
{
    public interface IAutorService : ICRUDService<AutorDTO>
    {
        Task<ResultadoDTO<AutorDTO>> Adicionar(AdicionarAutorDTO objetoEntrada);
        Task<ResultadoDTO<AutorDTO>> Atualizar(AtualizarAutorDTO objetoEntrada);
    }
}
