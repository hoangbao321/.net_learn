using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using cs45_Middleware.Middleware;

namespace cs45_Middleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<SecondMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) => 
            //{
            //    await context.Response.WriteAsync("Middleware 1 \n");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("quay lai Middleware 1 \n");
            //});


            /*
             * Http context
             *      First Middleware - Second MiddleWare
             */


            //pipeline
            /*
             * pipeline: Staticmiddleware
             *      -> Firstmiddleware
             *          -> Secondmiddleware
             *              -> Endpointmiddleware(E1, E2 ko thoa)
             *                -> M1
             * 
             */


            // lấy trong fileroot
            app.UseStaticFiles();

            app.UseFirstMiddleWare();

            app.UseSecondMiddleWare();

            app.UseRouting(); // EndpointRoutingMiddleware

            //terminated middleware
            app.UseEndpoints(endpoints =>
            {
                // E1
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("Trang about");
                });
                // E2
                endpoints.MapGet("/sanpham", async context =>
                {
                    await context.Response.WriteAsync("Trang san pham");
                });

            });

            
            //re nhanh trong pipeline
            app.Map("/admin", (app1) =>
            {
                app1.UseRouting(); // EndpointRoutingMiddleware
                app1.UseEndpoints(endpoints =>
                {
                    // Brand Endpoint 1
                    endpoints.MapGet("/user", async context =>
                    {
                        await context.Response.WriteAsync("Trang quan ly user");
                    });
                    // BE2
                    endpoints.MapGet("/product", async context =>
                    {
                        await context.Response.WriteAsync("Trang quan ly san pham");
                    });

                });
                // create middleware
                //  middleware M2
                app1.Run(async context =>
                {
                    await context.Response.WriteAsync("Trang Admin \n");
                });

            });

            // middleware M1
            // middleware cuối cùng và ko gọi middleware phía sau
            app.Run(async context =>
            {
                await context.Response.WriteAsync("teminal Middleware 3-M1 \n");
            });

        }
    }
}
