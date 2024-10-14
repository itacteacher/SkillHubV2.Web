using FluentValidation;
using Serilog;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.BLL.Validators;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web;

public class Program
{
    public static async Task Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbWithRepositories(builder.Configuration);

        builder.Services.AddScoped<ISkillsService<SoftSkill>, SoftSkillsService>();
        builder.Services.AddScoped<ISkillsService<HardSkill>, HardSkillsService>();
        builder.Services.AddScoped<IValidator<HardSkill>, HardSkillValidator>();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        builder.Host.UseSerilog();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            await app.Services.InitializeDbAsync();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=SoftSkills}/{action=Index}/{id?}");

        app.Run();
    }
}
