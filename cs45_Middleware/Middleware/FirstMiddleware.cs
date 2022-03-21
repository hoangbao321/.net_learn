using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs45_Middleware.Middleware
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate requestDelegate;
        public FirstMiddleware(RequestDelegate _requestDelegate)
        {
            requestDelegate = _requestDelegate;
        }
        // httpcontext đi qua middleware trong pipelinel
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"URL: {context.Request.Path}");
            Console.WriteLine("first middleware");
            context.Items.Add("DataFromFirstMiddleWare", $"<p>URL: {context.Request.Path}</p>");
            await requestDelegate(context);
        }
    }
}
