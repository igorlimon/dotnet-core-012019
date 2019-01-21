using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class CustomMiddleware
    {
        public CustomMiddleware(RequestDelegate next)
        {
        }
        
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Hello from CustomMiddleware");
        }
}
}