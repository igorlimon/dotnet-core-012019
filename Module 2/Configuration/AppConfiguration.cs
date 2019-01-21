namespace Configuration
{
    public class AppConfiguration
    {
        public ProfileConfiguration Profile { get; set; }
        public string ConnectionString { get; set; }
    }

    public class ProfileConfiguration
    {
        public string UserName { get; set; }
    }
}