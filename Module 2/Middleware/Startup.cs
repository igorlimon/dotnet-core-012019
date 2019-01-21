using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Http;

namespace Middleware
{
    public class Startup
    {
        private readonly Exampels _exampels = new Exampels();

         public void Configure(IApplicationBuilder app)
        {
            _exampels.Use(app);            
            //_exampels.UseOrder(app);
            // _exampels.Run(app);            
            // _exampels.Map(app);
            // _exampels.Map(app);
            // _exampels.MapWhenOptions(app, new  MapWhenOptions
            // {
            //     Branch =  
            //         context => 
            //             context.Response.WriteAsync($"olleh"),
            //     Predicate = context => context.Request.Path.Value.Contains("hello")
            // });
        }
    }
}