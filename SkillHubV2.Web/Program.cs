using FluentValidation;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.BLL.Validators;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.Web.Extensions;
using SkillsHubV2.Web.Filters;
using SkillsHubV2.Web.Middleware;
using System.Diagnostics;

namespace SkillsHubV2.Web;

public class Program
{
    public static async Task Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbWithRepositories(builder.Configuration);

        builder.Services.AddScoped<ISkillsService<SoftSkill>, SoftSkillsService>();
        builder.Services.AddScoped<ISkillsService<HardSkill>, HardSkillsService>();
        builder.Services.AddScoped<IValidator<HardSkill>, HardSkillValidator>();

        builder.Services.AddScoped<ModelValidationActionFilter>();
        builder.Services.AddScoped<CustomExceptionFilter>();

        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.AddService<CustomExceptionFilter>();
        });

        builder.ConfigureCustomFileLogging();

        var app = builder.Build();

        //app.UseHttpLogging();
        //app.UseRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            await app.Services.InitializeDbAsync();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/SoftSkills/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=SoftSkills}/{action=Index}/{id?}");

        app.UseStatusCodePagesWithRedirects("/SoftSkills/Error");

        app.Use(async (context, next) =>
        {
            context.Items["RequestId"] = Activity.Current?.Id ?? context.TraceIdentifier;
            await next.Invoke();
        });

        app.Run();
    }
}
