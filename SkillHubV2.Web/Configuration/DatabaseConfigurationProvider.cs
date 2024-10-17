using Microsoft.Data.SqlClient;

namespace SkillsHubV2.Web.Configuration;

public class DatabaseConfigurationProvider : ConfigurationProvider
{
    private readonly string _connectionString;

    public DatabaseConfigurationProvider (string connectionString)
    {
        _connectionString = connectionString;
    }

    public override void Load ()
    {
        var settings = LoadSettingsFromDatabase();
        foreach (var setting in settings)
        {
            Data.Add(setting.Key, setting.Value);
        }
    }

    private IEnumerable<ConfigurationSetting> LoadSettingsFromDatabase ()
    {
        List<ConfigurationSetting> settings = new List<ConfigurationSetting>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var command = new SqlCommand("SELECT [Key], [Value] FROM ConfigurationSettings", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    settings.Add(new ConfigurationSetting
                    {
                        Key = reader["Key"].ToString(),
                        Value = reader["Value"].ToString()
                    });
                }
            }
        }

        return settings;
    }
}
