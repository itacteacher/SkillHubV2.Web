using Microsoft.EntityFrameworkCore;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories;
public class HardSkillRepository : Repository<HardSkill>, IHardSkillRepository
{
    private ApplicationDbContext _context;
    public HardSkillRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateAsync (HardSkill entity)
    {
        var originalEntity = await _context.HardSkills.FindAsync(entity.Id);

        if (originalEntity != null)
        {
            originalEntity.Name = entity.Name;
            originalEntity.Description = entity.Description;
            originalEntity.Level = entity.Level;
            originalEntity.Technology = entity.Technology;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> IsNameTakenAsync (string name)
    {
        return await _context.HardSkills.AnyAsync(u => u.Name == name);
    }
}
