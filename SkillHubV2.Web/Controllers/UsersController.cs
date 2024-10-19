using Microsoft.AspNetCore.Mvc;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.Web.Controllers;
public class UsersController : Controller
{
    public IActionResult Index ()
    {
        var users = new List<User> {
            new User
            {
                Id = 1,
                Username = "johndoe",
                Email = "johndoe@example.com"
            },
            new User
            {
                Id = 2,
                Username = "janedoe",
                Email = "janedoe@example.com"
            }
        };

        return View(users);
    }

    public IActionResult GetSkills (int id, string skills)
    {
        var usersSkills = new Dictionary<int, List<string>>
        {
            { 1, new List<string> { "Communication", "Teamwork" } },
            { 2, new List<string> { "Leadership", "Problem Solving" } }
        };

        if (string.IsNullOrEmpty(skills))
        {
            if (usersSkills.TryGetValue(id, out var softSkills))
            {
                ViewBag.Id = id;
                ViewBag.Skills = softSkills;
                return View("SkillsList");
            }

            return Content("User not found");
        }

        var skillList = skills.Split('/');

        if (usersSkills.ContainsKey(id))
        {
            var foundSkills = new List<string>();
            var notFoundSkills = new List<string>();

            foreach (var skill in skillList)
            {
                if (usersSkills[id].Contains(skill))
                {
                    foundSkills.Add(skill);
                }
                else
                {
                    notFoundSkills.Add(skill);
                }
            }

            ViewBag.Id = id;
            ViewBag.FoundSkills = foundSkills;
            ViewBag.NotFoundSkills = notFoundSkills;
            return View("SkillsDetails");
        }

        return Content("User or skills not found");
    }
}
