using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnetcore_asp.Core.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthMiddlewareAttribute : TypeFilterAttribute
    {
        public CustomAuthMiddlewareAttribute() : base(typeof(CustomAuthMiddlewareFilter))
        {
        }

        private class CustomAuthMiddlewareFilter : IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {

                Console.WriteLine("Runs before");
                var resultContext = await next();
                Console.WriteLine("Runs after");
            }
        }
    }
}