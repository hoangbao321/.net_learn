using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs47.Middleware
{
    public static class UseMiddleware
    {
        public static void FirstMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<FirstMiddleware>();
        }
        public static void SecondMiddleware ( this IApplicationBuilder app)
        {
            app.UseMiddleware<SecondMiddleware>();
        }
        public static void ThirdMiddleware( this IApplicationBuilder app)
        {
            app.UseMiddleware<ThirdMidddleware>();
        }
    }
}
