using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using ARManager_REMAKE.Classes.Database.Models;
using ARManager_REMAKE.Forms.PickerForms;
using Newtonsoft.Json;

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
                    CompletionDate TEXT,
                    EmployeeId INTEGER NOT NULL,
                    DeviceType TEXT,
                    DeviceModel TEXT,
                    DeviceSerialNumber TEXT,
                    TotalCost INTEGER NOT NULL,
                    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
                    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
                );
                CREATE TABLE IF NOT EXISTS Services (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Price INTEGER NOT NULL
                );
                CREATE TABLE IF NOT EXISTS OrderDetails (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrderId INTEGER NOT NULL,
                    ServiceId INTEGER NOT NULL,
                    Quantity INTEGER NOT NULL,
                    TotalCost INTEGER NOT NULL,
                    FOREIGN KEY (OrderId) REFERENCES Orders(Id),
                    FOREIGN KEY (ServiceId) REFERENCES Services(Id)
                );";

                using (var command = new SQLiteCommand(createTablesQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string checkEmployeesQuery = "SELECT COUNT(*) FROM Employees";
                using (var command = new SQLiteCommand(checkEmployeesQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertAdminQuery = @"
                        INSERT INTO Employees (Login, Password, FirstName, LastName, ContactNumber, Position) 
                        VALUES ('admin', 'admin', 'Admin', 'Admin', '1234567890', 'Администратор')";
                        using (var insertCommand = new SQLiteCommand(insertAdminQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public List<Order> GetOrders(Employee user)
        {
            var orders = new List<Order>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query;
                if (user == null || user.Position == "Администратор" || user.Position == "Менеджер")
                {
                    query = @"
                        SELECT 
                            o.Id, o.OrderDate, o.Status, o.DeviceType, o.DeviceModel, 
                            o.DeviceSerialNumber, o.ProblemDescription, o.CompletionDate, 
                            o.CustomerId, o.EmployeeId, o.TotalCost,
                            c.FirstName AS CustomerFirstName, c.LastName AS CustomerLastName,
                            e.FirstName AS EmployeeFirstName, e.LastName AS EmployeeLastName
                        FROM Orders o
                        JOIN Customers c ON o.CustomerId = c.Id
                        JOIN Employees e ON o.EmployeeId = e.Id";
                }
                else
                {
                    query = @"
                        SELECT 
                            o.Id, o.OrderDate, o.Status, o.DeviceType, o.DeviceModel, 
                            o.DeviceSerialNumber, o.ProblemDescription, o.CompletionDate, 
                            o.CustomerId, o.EmployeeId, o.TotalCost,
                            c.FirstName AS CustomerFirstName, c.LastName AS CustomerLastName,
                            e.FirstName AS EmployeeFirstName, e.LastName AS EmployeeLastName
                        FROM Orders o
                        JOIN Customers c ON o.CustomerId = c.Id
                        JOIN Employees e ON o.EmployeeId = e.Id
                        WHERE o.EmployeeId = @EmployeeId";
                }

                using (var command = new SQLiteCommand(query, connection))
                {
                    if (user != null && user.Position != "Администратор" && user.Position != "Менеджер")
                    {
                        command.Parameters.AddWithValue("@EmployeeId", user.Id);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Id = reader.GetInt32(0),
                                OrderDate = DateTime.Parse(reader.GetString(1)),
                                Status = reader.GetString(2),
                                DeviceType = reader.IsDBNull(3) ? null : reader.GetString(3),
                                DeviceModel = reader.IsDBNull(4) ? null : reader.GetString(4),
                                DeviceSerialNumber = reader.IsDBNull(5) ? null : reader.GetString(5),
                                ProblemDescription = reader.IsDBNull(6) ? null : reader.GetString(6),
                                CompletionDate = reader.IsDBNull(7) ? default : DateTime.Parse(reader.GetString(7)),
                                CustomerId = reader.GetInt32(8),
                                EmployeeId = reader.GetInt32(9),
                                TotalCost = reader.GetInt32(10),
                                CustomerFirstName = reader.GetString(11),
                                CustomerLastName = reader.GetString(12),
                                EmployeeFirstName = reader.GetString(13),
                                EmployeeLastName = reader.GetString(14)
                            };
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        public void SaveOrder(Order order, List<ServicePicker.SelectedService> selectedServices)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertOrderQuery = @"
                            INSERT INTO Orders (OrderDate, CustomerId, Status, ProblemDescription, 
                                CompletionDate, EmployeeId, DeviceType, DeviceModel, DeviceSerialNumber, TotalCost)
                            VALUES (@OrderDate, @CustomerId, @Status, @ProblemDescription, 
                                @CompletionDate, @EmployeeId, @DeviceType, @DeviceModel, @DeviceSerialNumber, @TotalCost);
                            SELECT last_insert_rowid();";

                        int orderId;
                        using (var command = new SQLiteCommand(insertOrderQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                            command.Parameters.AddWithValue("@Status", order.Status);
                            command.Parameters.AddWithValue("@ProblemDescription", order.ProblemDescription ?? "");
                            command.Parameters.AddWithValue("@CompletionDate", order.CompletionDate == default ? (object)DBNull.Value : order.CompletionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
                            command.Parameters.AddWithValue("@DeviceType", order.DeviceType ?? "");
                            command.Parameters.AddWithValue("@DeviceModel", order.DeviceModel ?? "");
                            command.Parameters.AddWithValue("@DeviceSerialNumber", order.DeviceSerialNumber ?? "");
                            command.Parameters.AddWithValue("@TotalCost", selectedServices.Sum(s => s.Service.Price * s.Quantity));
                            orderId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        foreach (var selectedService in selectedServices)
                        {
                            string insertOrderDetailsQuery = @"
                                INSERT INTO OrderDetails (OrderId, ServiceId, Quantity, TotalCost)
                                VALUES (@OrderId, @ServiceId, @Quantity, @TotalCost)";
                            using (var command = new SQLiteCommand(insertOrderDetailsQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderId", orderId);
                                command.Parameters.AddWithValue("@ServiceId", selectedService.Service.Id);
                                command.Parameters.AddWithValue("@Quantity", selectedService.Quantity);
                                command.Parameters.AddWithValue("@TotalCost", selectedService.Service.Price * selectedService.Quantity);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void UpdateOrder(Order order, List<ServicePicker.SelectedService> selectedServices)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string updateOrderQuery = @"
                            UPDATE Orders 
                            SET OrderDate = @OrderDate, CustomerId = @CustomerId, Status = @Status, 
                                ProblemDescription = @ProblemDescription, CompletionDate = @CompletionDate, 
                                EmployeeId = @EmployeeId, DeviceType = @DeviceType, DeviceModel = @DeviceModel, 
                                DeviceSerialNumber = @DeviceSerialNumber, TotalCost = @TotalCost
                            WHERE Id = @Id";
                        using (var command = new SQLiteCommand(updateOrderQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", order.Id);
                            command.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                            command.Parameters.AddWithValue("@Status", order.Status);
                            command.Parameters.AddWithValue("@ProblemDescription", order.ProblemDescription ?? "");
                            command.Parameters.AddWithValue("@CompletionDate", order.CompletionDate == default ? (object)DBNull.Value : order.CompletionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
                            command.Parameters.AddWithValue("@DeviceType", order.DeviceType ?? "");
                            command.Parameters.AddWithValue("@DeviceModel", order.DeviceModel ?? "");
                            command.Parameters.AddWithValue("@DeviceSerialNumber", order.DeviceSerialNumber ?? "");
                            command.Parameters.AddWithValue("@TotalCost", selectedServices.Sum(s => s.Service.Price * s.Quantity));
                            command.ExecuteNonQuery();
                        }

                        string deleteOrderDetailsQuery = "DELETE FROM OrderDetails WHERE OrderId = @OrderId";
                        using (var command = new SQLiteCommand(deleteOrderDetailsQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@OrderId", order.Id);
                            command.ExecuteNonQuery();
                        }

                        foreach (var selectedService in selectedServices)
                        {
                            string insertOrderDetailsQuery = @"
                                INSERT INTO OrderDetails (OrderId, ServiceId, Quantity, TotalCost)
                                VALUES (@OrderId, @ServiceId, @Quantity, @TotalCost)";
                            using (var command = new SQLiteCommand(insertOrderDetailsQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@OrderId", order.Id);
                                command.Parameters.AddWithValue("@ServiceId", selectedService.Service.Id);
                                command.Parameters.AddWithValue("@Quantity", selectedService.Quantity);
                                command.Parameters.AddWithValue("@TotalCost", selectedService.Service.Price * selectedService.Quantity);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void CloseOrder(int orderId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Orders 
                    SET Status = 'Закрыт', CompletionDate = @CompletionDate
                    WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", orderId);
                    command.Parameters.AddWithValue("@CompletionDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<OrderDetails> GetOrderDetails(int orderId)
        {
            var orderDetails = new List<OrderDetails>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, OrderId, ServiceId, Quantity, TotalCost FROM OrderDetails WHERE OrderId = @OrderId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderDetails.Add(new OrderDetails
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                ServiceId = reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                TotalCost = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return orderDetails;
        }

        public List<string> GetOrderStatuses()
        {
            var statuses = new List<string>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Status FROM Orders";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            statuses.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return statuses;
        }

        public List<OrderItem> GetOrderItems(int orderId)
        {
            var items = new List<OrderItem>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
            SELECT od.OrderId, s.Name, od.Quantity, s.Price
            FROM OrderDetails od
            JOIN Services s ON od.ServiceId = s.Id
            WHERE od.OrderId = @OrderId";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItem
                            {
                                OrderId = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                Price = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return items;
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customers";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                ContactNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                Address = reader.GetString(5)
                            });
                        }
                    }
                }
            }
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            Customer customer = null;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Customers WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                ContactNumber = reader.GetString(3),
                                Email = reader.GetString(4),
                                Address = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Customers (FirstName, LastName, ContactNumber, Email, Address) 
                    VALUES (@FirstName, @LastName, @ContactNumber, @Email, @Address)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Customers 
                    SET FirstName = @FirstName, LastName = @LastName, ContactNumber = @ContactNumber, 
                        Email = @Email, Address = @Address 
                    WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Customers WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", customerId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Service> GetServices()
        {
            var services = new List<Service>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Services";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            services.Add(new Service
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            return services;
        }

        public Service GetServiceById(int id)
        {
            Service service = null;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Services WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            service = new Service
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetInt32(2)
                            };
                        }
                    }
                }
            }
            return service;
        }

        public void AddService(Service service)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Services (Name, Price) 
                    VALUES (@Name, @Price)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", service.Name);
                    command.Parameters.AddWithValue("@Price", service.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateService(Service service)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Services 
                    SET Name = @Name, Price = @Price
                    WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", service.Id);
                    command.Parameters.AddWithValue("@Name", service.Name);
                    command.Parameters.AddWithValue("@Price", service.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteService(int serviceId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Services WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", serviceId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                FirstName = reader.GetString(3),
                                LastName = reader.GetString(4),
                                ContactNumber = reader.GetString(5),
                                Position = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return employees;
        }

        public Employee GetEmployeeByLogin(string login)
        {
            Employee employee = null;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE Login = @Login";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
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
                return employee;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = null;
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
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

        public bool CheckLoginExists(string login)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Employees WHERE Login = @Login";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Employees (Login, Password, FirstName, LastName, ContactNumber, Position) 
                    VALUES (@Login, @Password, @FirstName, @LastName, @ContactNumber, @Position)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", employee.Login);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Employees 
                    SET Login = @Login, Password = @Password, FirstName = @FirstName, 
                        LastName = @LastName, ContactNumber = @ContactNumber, Position = @Position 
                    WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Login", employee.Login);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "DELETE FROM Employees WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", employeeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public class DatabaseData
        {
            public List<Customer> Customers { get; set; }
            public List<Employee> Employees { get; set; }
            public List<Service> Services { get; set; }
            public List<Order> Orders { get; set; }
            public List<OrderDetails> OrderDetails { get; set; }
        }

        public void ExportToJson(string filePath)
        {
            try
            {
                var data = new DatabaseData
                {
                    Customers = GetCustomers(),
                    Employees = GetEmployees(),
                    Services = GetServices(),
                    Orders = GetOrders(null),
                    OrderDetails = GetAllOrderDetails()
                };

                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при экспорте базы данных в JSON: {ex.Message}");
            }
        }

        public void ImportFromJson(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception("Указанный файл не существует.");
                }

                string json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<DatabaseData>(json);

                if (data == null)
                {
                    throw new Exception("Ошибка при десериализации JSON.");
                }

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            ClearTables(connection, transaction);

                            ImportCustomers(data.Customers, connection, transaction);
                            ImportEmployees(data.Employees, connection, transaction);
                            ImportServices(data.Services, connection, transaction);
                            ImportOrders(data.Orders, connection, transaction);
                            ImportOrderDetails(data.OrderDetails, connection, transaction);

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при импорте базы данных из JSON: {ex.Message}");
            }
        }

        private List<OrderDetails> GetAllOrderDetails()
        {
            var orderDetails = new List<OrderDetails>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT Id, OrderId, ServiceId, Quantity, TotalCost FROM OrderDetails";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orderDetails.Add(new OrderDetails
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                ServiceId = reader.GetInt32(2),
                                Quantity = reader.GetInt32(3),
                                TotalCost = reader.GetInt32(4)
                            });
                        }
                    }
                }
            }
            return orderDetails;
        }

        private void ClearTables(SQLiteConnection connection, SQLiteTransaction transaction)
        {
            string[] tables = { "OrderDetails", "Orders", "Services", "Customers", "Employees" };
            foreach (var table in tables)
            {
                string query = $"DELETE FROM {table}";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.ExecuteNonQuery();
                }
                string resetQuery = $"DELETE FROM sqlite_sequence WHERE name = '{table}'";
                using (var command = new SQLiteCommand(resetQuery, connection, transaction))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportCustomers(List<Customer> customers, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            if (customers == null) return;
            foreach (var customer in customers)
            {
                string query = @"
                    INSERT INTO Customers (Id, FirstName, LastName, ContactNumber, Email, Address)
                    VALUES (@Id, @FirstName, @LastName, @ContactNumber, @Email, @Address)";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", customer.Id);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", customer.ContactNumber);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportEmployees(List<Employee> employees, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            if (employees == null) return;
            foreach (var employee in employees)
            {
                string query = @"
                    INSERT INTO Employees (Id, Login, Password, FirstName, LastName, ContactNumber, Position)
                    VALUES (@Id, @Login, @Password, @FirstName, @LastName, @ContactNumber, @Position)";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Login", employee.Login);
                    command.Parameters.AddWithValue("@Password", employee.Password);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportServices(List<Service> services, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            if (services == null) return;
            foreach (var service in services)
            {
                string query = @"
                    INSERT INTO Services (Id, Name, Price)
                    VALUES (@Id, @Name, @Price)";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", service.Id);
                    command.Parameters.AddWithValue("@Name", service.Name);
                    command.Parameters.AddWithValue("@Price", service.Price);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportOrders(List<Order> orders, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            if (orders == null) return;
            foreach (var order in orders)
            {
                string query = @"
                    INSERT INTO Orders (Id, OrderDate, CustomerId, Status, ProblemDescription, 
                        CompletionDate, EmployeeId, DeviceType, DeviceModel, DeviceSerialNumber, TotalCost)
                    VALUES (@Id, @OrderDate, @CustomerId, @Status, @ProblemDescription, 
                        @CompletionDate, @EmployeeId, @DeviceType, @DeviceModel, @DeviceSerialNumber, @TotalCost)";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                    command.Parameters.AddWithValue("@Status", order.Status);
                    command.Parameters.AddWithValue("@ProblemDescription", order.ProblemDescription ?? "");
                    command.Parameters.AddWithValue("@CompletionDate", order.CompletionDate == default ? (object)DBNull.Value : order.CompletionDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@EmployeeId", order.EmployeeId);
                    command.Parameters.AddWithValue("@DeviceType", order.DeviceType ?? "");
                    command.Parameters.AddWithValue("@DeviceModel", order.DeviceModel ?? "");
                    command.Parameters.AddWithValue("@DeviceSerialNumber", order.DeviceSerialNumber ?? "");
                    command.Parameters.AddWithValue("@TotalCost", order.TotalCost);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ImportOrderDetails(List<OrderDetails> orderDetails, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            if (orderDetails == null) return;
            foreach (var detail in orderDetails)
            {
                string query = @"
                    INSERT INTO OrderDetails (Id, OrderId, ServiceId, Quantity, TotalCost)
                    VALUES (@Id, @OrderId, @ServiceId, @Quantity, @TotalCost)";
                using (var command = new SQLiteCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", detail.Id);
                    command.Parameters.AddWithValue("@OrderId", detail.OrderId);
                    command.Parameters.AddWithValue("@ServiceId", detail.ServiceId);
                    command.Parameters.AddWithValue("@Quantity", detail.Quantity);
                    command.Parameters.AddWithValue("@TotalCost", detail.TotalCost);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}