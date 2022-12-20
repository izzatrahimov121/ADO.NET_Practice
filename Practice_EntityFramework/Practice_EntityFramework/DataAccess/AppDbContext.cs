using Microsoft.EntityFrameworkCore;
using Practice_EntityFramework.Core.Entities;

namespace Practice_EntityFramework.DataAccess;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=B3-16;Database=EmployeeDB;Trusted_Connection=true;");
    }
    public DbSet<Employee> Employees { get; set; }
}

