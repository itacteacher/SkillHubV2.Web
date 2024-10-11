using SkillsHubV2.Domain.Entities;

namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface IUserRepository : IRepository<User>
{
    Task UpdateAsync (User entity);
}
