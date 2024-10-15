using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories;
public class SoftSkillRepository : Repository<SoftSkill>, ISoftSkillRepository
{
    private ApplicationDbContext _context;
    private ILogger<SoftSkillRepository> _logger;

    public SoftSkillRepository(ApplicationDbContext context,
        ILogger<SoftSkillRepository> logger) : base(context, logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task UpdateAsync (SoftSkill entity)
    {
        var originalEntity = await _context.SoftSkills.FindAsync(entity.Id);
        
        if (originalEntity != null)
        {
            originalEntity.Name = entity.Name;
            originalEntity.Description = entity.Description;
            originalEntity.Level = entity.Level;
            originalEntity.CommunicationStyle = entity.CommunicationStyle;

            await _context.SaveChangesAsync();
            _logger.LogInformation("{Name} entity has been updated", nameof(SoftSkill));
        }
    }

    public async Task<bool> IsNameTakenAsync (string name)
    {
        return await _context.SoftSkills.AnyAsync(u => u.Name == name);
    }
}
