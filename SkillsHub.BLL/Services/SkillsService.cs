using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.Domain.Entities;
using SkillsHubV2.DAL.Repositories.Interfaces;

namespace SkillsHubV2.BLL.Services;
public class SkillsService : ISkillsService
{
    private readonly ISkillsRepository _repository;

    public SkillsService(ISkillsRepository repository)
    {
        _repository = repository;
    }

    public void AddSkill (Skill skill)
    {
        throw new NotImplementedException();
    }

    public void DeleteSkill (int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Skill>? GetAllSkills ()
    {
        throw new NotImplementedException();
    }

    public Skill? GetSkillById (int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateSkill (Skill skill)
    {
        throw new NotImplementedException();
    }
}
