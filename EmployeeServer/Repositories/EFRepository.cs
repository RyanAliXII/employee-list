using EmployeeServer.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServer.Repositories;
public class EFRepository<T>: IRepository<T> where T: class{
    private AppDbContext _dbContext;
    private DbSet<T> _table;
    public EFRepository(AppDbContext dbContext){
        _dbContext = dbContext;
        _table = dbContext.Set<T>();
    }
    public virtual async Task<T> CreateAsync(T entity){
        await _table.AddAsync(entity);
        return  entity;
    }
    public virtual IEnumerable<T> GetAll(){
        return _table.ToList();
    }
    public virtual void Update(T entity){
    }
    public virtual async Task<T?> GetByIdAsync(object id)
    {
        return await _table.FindAsync(id);
    }
    public virtual async Task DeleteAsync(object id){
        var ent =  await _table.FindAsync(id);
        if(ent != null){
            _table.Remove(ent);
        }
    }
    public virtual async Task SaveAsync(){
        await _dbContext.SaveChangesAsync();
    }
}   