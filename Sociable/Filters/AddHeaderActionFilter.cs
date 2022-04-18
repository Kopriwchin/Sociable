using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sociable.Filters
{
    public class AddHeaderActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Action-Name", context.ActionDescriptor.DisplayName);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Info-Result-Type", context.Result.GetType().Name);
        }

    }
}
