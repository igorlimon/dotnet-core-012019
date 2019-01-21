using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Configuration
{
    internal class Exampels
    {
        internal IConfigurationRoot SetupInMemoryConfiguration()
        {
            Dictionary<string, string> arrayDict = new Dictionary<string, string>
            {
                {"date", "21/01/2019"},
                {"name", "IQuest"}
            };
            var builder = new ConfigurationBuilder();
            builder.AddInMemoryCollection(arrayDict);
            return builder.Build();
        }

        internal void ReadInMemoryConfiguration()
        {
            var config = SetupInMemoryConfiguration();
            string name = config["name"];
            string date = config["date"];
            Console.WriteLine($"{name} {date}");
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupJsonConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("app/appsettings1.json")
                .Build();

            return config;
        }

        internal void ReadJsonConfiguration()
        {
            var config = SetupJsonConfiguration();
            string val1 = config["SimpleConfig"];
            string val2 = config["AnotherOne"];
            Console.WriteLine($"{val1} {val2}");
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupEnvironmentVariablesConfiguration()
        {
            return new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
        }

        internal void ReadEnvironmentVariablesConfiguration()
        {
            IConfigurationRoot config = SetupEnvironmentVariablesConfiguration();
            string year = config["year"];
            string month = config["month"];
            string day = config["day"];
            string location = config["location"];
            Console.WriteLine($"{year} {month} {day} {location}");
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupCommandLineConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();
        }

        internal void ReadCommandLineConfiguration(string[] args)
        {
            var config = SetupCommandLineConfiguration(args);
            string key1 = config["key1"];
            Console.WriteLine($"{key1}");
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupConfigurationWithOptionalSettings()
        {
            string environment = Environment.GetEnvironmentVariable("Environment");

            return new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .AddJsonFile($"appsettings.{environment}.json", optional: true)
                 .Build();
        }

        internal void ReadConfigurationWithOptionalSettings()
        {
            var config = SetupConfigurationWithOptionalSettings();
            Console.WriteLine(nameof(ReadConfigurationWithOptionalSettings));
            Console.WriteLine(config.GetSection("ConnectionStrings")["DefaultConnection"]);
            Console.WriteLine(config.GetConnectionString("DefaultConnection"));
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupConfigurationWithMultipleProviders(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("Env");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddInMemoryCollection(new Dictionary<string, string> {
                    {"K0", "ABC"},
                    {"K1", "DEF"}
                })
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        internal void ReadConfigurationWithMultipleProviders(string[] args)
        {
            var config = SetupConfigurationWithMultipleProviders(args);
            Console.WriteLine(config.GetSection("ConnectionStrings")["DefaultConnection"]);
            Console.WriteLine($"{config["key1"]}");
            Console.WriteLine($"{config["year"]} {config["month"]} {config["day"]} {config["location"]}");
            Console.WriteLine($"{config["K0"]} {config["k1"]}");
            Console.WriteLine($"{config["SimpleConfig"]} {config["AnotherOne"]}");
            Console.WriteLine();
        }

        internal IConfigurationRoot SetupClassMappingConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("classmapping.json")
                .Build();

            return config;
        }

        internal void ReadClassMappingConfiguration()
        {
            var config = SetupClassMappingConfiguration();
            AppConfiguration appConfiguration = new AppConfiguration();
            config.GetSection("AppConfiguration").Bind(appConfiguration);
            Console.WriteLine($"{appConfiguration.ConnectionString} {appConfiguration.Profile.UserName}");
            Console.WriteLine();
        }
    }
}