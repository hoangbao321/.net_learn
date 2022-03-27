using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs47.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public FirstMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate;
        }
        public async Task InvokeAsync( HttpContext context)
        {

            await context.Response.WriteAsync("--1.1\n");
            await requestDelegate(context);
            await context.Response.WriteAsync("--1.2\n");
        }
    }
}
