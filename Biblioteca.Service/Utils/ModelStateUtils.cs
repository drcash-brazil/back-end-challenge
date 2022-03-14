using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Service.Utils
{
    public static class ModelStateUtils
    {
        public static string ObterMensagemDeErrosPorModelState(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors);

            var mensagem = string.Join(';', errors.Select(e => e.ErrorMessage));

            return mensagem;
        }
    }
}
