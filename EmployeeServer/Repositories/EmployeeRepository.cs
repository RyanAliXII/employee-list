using EmployeeServer.Data;
using EmployeeServer.Models;

namespace EmployeeServer.Repositories;
public class EmployeeRepository(AppDbContext dbContext) : EFRepository<Employee>(dbContext), IEmployeeRepository{
    protected readonly AppDbContext _dbContext = dbContext;
       
         
}
public interface IEmployeeRepository: IRepository<Employee>{}
   
