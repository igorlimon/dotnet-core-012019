using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class Startup
    {
         public void Configure1(IApplicationBuilder app)
        {            
        }

        public void ConfigureServices1(IServiceCollection services)
        {
            services.AddTransient<IIQuestService>(s => new IQuestService("MyConnectionString"));
        }
    }
}