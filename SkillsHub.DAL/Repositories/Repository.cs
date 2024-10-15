using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillsHubV2.DAL.Repositories.Interfaces;

namespace SkillsHubV2.DAL.Repositories;
public class Repository<T> : IRepository<T> where T: class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly ILogger<Repository<T>> _logger;

    public Repository (DbContext context, ILogger<Repository<T>> logger)
    {
        _logger = logger;
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> CreateAsync (T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();

        _logger.LogInformation("{Name} entity has been saved", typeof(T).Name);
        return entity;
    }
    public async Task<IEnumerable<T>> GetAllAsync ()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<T?> GetByIdAsync (int id)
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
            _logger.LogInformation("{Name} entity has been deleted", typeof(T).Name);
        }
    }
}
