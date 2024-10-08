using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface ISkillsRepository
{
    Task<Skill> GetByIdAsync(int id);
    Task<IEnumerable<Skill>> GetAllAsync();
    Task AddAsync(Skill skill);
    Task UpdateAsync(Skill skill);
    Task DeleteAsync(int id);
}
