using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
            CustomImplementationOfDi();
        }

        private static void CustomImplementationOfDi()
        {
            var customDi = new CustomDi();
            customDi.PopulateService();

            var peakItService = customDi.GetIQuestService();
            Console.WriteLine(peakItService.GetConstructorParameter());
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<LifetimeDiStartup>()
                .UseEnvironment("Development");
    }
}
