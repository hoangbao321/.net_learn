using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cs44
{
    public class Program
    {
        /*
         * Host (Ihost) Object:
         *          - Dependency Injection(ID) : IServiceProveide(ServiceCollection)
         *          - Logging (ILogging)
         *          - Configuration: chứa cấu hình ứng dụng
         *          - IhostedService => StartAsync : Run HTTP Server (Kestrol Http)
         *          
         *      1) Tạo IhostBuilder
         *      2) Cấu hình , đăng kí các dịch vụ (gọi ConfigureWebHostDefaults)
         *      3) IhostBulder.Build()=> Host (Ihost)
         *      4) Host.Run();
         */
        public static void Main(string[] args)
        {
            Console.WriteLine("start project");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // tùy biến thêm về Host

                    // sử dụng public làm web root thay cho wwwroot
                    //webBuilder.UseWebRoot("public");
                    //webBuilder.UseStartup<Startup>();
                    webBuilder.UseStartup<MyStartUp>();
                });
    }
}
