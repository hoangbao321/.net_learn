using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cs47.Service;
namespace cs47.TestOptionMiddleware
{
    public class TestOptionsMiddleware : IMiddleware
    {
        private TestOptions _testOptions { get; set; }
        private ProductName _productName { get; set; }
        /* inject 2 kiểu
         *      + 1 inject option , 
         *      + 1 inject dịch vụ khác
         */
        public TestOptionsMiddleware(IOptions<TestOptions> option, ProductName productName)
        {
            _testOptions = option.Value;
            _productName = productName;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Show option in TestOptionsMiddleware\n");

            StringBuilder stringBuilder  = new();

            stringBuilder.Append(_testOptions.opt_key2.k1+" ");
            stringBuilder.Append(string.Join(",",_testOptions.opt_key2.k3));

            // tên sp lấy từ dv product name
            foreach (var item in _productName.GetName())
            {
                stringBuilder.AppendLine(item);
            }

            await context.Response.WriteAsync($"testoptionMiddledasdasdasware: {stringBuilder.ToString()}\n");
            await next(context);
        }
    }
}
