using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cs44.middleware;

namespace cs44.Somemiddleware
{
    public static class Somemiddleware
    {
        public static IApplicationBuilder Somemiddleware_bao(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Simplemiddleware>(); 
        }
    }
}
