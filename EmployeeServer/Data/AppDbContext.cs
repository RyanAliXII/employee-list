
using EmployeeServer.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeeServer.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
        public DbSet<Employee> Employee { get; set; }
       
}
