using TestTask.Models.Dbo;

namespace TestTask.Interfaces;

public interface IOperationService<T>:ICrudService<T>
{
    Task<IEnumerable<T>> GetByContainerIdAsync(Guid id);

}