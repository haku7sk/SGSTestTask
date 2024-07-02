namespace TestTask.Interfaces;

public interface ICrudService<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(T entity);
    Task<T> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
}