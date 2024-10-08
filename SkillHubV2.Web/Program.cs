using Microsoft.EntityFrameworkCore;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.DAL.Repository;

namespace SkillsHubV2.Web;

public class Program
{
    public static void Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ISoftSkillsRepository, SoftSkillsRepository>();
        builder.Services.AddScoped<ISkillsRepository, SkillsRepository>();
        builder.Services.AddScoped<ISkillsService, StubSkillsService>();
        builder.Services.AddScoped<ISoftSkillsService, SoftSkillsService>();

        var app = builder.Build();

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
            pattern: "{controller=Skills}/{action=Index}/{id?}");

        app.Run();
    }
}
