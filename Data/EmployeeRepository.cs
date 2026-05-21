using System.Collections.Generic;
using System.Data.SQLite;
using MaintenanceApp.Models;

namespace MaintenanceApp.Data
{
    public class EmployeeRepository
    {
        public List<Employee> GetAll()
        {
            var list = new List<Employee>();
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee
                        {
                            Id = System.Convert.ToInt32(reader["Id"]),
                            FullName = reader["FullName"].ToString(),
                            Position = reader["Position"].ToString(),
                            Phone = reader["Phone"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Employee emp)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Employees (FullName, Position, Phone) VALUES (@name, @pos, @phone)";
                cmd.Parameters.AddWithValue("@name", emp.FullName);
                cmd.Parameters.AddWithValue("@pos", emp.Position);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee emp)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Employees SET FullName=@name, Position=@pos, Phone=@phone WHERE Id=@id";
                cmd.Parameters.AddWithValue("@name", emp.FullName);
                cmd.Parameters.AddWithValue("@pos", emp.Position);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Employees WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}