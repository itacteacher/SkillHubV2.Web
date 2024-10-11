using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;
public class SoftSkillsService : ISkillsService<SoftSkill>
{
    private readonly ISoftSkillRepository _repository;
    public SoftSkillsService (ISoftSkillRepository repository) => _repository = repository;

    public Task<SoftSkill> CreateAsync (SoftSkill entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        return _repository.CreateAsync(entity);
    }

    public Task<SoftSkill> GetByIdAsync (int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<IEnumerable<SoftSkill>> GetAllAsync ()
    {
        return _repository.GetAllAsync();
    }

    public Task UpdateAsync (SoftSkill entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        return _repository.UpdateAsync(entity);
    }

    public Task DeleteAsync (int id)
    {
        return _repository.DeleteAsync(id);
    }
}
