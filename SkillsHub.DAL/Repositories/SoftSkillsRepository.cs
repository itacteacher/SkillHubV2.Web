using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repository;
public class SoftSkillsRepository : Repository<SoftSkill>, ISoftSkillsRepository
{
    private ApplicationDbContext _context;
    public SoftSkillsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
