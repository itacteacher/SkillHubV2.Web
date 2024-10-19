using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.Web.Models;
using System.Diagnostics;

namespace SkillsHubV2.Web.Controllers;

public class SoftSkillsController : Controller
{
	private readonly ISpecificSkillService<SoftSkill> _softSkillService;
	private readonly ILogger<SoftSkillsController> _logger;

	public SoftSkillsController(ISpecificSkillService<SoftSkill> softSkillService,
		ILogger<SoftSkillsController> logger)
	{
		_softSkillService = softSkillService;
		_logger = logger;
	}

	public async Task<IActionResult> Index()
	{
		try
		{
			var skills = await _softSkillService.GetAllAsync();

			return View(skills);
		}
		catch (Exception ex)
		{
			return StatusCode(500, "Произошла ошибка");
		}
	}

	public async Task<IActionResult> Details(int id)
	{
		var skill = await _softSkillService.GetByIdAsync(id);

		if (skill == null)
		{
			return NotFound();
		}

		return View(skill);
	}

	public IActionResult Create()
	{
		return PartialView("Create", new SoftSkill());
	}

	[HttpPost]
	public async Task<IActionResult> Create(SoftSkill skill)
	{
		if (ModelState.IsValid)
		{
			await _softSkillService.CreateAsync(skill);

			return RedirectToAction(nameof(Index));
		}

		return PartialView("Create", skill);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var skill = await _softSkillService.GetByIdAsync(id);

		if (skill == null)
		{
			return NotFound();
		}

		return View(skill);
	}

	[HttpPost]
	public async Task<IActionResult> Edit(int id, SoftSkill skill)
	{
		if (id != skill.Id)
		{
			return BadRequest();
		}

		if (ModelState.IsValid)
		{
			await _softSkillService.UpdateAsync(skill);
			return RedirectToAction(nameof(Index));
		}

		return View(skill);
	}

	public async Task<IActionResult> Delete(int id)
	{
		var skill = await _softSkillService.GetByIdAsync(id);

		if (skill == null)
		{
			return NotFound();
		}

		return View(skill);
	}

	[HttpPost]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await _softSkillService.DeleteAsync(id);

		return RedirectToAction(nameof(Index));
	}

	public IActionResult Error()
	{
		var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

		var error = new ErrorViewModel
		{
			RequestId = requestId
		};

		_logger.LogError("An error occurred. RequestId: {Id}", requestId);

		return View("Error", error);
	}
}
