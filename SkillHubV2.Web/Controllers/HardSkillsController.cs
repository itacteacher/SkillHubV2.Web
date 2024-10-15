using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.Web.Filters;

namespace SkillsHubV2.Web.Controllers;

public class HardSkillsController : Controller
{
    private readonly ISkillsService<HardSkill> _hardSkillsService;
    private readonly IValidator<HardSkill> _validator;

    public HardSkillsController (ISkillsService<HardSkill> hardSkillsService, IValidator<HardSkill> validator)
    {
        _hardSkillsService = hardSkillsService;
        _validator = validator;
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

    [ServiceFilter(typeof(ModelValidationActionFilter))]
    [HttpPost]
    public async Task<IActionResult> Create (HardSkill skill)
    {
        var result = await _validator.ValidateAsync(skill);

        if (!result.IsValid)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(skill);
        }

        await _hardSkillsService.CreateAsync(skill);
        return RedirectToAction(nameof(Index));
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
