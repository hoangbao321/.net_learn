using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace cs44.middleware
{
    // cái này là middleware 
    public class Simplemiddleware
    {
        private readonly RequestDelegate _myservice;
        public Simplemiddleware(RequestDelegate next)
        {
            _myservice = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("from bao\n");
            await _myservice(context);
            await context.Response.WriteAsync("from baodasd\n");

        }
    }
}
