using System;
using System.Data.SQLite;
using System.IO;

namespace MaintenanceApp.Data
{
    public static class Database
    {
        private static readonly string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "maintenance.db");
        public static string ConnectionString => $"Data Source={dbPath};Version=3;";

        public static void Initialize()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    CREATE TABLE IF NOT EXISTS Equipment (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Location TEXT,
                        Type TEXT
                    );
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Position TEXT,
                        Phone TEXT
                    );
                    CREATE TABLE IF NOT EXISTS Requests (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Description TEXT,
                        Status TEXT DEFAULT 'Новая',
                        Priority TEXT DEFAULT 'Средний',
                        CreatedAt TEXT,
                        CompletedAt TEXT,
                        EquipmentId INTEGER,
                        EmployeeId INTEGER,
                        FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id),
                        FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
                    );";
                cmd.ExecuteNonQuery();
            }
        }
    }
}