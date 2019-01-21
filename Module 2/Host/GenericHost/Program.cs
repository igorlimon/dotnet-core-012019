using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Run();
        }

        private static async Task Run()
        {
            var host = new HostBuilder()
              .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<LifetimeEventsHostedService>();
                    services.AddHostedService<TimedHostedService>();
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
                .UseConsoleLifetime()
                .Build();

            await host.StartAsync();
        }
    }
}
