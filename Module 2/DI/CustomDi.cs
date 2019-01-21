using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public class CustomDi
    {
        private readonly ServiceCollection _services = new ServiceCollection();

        internal void PopulateService()
        {
            _services.AddTransient<IIQuestService>(s => new IQuestService("MyConnectionString"));
        }

        internal IIQuestService GetIQuestService()
        {
            var provider = _services.BuildServiceProvider();

            return provider.GetService<IIQuestService>();
        }
    }
}