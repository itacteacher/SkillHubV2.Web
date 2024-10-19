using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface ISkillRepository
{
    Task<IEnumerable<Skill>> GetAllSkillsAsync ();
}
