using Microsoft.EntityFrameworkCore;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories;
public class SkillsRepository : ISkillsRepository
{
    private readonly ApplicationDbContext _context;

    public SkillsRepository (ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Skill> GetByIdAsync (int id)
    {
        return await _context.Set<Skill>().FindAsync(id);
    }

    public async Task<IEnumerable<Skill>> GetAllAsync ()
    {
        return await _context.Set<Skill>().ToListAsync();
    }

    public async Task AddAsync (Skill skill)
    {
        await _context.Set<Skill>().AddAsync(skill);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync (Skill skill)
    {
        _context.Set<Skill>().Update(skill);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync (int id)
    {
        var skill = await _context.Set<Skill>().FindAsync(id);

        if (skill != null)
        {
            _context.Set<Skill>().Remove(skill);

            await _context.SaveChangesAsync();
        }
    }
}
