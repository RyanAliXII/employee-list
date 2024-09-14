using EmployeeServer.Data;
using EmployeeServer.Models;

namespace EmployeeServer.Repositories;
public class EmployeeRepository(AppDbContext dbContext) : EFRepository<Employee>(dbContext), IEmployeeRepository{
    protected readonly AppDbContext _dbContext = dbContext;
    public IEnumerable<Employee> GetEmployeesOrderedByCreatedAtDesc(){
        return _dbContext.Employee.OrderByDescending(emp=> emp.CreatedAt);
    }
         
}
public interface IEmployeeRepository: IRepository<Employee>{
    public IEnumerable<Employee> GetEmployeesOrderedByCreatedAtDesc();
}
   
