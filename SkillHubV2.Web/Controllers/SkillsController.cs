using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.BLL.Services;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.Web.Models;

namespace SkillsHubV2.Web.Controllers;
public class SkillsController : Controller
{
    private readonly ISkillsService _skillService;
    public SkillsController(ISkillsService skillService)
    {
        _skillService = skillService;
    }

    // GET: SkillsController
    public IActionResult Index()
    {
        var skills = _skillService.GetAllSkills();

        var skillViewModels = skills.Select(skill => new SkillViewModel
        {
            Id = skill.Id,
            Name = skill.Name,
            Description = skill.Description
        }).ToList();

        return View(skillViewModels);
    }

    public IActionResult Create ()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create ([FromForm] SkillViewModel skill)
    {
        if (ModelState.IsValid)
        {
            _skillService.AddSkill(new Skill
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description
            });

            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    public IActionResult Edit (int id)
    {
        var skill = _skillService.GetSkillById(id);

        if (skill == null)
        {
            return NotFound();
        }

        var skillViewModel = new SkillViewModel
        {
            Id = skill.Id,
            Name = skill.Name,
            Description = skill.Description
        };

        return View(skillViewModel);
    }

    [HttpPost]
    public IActionResult Edit (int id, [FromForm] SkillViewModel skill)
    {
        if (id != skill.Id)
        {
            return NotFound();
        }

        var existingSkill = _skillService.GetSkillById(id);

        if (existingSkill == null)
        {
            return NotFound();
        }

        existingSkill.Name = skill.Name;
        existingSkill.Description = skill.Description;

        _skillService.UpdateSkill(existingSkill);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete (int id)
    {
        var skill = _skillService.GetSkillById(id);

        if (skill == null)
        {
            return NotFound();
        }

        var skillViewModel = new SkillViewModel
        {
            Id = skill.Id,
            Name = skill.Name,
            Description = skill.Description
        };

        return View(skillViewModel);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed (int id)
    {
        var skill = _skillService.GetSkillById(id);

        if (skill != null)
        {
            _skillService.DeleteSkill(skill.Id);
        }

        return RedirectToAction(nameof(Index));
    }
}
