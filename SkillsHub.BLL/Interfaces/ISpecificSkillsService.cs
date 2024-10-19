namespace SkillsHubV2.BLL.Interfaces;
public interface ISpecificSkillService<T> where T : class
{
	Task<T> CreateAsync(T entity);
	Task<T> GetByIdAsync(int id);
	Task<IEnumerable<T>> GetAllAsync();
	Task UpdateAsync(T entity);
	Task DeleteAsync(int id);

	Task<bool> IsNameTakenAsync(string name);
}
