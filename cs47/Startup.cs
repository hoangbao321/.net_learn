using cs47.Middleware;
using cs47.Service;
using cs47.TestOptionMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace cs47
{
    public class Startup
    {

        IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // IOptions<TestOptions>
            services.Configure<TestOptions>(configuration.GetSection("TestOptions"));

            // đăng kí dịch vụ
            services.AddTransient<TestOptionsMiddleware>();

            services.AddTransient<ThirdMidddleware>();

            /* đăng kí vào Di của hệ thống
             *  kiểu singgleton đăng kí cái dv này chỉ tạo ra 1 dối tượng là productname cho tất cả các truy vấn
            */
            services.AddSingleton<ProductName, ProductName>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.FirstMiddleware();
            app.SecondMiddleware();
            app.ThirdMiddleware();

            app.UseMiddleware<TestOptionsMiddleware>();

            app.UseRouting();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Helldasdasdo World!\n");
                });
                endpoints.MapGet("/ShowOptions", async context =>
                {
                    /*
                    var config = context.RequestServices.GetService<IConfiguration>();
                    // dịch vụ khởi tạo cùng asp.net nhiệm vụ nạp các cấu hình trong appsetting
                    // gọi dịch vu IserviceProvider

                    var testOptions = config.GetSection("TestOptions");
                    var opt_key1 = testOptions["opt_key1"];// phone
                    var opt_key2_k3_value = testOptions.GetSection("opt_key2").GetSection("k3").GetChildren();

                    var stringbuilder = new StringBuilder();
                    // C1
                    stringbuilder.Append($"opt_key1:{opt_key1} value of K3: ");
                    foreach (var item in opt_key2_k3_value)
                    {
                        stringbuilder.Append(item.Value + " ");
                    }
                    await context.Response.WriteAsync(stringbuilder.ToString());

                    // đọc cấu hình thành 1 đối tượng
                    var config_2 = context.RequestServices.GetService<IConfiguration>();
                    var textoption = config_2.GetSection("TestOptions").Get<TestOptions>();

                    // Đang ki thiet lap vao DI cua ung dung, doc cau hinh IOptions

                    var testoption_2 = context.RequestServices.GetService<IOptions<TestOptions>>().Value;
                    
                    await context.Response.WriteAsync("showoptions\n");
                    */

                    /*
                    var aaa = context.RequestServices.GetService<ProductName>();
                    string kq = "";
                    foreach (var name in aaa.GetName())
                    {
                        kq = kq + name + " ";
                    }
                    await context.Response.WriteAsync(kq + "dasdada");
                    */

                });
            });

        }
    }
}
