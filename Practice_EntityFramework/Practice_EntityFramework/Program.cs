using Practice_EntityFramework.Core.Entities;
using Practice_EntityFramework.DataAccess;
using Practice_EntityFramework.Service.Implemeatation;

EmployeeService EmployeeService = new EmployeeService();
EmployeeService.CreateEmployee("Izzet", "Rehimov", 2342);

//AppDbContext context = new();
//Employee employee = new()
//{
//    Name = "dhsadfa",
//    Surname = "Microsoft",
//    Salary = 546
//};

////context.Employees.Add(employee);
//context.SaveChanges();
