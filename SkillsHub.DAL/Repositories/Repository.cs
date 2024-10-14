using Microsoft.EntityFrameworkCore;
using SkillsHubV2.DAL.Repositories.Interfaces;

namespace SkillsHubV2.DAL.Repositories;
public class Repository<T> : IRepository<T> where T: class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository (DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> CreateAsync (T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<IEnumerable<T>> GetAllAsync ()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync (int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task DeleteAsync (int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
