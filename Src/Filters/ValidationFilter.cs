using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaDrCash.Filters{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
            foreach(var param in context.ActionArguments){
                if(param.Value == null){
                    context.Result = new BadRequestObjectResult("Object is null");
                    return;
                }
            }
            

            if(!context.ModelState.IsValid){
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}