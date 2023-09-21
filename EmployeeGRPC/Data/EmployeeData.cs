using EmployeeGRPC.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeGRPC.Data;
public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions) : base(dbContextOptions) { }
    public DbSet<Employee> EmployeeList => Set<Employee>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                Name = "Abc",
                Address = "makarapura",
                Email = "abc@gmail.com"
            },
            new Employee
            {
                Id = 2,
                Name = "xyz",
                Address = "bustand",
                Email = "xyz@gmail.com"
            },
            new Employee
            {
                Id = 3,
                Name = "ram",
                Address = "changa",
                Email = "ram@gmail.com"
            },
            new Employee
            {
                Id = 4,
                Name = "shyam",
                Address = "changa",
                Email = "shyam@gmail.com"
            },
            new Employee
            {
                Id = 5,
                Name = "Test",
                Address = "Testpura",
                Email = "test@gmail.com"
            }


            );
    }
}