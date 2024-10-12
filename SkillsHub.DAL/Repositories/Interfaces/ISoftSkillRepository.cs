using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface ISoftSkillRepository : IRepository<SoftSkill>
{
    Task UpdateAsync (SoftSkill entity);
    Task<bool> IsNameTakenAsync (string name);
}
