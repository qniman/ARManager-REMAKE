using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms
{
    public partial class Admin : Form
    {
        private Database db = new Database();
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            SetupCustomersDatagrid();
            SetupServicesDatagrid();
            SetupEmployeesDatagrid();

            LoadData();
        }

        private void LoadData()
        {
            List<Customer> customers = db.GetCustomers();
            List<Service> services = db.GetServices();
            List<Employee> employees = db.GetEmployees();

            SetupCustomersDatagrid();
            SetupServicesDatagrid();
            SetupEmployeesDatagrid();

            foreach (var customer in customers)
            {
                CustomersDataGrid.Rows.Add(customer.Id, customer.FirstName, customer.LastName, customer.ContactNumber, customer.Email, customer.Address);
            }

            foreach (var service in services)
            {
                ServicesDataGrid.Rows.Add(service.Id, service.Name, service.Price);
            }

            foreach (var employee in employees)
            {
                EmployeesDataGrid.Rows.Add(employee.Id, employee.Login, employee.FirstName, employee.LastName, employee.ContactNumber, employee.Position);
            }
        }

        private void EditCustomer()
        {
            if (CustomersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для редактирования");
                return;
            }

            int customerId = (int)CustomersDataGrid.SelectedRows[0].Cells["Id"].Value;
            EditForms.EditCustomer form = new EditForms.EditCustomer();
            form.customer = db.GetCustomerById(customerId);
            form.ShowDialog();
            LoadData();
        }

        private void EditService()
        {
            if (ServicesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите услугу для редактирования");
                return;
            }

            int serviceId = (int)ServicesDataGrid.SelectedRows[0].Cells["Id"].Value;
            EditForms.EditService form = new EditForms.EditService();
            form.service = db.GetServiceById(serviceId);
            form.ShowDialog();
            LoadData();
        }

        private void EditEmployee()
        {
            if (EmployeesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования");
                return;
            }

            int employeeId = (int)EmployeesDataGrid.SelectedRows[0].Cells["Id"].Value;
            EditForms.EditEmployee form = new EditForms.EditEmployee();
            form.employee = db.GetEmployeeById(employeeId);
            form.ShowDialog();
            LoadData();
        }

        private void SetupCustomersDatagrid()
        {
            CustomersDataGrid.Columns.Clear();

            CustomersDataGrid.Columns.Add("Id", "");
            CustomersDataGrid.Columns.Add("FirstName", "Имя");
            CustomersDataGrid.Columns.Add("LastName", "Фамилия");
            CustomersDataGrid.Columns.Add("ContactNumber", "Номер телефона");
            CustomersDataGrid.Columns.Add("Email", "Почта");
            CustomersDataGrid.Columns.Add("Address", "Адрес");

            CustomersDataGrid.Columns["Id"].Visible = false;
        }

        private void SetupServicesDatagrid()
        {
            ServicesDataGrid.Columns.Clear();

            ServicesDataGrid.Columns.Add("Id", "");
            ServicesDataGrid.Columns.Add("Name", "Наименование");
            ServicesDataGrid.Columns.Add("Price", "Стоимость");

            ServicesDataGrid.Columns["Id"].Visible = false;
        }

        private void SetupEmployeesDatagrid()
        {
            EmployeesDataGrid.Columns.Clear();

            EmployeesDataGrid.Columns.Add("Id", "");
            EmployeesDataGrid.Columns.Add("Login", "Логин");
            EmployeesDataGrid.Columns.Add("FirstName", "Имя");
            EmployeesDataGrid.Columns.Add("LastName", "Фамилия");
            EmployeesDataGrid.Columns.Add("ContactNumber", "Номер");
            EmployeesDataGrid.Columns.Add("Position", "Должность");

            EmployeesDataGrid.Columns["Id"].Visible = false;
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            AddForms.AddCustomer form = new AddForms.AddCustomer();
            form.ShowDialog();
            LoadData();
        }

        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            EditCustomer();
        }

        private void DeleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (CustomersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента для удаления");
                return;
            }
            int customerId = (int)CustomersDataGrid.SelectedRows[0].Cells["Id"].Value;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Удаление клиента", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.DeleteCustomer(customerId);
                LoadData();
            }
        }

        private void CustomersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditCustomer();
        }

        private void AddServiceButton_Click(object sender, EventArgs e)
        {
            AddForms.AddService form = new AddForms.AddService();
            form.ShowDialog();
            LoadData();
        }

        private void EditServiceButton_Click(object sender, EventArgs e)
        {
            EditService();
        }

        private void ServicesDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditService();
        }

        private void DeleteServiceButton_Click(object sender, EventArgs e)
        {
            if (ServicesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите услугу для удаления");
                return;
            }
            int serviceId = (int)ServicesDataGrid.SelectedRows[0].Cells["Id"].Value;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить услугу?", "Удаление услуги", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.DeleteService(serviceId);
                LoadData();
            }
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            AddForms.AddEmployee form = new AddForms.AddEmployee();
            form.ShowDialog();
            LoadData();
        }

        private void EditEmployeeButton_Click(object sender, EventArgs e)
        {
            EditEmployee();
        }

        private void EmployeesDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditEmployee();
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (EmployeesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления");
                return;
            }
            int employeeId = (int)EmployeesDataGrid.SelectedRows[0].Cells["Id"].Value;
            Employee employee = db.GetEmployeeById(employeeId);
            if (employee.Login == "admin")
            {
                MessageBox.Show("Вы не можете удалить администратора");
                return;
            }
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить сотрудника?", "Удаление сотрудника", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                db.DeleteEmployee(employeeId);
                LoadData();
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Выберите JSON файл для импорта";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.ImportFromJson(openFileDialog.FileName);
                        MessageBox.Show("База данных успешно импортирована из JSON. Текущая сессия будет закрыта.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Перезапуск приложения
                        System.Diagnostics.Process.Start(Application.ExecutablePath);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при импорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить базу данных как JSON";
                saveFileDialog.FileName = $"database_export_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        db.ExportToJson(saveFileDialog.FileName);
                        MessageBox.Show("База данных успешно экспортирована в JSON.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
