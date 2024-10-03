using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.Web.Models;

namespace SkillsHubV2.Web.Controllers;
public class SkillsController : Controller
{
    // Временное хранилище для списка скиллов
    private static List<SkillViewModel> skills =
    [
        new SkillViewModel { Id = 1, Name = "C#", Description = "Advanced" },
        new SkillViewModel { Id = 2, Name = "ASP.NET", Description = "Intermediate" },
        new SkillViewModel { Id = 3, Name = "HTML/CSS", Description = "Beginner" }
    ];

    // GET: SkillsController
    public IActionResult Index()
    {
        ViewBag.Subtitle = "Programming in C#";
        ViewData["AnotherSubtitle"] = "ASP.NET Core MVC";

        return View(skills);
    }

    // GET: HomeController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Skills/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] SkillViewModel skill)
    {
        if (ModelState.IsValid)
        {
            skill.Id = skills.Count > 0 ? skills.Max(s => s.Id) + 1 : 1;
            skills.Add(skill);

            return RedirectToAction(nameof(Index));
        }

        return View(skill);
    }

    // GET: Skills/Edit/1
    public IActionResult Edit(int id)
    {
        var skill = skills.FirstOrDefault(s => s.Id == id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    // POST: Skills/Edit/1
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [FromForm] SkillViewModel skill)
    {
        var existingSkill = skills.FirstOrDefault(s => s.Id == id);

        if (existingSkill == null)
        {
            return NotFound();
        }

        existingSkill.Name = skill.Name;
        existingSkill.Description = skill.Description;

        return RedirectToAction(nameof(Index));
    }

    // GET: Skills/Delete/1
    public IActionResult Delete(int id)
    {
        var skill = skills.FirstOrDefault(s => s.Id == id);

        if (skill == null)
        {
            return NotFound();
        }

        return View(skill);
    }

    // POST: Skills/Delete/1
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var skill = skills.FirstOrDefault(s => s.Id == id);

        if (skill != null)
        {
            skills.Remove(skill);
        }

        return RedirectToAction(nameof(Index));
    }
}
