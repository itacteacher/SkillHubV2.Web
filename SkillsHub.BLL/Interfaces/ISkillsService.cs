using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Interfaces;
public interface ISkillsService
{
    IEnumerable<Skill>? GetAllSkills ();
    Skill? GetSkillById (int id);
    void AddSkill (Skill skill);
    void UpdateSkill (Skill skill);
    void DeleteSkill (int id);
}
