using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillsHubV2.DAL.Data;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
	private readonly ApplicationDbContext _context;
	private ILogger<UserRepository> _logger;

	public UserRepository(ApplicationDbContext context,
		ILogger<UserRepository> logger) : base(context, logger)
	{
		_context = context;
		_logger = logger;
	}

	public async Task UpdateAsync(User entity)
	{
		var originalEntity = await _context.Users
			.Include(u => u.Skills)
			.FirstOrDefaultAsync(u => u.Id == entity.Id);

		if (originalEntity != null)
		{
			originalEntity.Username = entity.Username;
			originalEntity.Email = entity.Email;

			originalEntity.Skills.Clear();

			foreach (var skill in entity.Skills)
			{
				originalEntity.Skills.Add(skill);
			}

			await _context.SaveChangesAsync();
			_logger.LogInformation("{Name} entity has been updated", nameof(User));
		}
	}

	public async Task<IEnumerable<User>> GetUsersWithSkillsAsync()
	{
		return await _context.Users
			.Include(u => u.Skills)
			.ToListAsync();
	}
}