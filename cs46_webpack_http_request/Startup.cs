using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace cs46_webpack_http_request
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // tạo menu
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                    var html = HtmlHelper.HtmlDocument("Xin chao", menu + HtmlHelper.HtmlTrangchu());
                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/RequestInfo", async context =>
                {
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);

                    var info = RequestProcess.RequestInfo(context.Request).HtmlTag("div", "container");

                    var html = HtmlHelper.HtmlDocument("Thong tin RequestInfo", menu + info);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Encoding", async context =>
                {
                    context.Response.Headers.Add("asa", "bbb");
                    await context.Response.WriteAsync("Encoding");
                });

                //  /Cookies/ write
                //  /Cookies/read
                endpoints.MapGet("/Cookies/{*action}", async context =>
                {
                    // tạo menu
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);

                    // tạo mấy cái nút
                    var huongdan = @$"<a class=""btn btn-danger""  href=""/Cookies/read"">Doc Cookies</a>
                                    <a class=""btn btn-success"" href=""/Cookies/write"">Ghi Cookies</a>";

                    var action = context.GetRouteValue("action") ?? "read";

                    var message = "";
                    if (action.ToString() == "write")
                    {
                        var option = new CookieOptions()
                        {
                            Path = "/abc",
                            Expires = DateTime.Now.AddDays(1),
                        };
                        // ten-gia tri
                        context.Response.Cookies.Append("masanpham", "dasdasda",option);
                        message = "Cookies duoc ghi";
                    }
                    else
                    {
                        var listcokie = context.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}".HtmlTag("li"));
                        message = string.Join("", listcokie).HtmlTag("ul");
                    }

                    message = message.HtmlTag("div", "alert alert-danger");

                    huongdan = huongdan.HtmlTag("div", "container mt-4");

                    var html = HtmlHelper.HtmlDocument("COOKIES: " + action, menu + huongdan + message);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapGet("/Json", async context =>
                {
                    var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);

                    var p = new
                    {
                        TenSp = "Dong ho Abc",
                        Gia = 500000,
                        NgaySX = new DateTime(2022, 3, 21)
                    };


                    var json = JsonConvert.SerializeObject(p).HtmlTag("div", "container");

                    var html = HtmlHelper.HtmlDocument("JSON", menu + json);

                    await context.Response.WriteAsync(html);
                });

                endpoints.MapMethods("/Form", new string[] { "GET", "POST" }, async context =>
                   {
                       var menu = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
                       var htmlform = RequestProcess.ProcessForm(context.Request);
                       var html = HtmlHelper.HtmlDocument("Test Submit form", menu + htmlform);
                       await context.Response.WriteAsync(html);
                   });

            });
        }
    }
}
