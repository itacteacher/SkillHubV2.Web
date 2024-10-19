using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Interfaces;

public interface IUserService
{
	Task<IEnumerable<User>> GetAllAsync();
	Task<User> GetByIdAsync(int id);
	Task<IEnumerable<User>> GetAllWithSkillsAsync();
	Task CreateAsync(User user);
	Task UpdateAsync(User user);
	Task DeleteAsync(int id);
}