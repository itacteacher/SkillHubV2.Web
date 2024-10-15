namespace SkillsHubV2.DAL.Repositories.Interfaces;
public interface IRepository<T> where T : class
{
    Task<T> CreateAsync (T entity);
    Task<IEnumerable<T>> GetAllAsync ();
    Task<T?> GetByIdAsync (int id);
    Task DeleteAsync (int id);
}
