using System;
using System.Data.SQLite;
using ARManager_REMAKE.Classes.Database.Models;

namespace ARManager_REMAKE.Classes.Database
{
    public class Database
    {
        private string ConnectionString = "Data Source=database.db";

        public void Init()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // Создание таблиц
                string createTablesQuery = @"
                    CREATE TABLE IF NOT EXISTS Customers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        ContactNumber TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Address TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Login TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        FirstName TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        ContactNumber TEXT NOT NULL,
                        Position TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Orders (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrderDate TEXT NOT NULL,
                        CustomerId INTEGER NOT NULL,
                        Status TEXT NOT NULL,   
                        ProblemDescription TEXT NOT NULL,
                        CompletionDate TEXT NOT NULL,       
                        EmployeeId INTEGER NOT NULL,
                        FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
                        FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
                    );
                    CREATE TABLE IF NOT EXISTS Services (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Description TEXT NOT NULL,
                        Price INTEGER NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS OrderDetails (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrderId INTEGER NOT NULL,
                        ServiceId INTEGER NOT NULL,
                        Quantity INTEGER NOT NULL,
                        FOREIGN KEY (OrderId) REFERENCES Orders(Id),
                        FOREIGN KEY (ServiceId) REFERENCES Services(Id)
                    );";

                using (var command = new SQLiteCommand(createTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Проверка, пуста ли таблица Employees
                string checkEmployeesQuery = "SELECT COUNT(*) FROM Employees";
                using (var command = new SQLiteCommand(checkEmployeesQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();
                    if (count == 0) // Если таблица пуста, создаем админа
                    {
                        string insertAdminQuery = @"
                            INSERT INTO Employees (Login, Password, FirstName, LastName, ContactNumber, Position) 
                            VALUES ('admin', 'admin', 'Admin', 'Admin', '1234567890', 'Administrator')";
                        using (var insertCommand = new SQLiteCommand(insertAdminQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public Employee GetEmployeeByLogin(string login)
        {
            Employee employee = null;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE Login = @login";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employee
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                FirstName = reader.GetString(3),
                                LastName = reader.GetString(4),
                                ContactNumber = reader.GetString(5),
                                Position = reader.GetString(6)
                            };
                        }
                    }
                }
            }
            return employee;
        }
    }
}