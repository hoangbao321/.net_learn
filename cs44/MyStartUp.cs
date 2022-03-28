using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cs44
{
    public class MyStartUp
    {
        // đăng kí các dịch vụ ứng dụng (DI)
        public void Configuration(IServiceCollection services)
        {

        }
        // Xây dựng pipeline (Chuoi Middleware)
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // EndpointRoutingMiddleware điều hướng đi tới cái 
            // phân tích địa chỉ truy cập điều hướng request tạo ra các endpoint
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                //Get
                endpoints.MapGet("/", async context =>
                {
                    string html = @"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset=""UTF-8"">
                    <title>Trang web đầu tiên</title>
                    <link rel=""stylesheet"" href=""/css/bootstrap.min.css"" />
                    <script src=""/js/jquery.min.js""></script>
                    <script src=""/js/popper.min.js""></script>
                    <script src=""/js/bootstrap.min.js""></script>


                </head>
                <body>
                    <nav class=""navbar navbar-expand-lg navbar-dark bg-danger"">
                            <a class=""navbar-brand"" href=""#"">Brand-Logo</a>
                            <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#my-nav-bar"" aria-controls=""my-nav-bar"" aria-expanded=""false"" aria-label=""Toggle navigation"">
                                    <span class=""navbar-toggler-icon""></span>
                            </button>
                            <div class=""collapse navbar-collapse"" id=""my-nav-bar"">
                            <ul class=""navbar-nav"">
                                <li class=""nav-item active"">
                                    <a class=""nav-link"" href=""#"">Trang chủ</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link"" href=""#"">Học HTML</a>
                                </li>
                            
                                <li class=""nav-item"">
                                    <a class=""nav-link disabled"" href=""#"">Gửi bài</a>
                                </li>
                        </ul>
                        </div>
                    </nav> 
                    <p class=""display-4 text-danger"">Đây là trang đã có Bootstrap</p>
                </body>
                </html>";
                    // HttpContext chứa tất cả các thông tin request , yêu cầu thông tin client về đến server
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync("Trang About\n");
                });

                endpoints.MapGet("/hello", async context =>
                {
                    await context.Response.WriteAsync("hello world");
                });
            });

            // ít khi sử dụng trực tiếp 2 cái như dưới
            // terminated Middleware M2
            app.Map("/abc", app1 =>
            {
                app1.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Noi dung tra ve tu ABC");
                });
            });

            // terminated Middleware của .netcore
            // app.UseStatusCodePages();

            // wwwroot 
            // terminated Middleware của .netcore
            // nhưng cho truy cập file tĩnh trong wwwroot
            app.UseStaticFiles();

        }

    }
}
