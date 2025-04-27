using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms
{
    public partial class OrderHistory: Form
    {
        Database db = new Database();
        public OrderHistory()
        {
            InitializeComponent();
        }

        private void SetupDataGrid()
        {
            ordersDataGrid.Columns.Clear();

            ordersDataGrid.Columns.Add("Id", "");
            ordersDataGrid.Columns.Add("Status", "Статус");
            ordersDataGrid.Columns.Add("DeviceType", "Тип устройства");
            ordersDataGrid.Columns.Add("DeviceModel", "Модель устройства");
            ordersDataGrid.Columns.Add("DeviceSerialNumber", "Серийный номер");
            ordersDataGrid.Columns.Add("OrderDate", "Дата заказа");
            ordersDataGrid.Columns.Add("CompletionDate", "Дата выполнения");
            ordersDataGrid.Columns.Add("TotalCost", "Сумма заказа");
            ordersDataGrid.Columns.Add("Customer", "Клиент");
            ordersDataGrid.Columns.Add("Employee", "Сотрудник");

            ordersDataGrid.Columns["Id"].Visible = false;
        }

        private void LoadData()
        {
            SetupDataGrid();

            List<Order> orders = db.GetOrders(null);    
            foreach (Order order in orders)
            {
                var customerFullname = order.CustomerFirstName + " " + order.CustomerLastName;
                var employeeFullname = order.EmployeeFirstName + " " + order.EmployeeLastName;
                ordersDataGrid.Rows.Add(order.Id, order.Status, order.DeviceType, order.DeviceModel, order.DeviceSerialNumber, order.OrderDate, order.CompletionDate, order.TotalCost, customerFullname, employeeFullname);
            }
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
