using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web.Controllers;
public class SoftSkillsController : Controller
{
    private readonly ISkillsService<SoftSkill> _softSkillsService;

    public SoftSkillsController (ISkillsService<SoftSkill> softSkillsService)
    {
        _softSkillsService = softSkillsService;
    }

    public async Task<IActionResult> Index ()
    {
        var skills = await _softSkillsService.GetAllAsync();

        return View(skills);
    }

    public async Task<IActionResult> Details (int id)
    {
        var skill = await _softSkillsService.GetByIdAsync(id);

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
    public async Task<IActionResult> Create (SoftSkill skill)
    {
        if (ModelState.IsValid)
        {
            await _softSkillsService.CreateAsync(skill);

            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    public async Task<IActionResult> Edit (int id)
    {
        var skill = await _softSkillsService.GetByIdAsync(id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    [HttpPost]
    public async Task<IActionResult> Edit (int id, SoftSkill skill)
    {
        if (id != skill.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _softSkillsService.UpdateAsync(skill);
            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    public async Task<IActionResult> Delete (int id)
    {
        var skill = await _softSkillsService.GetByIdAsync(id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed (int id)
    {
        await _softSkillsService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
