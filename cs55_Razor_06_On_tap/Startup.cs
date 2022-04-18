using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using cs55_Razor_06.Services;
namespace cs55_Razor_06
{
    /**
     * -Model Binding : liên kết dữ liệu
     * Dữ liệu gửi đến theo dạng key value
     * Nguồn : 
     *       -Form HTML ( post) :               HTTPRequest.Form["key"]
     *       -Query (form) :                    HTTPRequest.Query["key"]
     *       - Header :                         HTTPRequest.Header["key"]
     *       - Route Data:                      HTTPRequest.RouteValue["key"]
     *       -
     *       - file upload
     *       - Body
     *       => dùng HTTPRequest ( Controller, PageModel , View)
     *       
     *      2 kiểu binding dữ liệu
     *      Attribute(thuộc tính): Parametter action/handler gọi là Binding
     */





    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            //services.AddSingleton<ProductServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
