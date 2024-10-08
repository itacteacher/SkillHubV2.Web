using SkillsHubV2.BLL.DTO;
using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;
public class SoftSkillsService : ISoftSkillsService
{
    private readonly ISoftSkillsRepository _repository;
    public SoftSkillsService(ISoftSkillsRepository repository)
    {
        _repository = repository;
    }
    public async Task<SoftSkill> CreateSoftSkillAsync (SoftSkill softSkill)
    {
        await _repository.AddAsync(softSkill);
        return softSkill;
    }

    public async Task<IEnumerable<SoftSkill>> GetAllSoftSkillsAsync ()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<SoftSkill> GetSoftSkillByIdAsync (int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<SoftSkill> UpdateSoftSkillAsync (SoftSkill softSkill)
    {
        await _repository.UpdateAsync(softSkill);
        return softSkill;
    }

    public async Task DeleteSoftSkillAsync (int id)
    {
        await _repository.DeleteAsync(id);
    }

    // Filter by Name
    public async Task<IEnumerable<SoftSkill>> GetSoftSkillsByNameAsync (string name)
    {
        var allSkills = await _repository.GetAllAsync();
        return allSkills.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    // Sort by Name
    public async Task<IEnumerable<SoftSkill>> GetSortedSoftSkillsAsync ()
    {
        var allSkills = await _repository.GetAllAsync();
        return allSkills.OrderBy(s => s.Name).ToList();
    }

    // Project to DTO
    public async Task<IEnumerable<SoftSkillDto>> GetSoftSkillDtosAsync ()
    {
        var allSkills = await _repository.GetAllAsync();
        return allSkills.Select(s => new SoftSkillDto
        {
            Id = s.Id,
            Name = s.Name
        }).ToList();
    }

    // Group by a property (e.g., count by skill type)
    public async Task<IDictionary<string, int>> GetSoftSkillCountByTypeAsync ()
    {
        var allSkills = await _repository.GetAllAsync();
        return allSkills
            .GroupBy(s => s.CommunicationStyle)
            .ToDictionary(g => g.Key, g => g.Count());
    }

}
