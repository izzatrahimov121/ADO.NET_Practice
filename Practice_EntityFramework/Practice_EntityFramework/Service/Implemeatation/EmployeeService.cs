using Practice_EntityFramework.Core.Entities;
using Practice_EntityFramework.DataAccess;
using Practice_EntityFramework.Service.Interface;

namespace Practice_EntityFramework.Service.Implemeatation;

public class EmployeeService : IEmployee
{

    AppDbContext context = new();
    public async void CreateEmployee(string name, string surname, int salary)
    {
        Employee emp = new()
        {
            Name = name,
            Surname = surname,
            Salary = salary
        };
        await context.Employees.AddAsync(emp);
         context.SaveChanges();
        //await context.SaveChangesAsync();
    }



    public List<IEmployee> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public void GetEmployeeById(int Id)
    {
        throw new NotImplementedException();
    }

    public List<IEmployee> SearchEmployeeByName(string search)
    {
        throw new NotImplementedException();
    }
}
