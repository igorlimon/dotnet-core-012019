using System;

namespace Configuration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var example = new Exampels();
            //example.ReadInMemoryConfiguration();
            //example.ReadJsonConfiguration();
            //example.ReadEnvironmentVariablesConfiguration();
            //example.ReadCommandLineConfiguration(args);
            //example.ReadConfigurationWithOptionalSettings();

            //example.ReadConfigurationWithMultipleProviders(args);

            example.ReadClassMappingConfiguration();

            Console.ReadKey();
        }
    }
}
