using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options => { options.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(5); })
                .UseIIS()
                .UseEnvironment("Development")
                .Build()
                .Run();
        }
    }
}
