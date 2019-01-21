using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;

namespace LoggingApp
{
    class Program
    {
        private static readonly Exampels _exampels = new Exampels();

        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    IConfigurationSection configurationSection = hostingContext.Configuration.GetSection("Logging");
                    logging.AddConfiguration(configurationSection);
                    //logging.AddConsole();
                    logging.AddConsole(options => options.IncludeScopes = true);
                    logging.AddDebug();
                    logging.AddEventSourceLogger();

                    //logging.AddFilter((provider, category, logLevel) =>
                    //{
                    //    if (category == "LoggingApp.Exampels")
                    //    {
                    //        return false;
                    //    }
                    //    return true;
                    //});
                })
                .UseStartup<Startup>()
                .Build();

            //_exampels.SimpleLog(webHost);
            //_exampels.LogEventId(webHost);
            _exampels.LogScope(webHost);

            webHost.Run();
        }
    }
}
