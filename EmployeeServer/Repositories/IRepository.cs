namespace EmployeeServer.Repositories;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    Task<T?> GetByIdAsync(object id);
    Task<T> CreateAsync(T Entity);
    void Update(T Entity);
    Task DeleteAsync(object id);
    Task SaveAsync();
}