using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;

namespace SkillsHubV2.Web.Controllers;
public class DashboardController : Controller
{
	private readonly ISkillService _skillService;
	private readonly IUserService _userService;

	public DashboardController(IUserService userService, ISkillService skillService)
	{
		_skillService = skillService;
		_userService = userService;
	}

	public async Task<IActionResult> Index()
	{
		var users = await _userService.GetAllWithSkillsAsync();
		var skills = await _skillService.GetAllSkillsAsync();

		ViewData["AllSkills"] = skills;

		return View(users);
	}
}
