using FluentValidation;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.BLL.Validators;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web;

public class Program
{
	public static async Task Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddDbWithRepositories(builder.Configuration);

		builder.Services.AddScoped<ISpecificSkillService<SoftSkill>, SoftSkillService>();
		builder.Services.AddScoped<ISpecificSkillService<HardSkill>, HardSkillService>();
		builder.Services.AddScoped<ISkillService, SkillService>();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IValidator<HardSkill>, HardSkillValidator>();

		builder.Services.AddControllersWithViews();


		var app = builder.Build();

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
			name: "users",
			pattern: "users/{id}/{*skills}",
			defaults: new { controller = "Users", action = "GetSkills" });

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Dashboard}/{action=Index}/{id?}");

		app.Run();
	}
}
