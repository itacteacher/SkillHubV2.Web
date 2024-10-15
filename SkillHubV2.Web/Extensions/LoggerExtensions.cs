using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using SkillsHubV2.BLL.Logging;

namespace SkillsHubV2.Web.Extensions;

public static class LoggerExtensions
{
    public static void ConfigureSerilog (this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();
    }

    public static void ConfigureJsonConsoleLogging (this WebApplicationBuilder builder)
    {
        builder.Logging.AddJsonConsole(options =>
        {
            options.JsonWriterOptions = new()
            {
                Indented = true
            };
        });
    }

    public static void ConfigureHttpLogging (this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.MediaTypeOptions.AddText("application/json");
            logging.RequestBodyLogLimit = 4096;
            logging.ResponseBodyLogLimit = 4096;
            logging.CombineLogs = true;
        });
    }

    public static void ConfigureCustomFileLogging (this WebApplicationBuilder builder)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "logs", "logs.txt");
        builder.Logging.AddProvider(new FileLoggerProvider(path));
    }
}
