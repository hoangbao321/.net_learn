using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cs50_Razor_01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // đăng kí engine dv razor page vào hệ thống
            // bây giờ muốn đổi chỗ lưu thư muc page
            services.AddRazorPages().AddRazorPagesOptions(option => 
            {
                //option.RootDirectory = "/Content";
                //option.Conventions.AddPageRoute("/FirstPage","trang-dau-tien.html");
            });
            // cho hết chữ trong URL biến thành chữ thường
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // thiết lập 1 cái endpoint
                // tìm toàn mã nguồn , .cshtml coi như 1 endpoint
                //FirstPage.cshtml URl=/FirstPage /SecondPage
                endpoints.MapRazorPages();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

/*
 * Razor Page (.cshtml) = html +c#
 * Engine Razor biên dịch .cshtml -> Response
 */
