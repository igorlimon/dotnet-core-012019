using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ErrorHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
