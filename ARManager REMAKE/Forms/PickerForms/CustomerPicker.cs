using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.PickerForms
{
    public partial class CustomerPicker : Form
    {
        private readonly Database db = new Database();
        public Customer selectedCustomer = null;
        private List<Customer> allCustomers;

        public CustomerPicker()
        {
            InitializeComponent();
        }

        private void SetupCustomersDatagrid()
        {
            customersDataGrid.Columns.Clear();

            customersDataGrid.Columns.Add("Id", "");
            customersDataGrid.Columns.Add("FirstName", "Имя");
            customersDataGrid.Columns.Add("LastName", "Фамилия");
            customersDataGrid.Columns.Add("ContactNumber", "Номер телефона");
            customersDataGrid.Columns.Add("Email", "Почта");
            customersDataGrid.Columns.Add("Address", "Адрес");

            customersDataGrid.Columns["Id"].Visible = false;
        }

        private void LoadCustomers(List<Customer> customers = null)
        {
            if (customers == null)
            {
                allCustomers = db.GetCustomers();
                customers = allCustomers;
            }

            SetupCustomersDatagrid();
            foreach (var customer in customers)
            {
                customersDataGrid.Rows.Add(customer.Id, customer.FirstName, customer.LastName,
                    customer.ContactNumber, customer.Email, customer.Address);
            }
        }

        private void CustomerPicker_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void SelectCustomer()
        {
            if (customersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            int customerId = (int)customersDataGrid.SelectedRows[0].Cells["Id"].Value;
            selectedCustomer = db.GetCustomerById(customerId);
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            SelectCustomer();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            AddForms.AddCustomer form = new AddForms.AddCustomer();
            form.ShowDialog();
            LoadCustomers();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadCustomers();
            }
            else
            {
                var filteredCustomers = allCustomers.Where(c =>
                    (c.FirstName?.ToLower().Contains(searchText) ?? false) ||
                    (c.LastName?.ToLower().Contains(searchText) ?? false) ||
                    (c.ContactNumber?.ToLower().Contains(searchText) ?? false) ||
                    (c.Email?.ToLower().Contains(searchText) ?? false) ||
                    (c.Address?.ToLower().Contains(searchText) ?? false)
                ).ToList();

                LoadCustomers(filteredCustomers);
            }
        }

        private void customersDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCustomer();
        }
    }
}