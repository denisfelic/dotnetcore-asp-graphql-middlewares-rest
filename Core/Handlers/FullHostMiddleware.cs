using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace dotnetcore_asp.Core.Handlers
{
    public class FullHostMiddleware
    {
        private readonly RequestDelegate next;
        private int requestCount = 0;

        public FullHostMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string queryString = httpContext.Request.QueryString.ToString();
            Console.WriteLine(requestCount);
            await next(httpContext);
           
            requestCount++;
        }
    }
}