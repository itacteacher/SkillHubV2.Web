using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;
public class HardSkillsService : ISkillsService<HardSkill>
{
    private readonly IHardSkillRepository _repository;
    public HardSkillsService (IHardSkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<HardSkill> CreateAsync (HardSkill entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return await _repository.CreateAsync(entity);
    }

    public async Task<HardSkill> GetByIdAsync (int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<HardSkill>> GetAllAsync ()
    {
        return await _repository.GetAllAsync();
    }

    public async Task UpdateAsync (HardSkill entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync (int id)
    {
        await _repository.DeleteAsync(id);
    }
}
