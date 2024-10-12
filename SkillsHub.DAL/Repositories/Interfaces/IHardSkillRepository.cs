using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface IHardSkillRepository : IRepository<HardSkill>
{
    Task UpdateAsync (HardSkill entity);
    Task<bool> IsNameTakenAsync (string name);
}
