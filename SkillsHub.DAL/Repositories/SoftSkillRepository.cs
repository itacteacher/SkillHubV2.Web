using Microsoft.EntityFrameworkCore;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories;
public class SoftSkillRepository : Repository<SoftSkill>, ISoftSkillRepository
{
    private ApplicationDbContext _context;
    public SoftSkillRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateAsync (SoftSkill entity)
    {
        var originalEntity = await _context.SoftSkills.FindAsync(entity.Id).ConfigureAwait(false);
        
        if (originalEntity != null)
        {
            originalEntity.Name = entity.Name;
            originalEntity.Description = entity.Description;
            originalEntity.Level = entity.Level;
            originalEntity.CommunicationStyle = entity.CommunicationStyle;

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }

    public async Task<bool> IsNameTakenAsync (string name)
    {
        return await _context.SoftSkills.AnyAsync(u => u.Name == name);
    }
}
