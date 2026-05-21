using System;
using System.Collections.Generic;
using System.Data.SQLite;
using MaintenanceApp.Models;

namespace MaintenanceApp.Data
{
    public class RequestRepository
    {
        public List<Request> GetAll()
        {
            var list = new List<Request>();
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    SELECT r.Id, r.Title, r.Description, r.Status, r.Priority,
                           r.CreatedAt, r.CompletedAt, r.EquipmentId, r.EmployeeId,
                           e.Name AS EquipmentName, emp.FullName AS EmployeeName
                    FROM Requests r
                    LEFT JOIN Equipment e ON r.EquipmentId = e.Id
                    LEFT JOIN Employees emp ON r.EmployeeId = emp.Id";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Request
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            Status = reader["Status"].ToString(),
                            Priority = reader["Priority"].ToString(),
                            CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()),
                            CompletedAt = reader["CompletedAt"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader["CompletedAt"].ToString()),
                            EquipmentId = Convert.ToInt32(reader["EquipmentId"]),
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            EquipmentName = reader["EquipmentName"].ToString(),
                            EmployeeName = reader["EmployeeName"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Request r)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Requests (Title, Description, Status, Priority, CreatedAt, CompletedAt, EquipmentId, EmployeeId)
                            VALUES (@title, @desc, @status, @priority, @created, @completed, @eqId, @empId)";
                cmd.Parameters.AddWithValue("@title", r.Title);
                cmd.Parameters.AddWithValue("@desc", r.Description);
                cmd.Parameters.AddWithValue("@status", r.Status);
                cmd.Parameters.AddWithValue("@priority", r.Priority);
                cmd.Parameters.AddWithValue("@created", r.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@completed", r.CompletedAt.HasValue ? r.CompletedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@eqId", r.EquipmentId);
                cmd.Parameters.AddWithValue("@empId", r.EmployeeId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Request r)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"UPDATE Requests SET Title=@title, Description=@desc, Status=@status,
                                    Priority=@priority, CompletedAt=@completed, EquipmentId=@eqId, EmployeeId=@empId
                                    WHERE Id=@id";
                cmd.Parameters.AddWithValue("@title", r.Title);
                cmd.Parameters.AddWithValue("@desc", r.Description);
                cmd.Parameters.AddWithValue("@status", r.Status);
                cmd.Parameters.AddWithValue("@priority", r.Priority);
                cmd.Parameters.AddWithValue("@completed", r.CompletedAt.HasValue ? r.CompletedAt.Value.ToString("yyyy-MM-dd HH:mm:ss") : (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@eqId", r.EquipmentId);
                cmd.Parameters.AddWithValue("@empId", r.EmployeeId);
                cmd.Parameters.AddWithValue("@id", r.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = new SQLiteConnection(Database.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Requests WHERE Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}