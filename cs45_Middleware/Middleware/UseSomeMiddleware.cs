using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs45_Middleware.Middleware
{
    public static class UseSomeMiddleware
    {
        public static void UseFirstMiddleWare (this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void UseSecondMiddleWare (this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
    }
}
