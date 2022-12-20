using System.Data.SqlClient;
using Task2_ADO.Net_SQL_Connection.Exceptions;
using Task2_ADO.Net_SQL_Connection.Models;

string connectionString = @"Server=localhost;Database=Task2;Trusted_Connection=True";


try
{
    //Console.WriteLine(GetEmployeeById(43));

    //CreateEmployee("Test2", "Test2ov", 490);

    //foreach (var item in GetAllEmployees())
    //{
    //    Console.WriteLine($"Id: {item.Id}   " +
    //        $"Name: {item.Name}      " +
    //        $"Surname: {item.Surname}     " +
    //        $"Salary: {item.Salary}      ");
    //}

    foreach (var item in SearchEmployeeByName("A"))
    {
        Console.WriteLine($"Id: {item.Id}   " +
            $"Name: {item.Name}      " +
            $"Surname: {item.Surname}     " +
            $"Salary: {item.Salary}      ");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

List<Employees> GetAllEmployees()
{
    List<Employees> employees = new List<Employees>();
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = $"Select * from Employee";
        SqlCommand command = new(query, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Employees employee = new Employees()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Salary = (int)reader["Salary"]
                };
                employees.Add(employee);
            }
        }
        return employees;
    }

}
List<Employees> SearchEmployeeByName(string search)
{
    List<Employees> searchName = new List<Employees>();
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = $"Select * from Employee Where Name  Like '%' + @search+ '%'";
        SqlCommand command = new(query, connection);
        command.Parameters.AddWithValue("@search", search);
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Employees employee = new Employees()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Surname = (string)reader["Surname"],
                    Salary = (int)reader["Salary"]
                };
                searchName.Add(employee);
            }
        }
        return searchName;
    }
}
string GetEmployeeById(int search)
{
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();

        string query = $"Select * from Employee Where Id={search}";

        SqlCommand command = new(query, connection);
        SqlDataReader reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (search == (int)reader["Id"])
                {
                    return $"Id: {reader["Id"]}   " +
                        $"\nName: {reader["Name"]}   " +
                        $"\nSurname:{reader["Surname"]}   " +
                        $"\nSalary:{reader["Salary"]}";
                }
            }
        }
        else
        {
            throw new NotFoundException("data not found");
        }
        return "";
    }
}

void CreateEmployee(string name, string surname, int salary)
{
    using (SqlConnection connection = new(connectionString))
    {
        connection.Open();
        string query = $"INSERT INTO Employee VALUES ('{name}','{surname}',{salary}) ";
        SqlCommand command = new(query, connection);
        int result = command.ExecuteNonQuery();
        Console.WriteLine($"{result} rows affected");
    }
}
