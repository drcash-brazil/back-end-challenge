using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Service.DTO
{
    public class ResultadoDTO<TEntity> where TEntity : class
    {
        public ResultadoDTO()
        {

        }

        public ResultadoDTO(bool sucesso, string mensagem, TEntity objetoSaida)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Saida = objetoSaida;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public TEntity Saida { get; set; }
    }
}