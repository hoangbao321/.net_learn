using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs47.Middleware
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public SecondMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {

            await context.Response.WriteAsync("----2.1\n");
            await requestDelegate(context);
            await context.Response.WriteAsync("----2.2\n");
        }
    }
}
