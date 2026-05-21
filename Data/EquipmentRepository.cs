using System.Collections.Generic;
using System.Data.SQLite;
using MaintenanceApp.Models;

namespace MaintenanceApp.Data
{
    public class EquipmentRepository
    {
        public List<Equipment> GetAll()
        {
            var list = new List<Equipment>();
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Equipment";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Equipment
                        {
                            Id = System.Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Location = reader["Location"].ToString(),
                            Type = reader["Type"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Equipment eq)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Equipment (Name, Location, Type) VALUES (@name, @loc, @type)";
                cmd.Parameters.AddWithValue("@name", eq.Name);
                cmd.Parameters.AddWithValue("@loc", eq.Location);
                cmd.Parameters.AddWithValue("@type", eq.Type);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Equipment eq)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Equipment SET Name=@name, Location=@loc, Type=@type WHERE Id=@id";
                cmd.Parameters.AddWithValue("@name", eq.Name);
                cmd.Parameters.AddWithValue("@loc", eq.Location);
                cmd.Parameters.AddWithValue("@type", eq.Type);
                cmd.Parameters.AddWithValue("@id", eq.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Equipment WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}