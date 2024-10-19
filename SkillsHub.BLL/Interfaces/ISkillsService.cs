using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Interfaces;
public interface ISkillService
{
	Task<IEnumerable<Skill>> GetAllSkillsAsync();
}
