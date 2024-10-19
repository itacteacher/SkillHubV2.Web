using SkillsHubV2.BLL.Interfaces;
using SkillsHubV2.DAL.Repositories.Interfaces;
using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.BLL.Services;
public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<IEnumerable<User>> GetAllAsync()
	{
		return await _userRepository.GetAllAsync();
	}

	public async Task<User> GetByIdAsync(int id)
	{
		return await _userRepository.GetByIdAsync(id);
	}

	public async Task<IEnumerable<User>> GetAllWithSkillsAsync()
	{
		return await _userRepository.GetUsersWithSkillsAsync();
	}

	public async Task CreateAsync(User user)
	{
		await _userRepository.CreateAsync(user);
	}

	public async Task UpdateAsync(User user)
	{
		_userRepository.UpdateAsync(user);
	}

	public async Task DeleteAsync(int id)
	{
		_userRepository.DeleteAsync(id);
	}
}
