namespace SkillsHubV2.Web.Configuration;

public class DatabaseConfigurationSource : IConfigurationSource
{
    private readonly string _connectionString;

    public DatabaseConfigurationSource (string connectionString)
    {
        _connectionString = connectionString;
    }

    public IConfigurationProvider Build (IConfigurationBuilder builder)
    {
        return new DatabaseConfigurationProvider(_connectionString);
    }
}
