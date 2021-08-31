using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Net;

namespace BibliotecaDrCash.Controllers{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class GlobalErrorController:ControllerBase{
        [HttpGet]
        [Route("/errors")]
        public IActionResult HandleErros(){
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;

            var code = exception is NullReferenceException ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError;

            return Problem(detail: exception.Message,statusCode: (int)code);
        }
    }
}