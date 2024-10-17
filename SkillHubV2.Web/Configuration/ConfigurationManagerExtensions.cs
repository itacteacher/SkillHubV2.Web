namespace SkillsHubV2.Web.Configuration;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddEntityConfiguration (
        this ConfigurationManager manager)
    {
        var connectionString = manager.GetConnectionString("DefaultConnection");

        IConfigurationBuilder configBuilder = manager;
        configBuilder.Add(new DatabaseConfigurationSource(connectionString));

        return manager;
    }
}
