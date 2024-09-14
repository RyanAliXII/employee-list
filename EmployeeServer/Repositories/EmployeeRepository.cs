using EmployeeServer.Data;
using EmployeeServer.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeServer.Repositories;
public class EmployeeRepository(AppDbContext dbContext) : EFRepository<Employee>(dbContext), IEmployeeRepository{
    protected readonly AppDbContext _dbContext = dbContext;
    public IEnumerable<Employee> GetEmployeesOrderedByCreatedAtDesc(){
        return _dbContext.Employee.OrderByDescending(emp=> emp.CreatedAt);
    }
    public async Task<bool> IsEmailExistsAsync(string email)
    {
        return await _dbContext.Employee.AnyAsync(u => u.Email == email);
    }

    public async Task<bool> IsSSNumberExistsAsync(string ssNumber)
    {
        return await _dbContext.Employee.AnyAsync(u => u.SSNumber == ssNumber);
    }

    public async Task<bool> IsTINExistsAsync(string tin)
    {
        return await _dbContext.Employee.AnyAsync(u => u.TIN == tin);
    }

    public async Task<bool> IsMIDNumberExistsAsync(string midNumber)
    {
        return await _dbContext.Employee.AnyAsync(u => u.MIDNumber == midNumber);
    }

    public async Task<bool> IsPhilHealthNumberExistsAsync(string philHealthNumber)
    {
        return await _dbContext.Employee.AnyAsync(u => u.PhilHealthNumber == philHealthNumber);
    }

    public async Task<bool> IsMobileNumberExistsAsync(string mobileNumber)
    {
        return await _dbContext.Employee.AnyAsync(u => u.MobileNumber == mobileNumber);
    }

    public async Task<bool> IsEmailForCurrentEmployeeAsync(string email, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.Email == email && u.Id != employeeId);
    }

    public async Task<bool> IsSSNumberForCurrentEmployeeAsync(string ssNumber, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.SSNumber == ssNumber && u.Id != employeeId);
    }

    public async Task<bool> IsTINForCurrentEmployeeAsync(string tin, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.TIN == tin && u.Id != employeeId);
    }

    public async Task<bool> IsMIDNumberForCurrentEmployeeAsync(string midNumber, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.MIDNumber == midNumber && u.Id != employeeId);
    }

    public async Task<bool> IsPhilHealthNumberForCurrentEmployeeAsync(string philHealthNumber, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.PhilHealthNumber == philHealthNumber && u.Id != employeeId);
    }

    public async Task<bool> IsMobileNumberForCurrentEmployeeAsync(string mobileNumber, Guid employeeId)
    {
        return await _dbContext.Employee.AnyAsync(u => u.MobileNumber == mobileNumber && u.Id != employeeId);
    }
    
}
public interface IEmployeeRepository: IRepository<Employee>{
    public IEnumerable<Employee> GetEmployeesOrderedByCreatedAtDesc();
    Task<bool> IsEmailExistsAsync(string email);
    Task<bool> IsSSNumberExistsAsync(string ssNumber);
    Task<bool> IsTINExistsAsync(string tin);
    Task<bool> IsMIDNumberExistsAsync(string midNumber);
    Task<bool> IsPhilHealthNumberExistsAsync(string philHealthNumber);
    Task<bool> IsMobileNumberExistsAsync(string mobileNumber);
    Task<bool> IsEmailForCurrentEmployeeAsync(string email, Guid employeeId);
    Task<bool> IsSSNumberForCurrentEmployeeAsync(string ssNumber, Guid employeeId);
    Task<bool> IsTINForCurrentEmployeeAsync(string tin, Guid employeeId);
    Task<bool> IsMIDNumberForCurrentEmployeeAsync(string midNumber, Guid employeeId);
    Task<bool> IsPhilHealthNumberForCurrentEmployeeAsync(string philHealthNumber, Guid employeeId);
    Task<bool> IsMobileNumberForCurrentEmployeeAsync(string mobileNumber, Guid employeeId);
}
   
