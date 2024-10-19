using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web.Controllers;
public class HardSkillsController : Controller
{
	private readonly ISpecificSkillService<HardSkill> _hardSkillService;
	public HardSkillsController(ISpecificSkillService<HardSkill> hardSkillService)
	{
		_hardSkillService = hardSkillService;
	}

	public async Task<IActionResult> Index()
	{
		var skills = await _hardSkillService.GetAllAsync();
		return View(skills);
	}

	public async Task<IActionResult> Details(int id)
	{
		var skill = await _hardSkillService.GetByIdAsync(id);
		if (skill == null)
		{
			return NotFound();
		}
		return View(skill);
	}

	public IActionResult Create()
	{
		return View("Create", new HardSkill());
	}

	[HttpPost]
	public async Task<IActionResult> Create(HardSkill skill)
	{
		if (ModelState.IsValid)
		{
			await _hardSkillService.CreateAsync(skill);
			return RedirectToAction(nameof(Index));
		}

		return PartialView("Create", skill);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var skill = await _hardSkillService.GetByIdAsync(id);
		if (skill == null)
		{
			return NotFound();
		}
		return View(skill);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, HardSkill skill)
	{
		if (id != skill.Id)
		{
			return BadRequest();
		}
		if (ModelState.IsValid)
		{
			await _hardSkillService.UpdateAsync(skill);
			return RedirectToAction(nameof(Index));
		}
		return View(skill);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var skill = await _hardSkillService.GetByIdAsync(id);
		if (skill == null)
		{
			return NotFound();
		}
		return View(skill);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await _hardSkillService.DeleteAsync(id);
		return RedirectToAction(nameof(Index));
	}
}
