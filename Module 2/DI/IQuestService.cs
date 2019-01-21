namespace DI
{
    public class IQuestService : IIQuestService
    {
        private string connectionString;
        
        public IQuestService(string connString)
        {
            this.connectionString = connString;
        }

        public string GetConstructorParameter()
        {
            return connectionString;
        }
    }
}
