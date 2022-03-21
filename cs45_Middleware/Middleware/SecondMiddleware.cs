using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs45_Middleware.Middleware
{
    public class SecondMiddleware : IMiddleware
    {
        /**
         * url : "/xxx.html"
         *     - khong goi duoc middleware phia sau
         *     - Ban khong co quyen truy cap 
         *     - Header - secondmiddleware: ban khong duoc truy cap
         * url: "/xxx.html"
         *      - Header -SecondMiddleware : ban duoc truy cap
         *      -Chuyen http context cho middleware phia sau 
         **/
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("datatumiddleware1", "ban ko co quyen truy cap ");
                var datafromMiddleware = context.Items["DataFromFirstMiddleWare"];
                if(datafromMiddleware != null)
                    await context.Response.WriteAsync((string)datafromMiddleware+ "\n");
                await context.Response.WriteAsync("ban ko duoc truy cap");
            }
            else
            {
                context.Response.Headers.Add("DataFromFirstMiddleWare", "ban co quyen truy cap ");
                var data = context.Items["DataFromFirstMiddleWare"];
                if (data != null)
                    await context.Response.WriteAsync((string)data + "\n");
                await next(context);
            }
        }
    }
}
