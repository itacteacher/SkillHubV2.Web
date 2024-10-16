﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.Web.Models;
using System.Diagnostics;

namespace SkillsHubV2.Web.Controllers;

public class SoftSkillsController : Controller
{
    private readonly ISkillsService<SoftSkill> _softSkillsService;
    private readonly ILogger<SoftSkillsController> _logger;

    public SoftSkillsController (ISkillsService<SoftSkill> softSkillsService, 
        ILogger<SoftSkillsController> logger)
    {
        _softSkillsService = softSkillsService;
        _logger = logger;
    }

    public async Task<IActionResult> Index ()
    {
        try
        {
            var skills = await _softSkillsService.GetAllAsync();

            return View(skills);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Произошла ошибка");
        }
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
        if (await _softSkillsService.IsNameTakenAsync(skill.Name))
        {
            ModelState.AddModelError("Name", "Name is taken.");
            return View(skill);
        }

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

    public IActionResult Error ()
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
