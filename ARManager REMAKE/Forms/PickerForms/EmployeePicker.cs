using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.PickerForms
{
    public partial class EmployeePicker : Form
    {
        private readonly Database db = new Database();
        public Employee selectedEmployee = null;
        private List<Employee> allEmployees;

        public EmployeePicker()
        {
            InitializeComponent();
        }

        private void SetupEmployeesDatagrid()
        {
            employeesDataGrid.Columns.Clear();

            employeesDataGrid.Columns.Add("Id", "");
            employeesDataGrid.Columns.Add("Login", "Логин");
            employeesDataGrid.Columns.Add("FirstName", "Имя");
            employeesDataGrid.Columns.Add("LastName", "Фамилия");
            employeesDataGrid.Columns.Add("ContactNumber", "Номер");
            employeesDataGrid.Columns.Add("Position", "Должность");

            employeesDataGrid.Columns["Id"].Visible = false;
        }

        private void LoadEmployees(List<Employee> employees = null)
        {
            if (employees == null)
            {
                allEmployees = db.GetEmployees();
                employees = allEmployees;
            }

            SetupEmployeesDatagrid();
            foreach (var employee in employees)
            {
                employeesDataGrid.Rows.Add(employee.Id, employee.Login, employee.FirstName, employee.LastName, employee.ContactNumber, employee.Position);
            }
        }

        private void EmployeePicker_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (employeesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            int employeeId = (int)employeesDataGrid.SelectedRows[0].Cells["Id"].Value;
            selectedEmployee = db.GetEmployeeById(employeeId);
            Close();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            AddForms.AddEmployee form = new AddForms.AddEmployee();
            form.ShowDialog();
            LoadEmployees();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadEmployees();
            }
            else
            {
                var filteredCustomers = allEmployees.Where(c =>
                    (c.Login?.ToLower().Contains(searchText) ?? false) ||
                    (c.FirstName?.ToLower().Contains(searchText) ?? false) ||
                    (c.LastName?.ToLower().Contains(searchText) ?? false) ||
                    (c.ContactNumber?.ToLower().Contains(searchText) ?? false) ||
                    (c.Position?.ToLower().Contains(searchText) ?? false)
                ).ToList();

                LoadEmployees(filteredCustomers);
            }
        }
    }
}
