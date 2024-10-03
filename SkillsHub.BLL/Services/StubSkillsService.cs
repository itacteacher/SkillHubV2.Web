using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;
public class StubSkillsService : ISkillsService
{
    private static List<Skill> skills =
    [
        new Skill { Id = 1, Name = "C#", Description = "Advanced" },
        new Skill { Id = 2, Name = "ASP.NET", Description = "Intermediate" },
        new Skill { Id = 3, Name = "HTML/CSS", Description = "Beginner" }
    ];

    public IEnumerable<Skill> GetAllSkills ()
    {
        return skills;
    }

    public Skill? GetSkillById (int id)
    {
        return skills?.FirstOrDefault(s => s.Id == id);
    }

    public void AddSkill (Skill skill)
    {
        skill.Id = skills.Count > 0 ? skills.Max(s => s.Id) + 1 : 1;
        skills.Add(skill);
    }

    public void DeleteSkill (int id)
    {
        var skill = GetSkillById(id);

        if (skill != null)
        {
            skills.Remove(skill);
        }
    }

    public void UpdateSkill (Skill skill)
    {
        var existingSkill = GetSkillById(skill.Id);

        if (existingSkill != null)
        {
            existingSkill.Name = skill.Name;
            existingSkill.Description = skill.Description;
        }
    }
}
