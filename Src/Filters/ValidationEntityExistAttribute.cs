using System;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDrCash.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaDrCash.Filters{
    public class ValidationEntityExistAttribute<T> : IAsyncActionFilter where T: class
    {
        private readonly IRepository<T> _context;

        public ValidationEntityExistAttribute(IRepository<T> context) => _context = context;

     
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Guid id = Guid.Empty;

            if(context.ActionArguments.ContainsKey("id")){
                id = Guid.Parse(context.ActionArguments["id"].ToString());
            }else{
                context.Result = new BadRequestObjectResult("Bad id");
                return;
            }

            T obj = await _context.GetAsync(id);

            if(obj == null) context.Result = new NotFoundResult();
            else{
                context.HttpContext.Items.Add("entity",obj);
                await next();
            }

        }
    }
}