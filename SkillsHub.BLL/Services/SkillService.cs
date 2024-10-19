using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;

public class SkillService : ISkillService
{
	private readonly ISkillRepository _skillRepository;

	public SkillService(ISkillRepository skillRepository)
	{
		_skillRepository = skillRepository;
	}

	public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
	{
		return await _skillRepository.GetAllSkillsAsync().ConfigureAwait(false);
	}
}
