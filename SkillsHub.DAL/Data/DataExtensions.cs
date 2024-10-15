using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillsHubV2.DAL.Repositories;
using SkillsHubV2.DAL.Repositories.Interfaces;

namespace SkillsHubV2.DAL.Data;

public static class DataExtensions
{
    public static IServiceCollection AddDbWithRepositories (this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddSqlServer<ApplicationDbContext>(connectionString);

        services.AddScoped<ISoftSkillRepository, SoftSkillRepository>();
        services.AddScoped<IHardSkillRepository, HardSkillRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    //Only for Development env!
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}