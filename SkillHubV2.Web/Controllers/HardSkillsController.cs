using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web.Controllers;

public class HardSkillsController : Controller
{
    private readonly ISkillsService<HardSkill> _hardSkillsService;

    public HardSkillsController (ISkillsService<HardSkill> hardSkillsService)
    {
        _hardSkillsService = hardSkillsService;
    }

    public async Task<IActionResult> Index ()
    {
        var skills = await _hardSkillsService.GetAllAsync();
        return View(skills);
    }

    public async Task<IActionResult> Details (int id)
    {
        var skill = await _hardSkillsService.GetByIdAsync(id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    public IActionResult Create ()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create (HardSkill skill)
    {
        if (ModelState.IsValid)
        {
            await _hardSkillsService.CreateAsync(skill);
            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    public async Task<IActionResult> Edit (int id)
    {
        var skill = await _hardSkillsService.GetByIdAsync(id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    [HttpPost]
    public async Task<IActionResult> Edit (int id, HardSkill skill)
    {
        if (id != skill.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _hardSkillsService.UpdateAsync(skill);
            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    public async Task<IActionResult> Delete (int id)
    {
        var skill = await _hardSkillsService.GetByIdAsync(id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed (int id)
    {
        await _hardSkillsService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
