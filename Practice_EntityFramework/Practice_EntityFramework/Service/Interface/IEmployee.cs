namespace Practice_EntityFramework.Service.Interface;

public interface IEmployee
{
    List<IEmployee> GetAllEmployees();
    void GetEmployeeById(int Id);
    void CreateEmployee(string name, string surname, int salary);
    List<IEmployee> SearchEmployeeByName(string search);
}
