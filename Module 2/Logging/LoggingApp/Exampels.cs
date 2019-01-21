using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingApp
{
    internal class Exampels
    {
        private static ILogger<Exampels> GetLoggerInstance(IWebHost webHost)
        {
            var logger = webHost.Services.GetRequiredService<ILogger<Exampels>>();
            return logger;
        }

        public void SimpleLog(IWebHost webHost)
        {
            var logger = GetLoggerInstance(webHost);
            logger.LogInformation("Simple log");
            logger.LogTrace("Simple log");
            logger.LogWarning("Simple log");
            logger.LogDebug("Simple log");
            logger.LogError("Simple log");
            logger.LogCritical("Simple log");
        }

        public void LogEventId(IWebHost webHost)
        {
            var logger = GetLoggerInstance(webHost);
            logger.LogInformation(LogEvents.Update, "Update log");
            logger.LogInformation(LogEvents.Create, "Create log");
        }

        public void LogScope(IWebHost webHost)
        {
            var logger = GetLoggerInstance(webHost);
            using (logger.BeginScope("Message attached to logs created in the using block of id 1"))
            {
                logger.LogInformation(LogEvents.Update, "Update log");
                logger.LogInformation(LogEvents.Create, "Create log");
            }
        }
    }

    public class LogEvents
    {
        public const int Create = 245;
        public const int Update = 745;
    }
}
