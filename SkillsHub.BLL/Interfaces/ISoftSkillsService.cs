using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Interfaces;
public interface ISoftSkillsService
{
    Task<SoftSkill> CreateSoftSkillAsync (SoftSkill softSkill);
    Task<SoftSkill> GetSoftSkillByIdAsync (int id);
    Task<IEnumerable<SoftSkill>> GetAllSoftSkillsAsync ();
    Task<SoftSkill> UpdateSoftSkillAsync (SoftSkill softSkill);
    Task DeleteSoftSkillAsync (int id);
}
