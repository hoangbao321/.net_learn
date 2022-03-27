using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs47.Middleware
{
    public class ThirdMidddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("hello hello");
            await context.Response.WriteAsync($"--3.1\n");
            await next.Invoke(context);
            await context.Response.WriteAsync("--3.2\n");
        }
    }
}
