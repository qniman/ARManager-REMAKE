using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;

namespace ARManager_REMAKE.Forms
{
    public partial class Main : Form
    {
        private readonly Database db = new Database();
        public Employee User = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            userNameToolStripMenuItem.Text = User?.Login ?? "Неизвестный пользователь";
            LoadOrders();
        }

        private void SetupOrdersDataGrid()
        {
            ordersDataGrid.Columns.Clear();

            ordersDataGrid.Columns.Add("Id", "ID");
            ordersDataGrid.Columns.Add("Status", "Статус");
            ordersDataGrid.Columns.Add("OrderDate", "Дата создания");
            ordersDataGrid.Columns.Add("Customer", "Клиент");
            ordersDataGrid.Columns.Add("CompletionDate", "Дата сдачи");
            ordersDataGrid.Columns.Add("Employee", "Сотрудник");
            ordersDataGrid.Columns.Add("TotalCost", "Общая стоимость");

            ordersDataGrid.Columns["Id"].Visible = false;
            ordersDataGrid.Columns["TotalCost"].DefaultCellStyle.Format = "0.00 ₽";
            ordersDataGrid.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadOrders()
        {
            SetupOrdersDataGrid();

            List<Order> orders = db.GetOrders(User);

            foreach (var order in orders)
            {
                if (order.Status == "Закрыт")
                {
                    return;
                }
                ordersDataGrid.Rows.Add(
                    order.Id,
                    order.Status,
                    order.OrderDate.ToString("dd.MM.yyyy"),
                    $"{order.CustomerFirstName} {order.CustomerLastName}",
                    order.CompletionDate == default ? "Не завершено" : order.CompletionDate.ToString("dd.MM.yyyy"),
                    $"{order.EmployeeFirstName} {order.EmployeeLastName}",
                    order.TotalCost
                );
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Auth authForm = new Auth();
            authForm.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            adminForm.ShowDialog();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            AddForms.AddOrder form = new AddForms.AddOrder();
            form.ShowDialog();
            LoadOrders();
        }

        private void editOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для редактирования");
                return;
            }

            int orderId = (int)ordersDataGrid.SelectedRows[0].Cells["Id"].Value;
            var order = db.GetOrders(User).FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                MessageBox.Show("Заказ не найден");
                return;
            }

            if (User.Position != "Администратор" && User.Position != "Менеджер" && order.EmployeeId != User.Id)
            {
                MessageBox.Show("Вы не можете редактировать этот заказ");
                return;
            }

            var editForm = new AddForms.AddOrder(order);
            editForm.ShowDialog();
            LoadOrders();
        }

        private void closeOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для закрытия");
                return;
            }

            int orderId = (int)ordersDataGrid.SelectedRows[0].Cells["Id"].Value;
            var order = db.GetOrders(User).FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                MessageBox.Show("Заказ не найден");
                return;
            }

            if (User.Position != "Администратор" && User.Position != "Менеджер" && order.EmployeeId != User.Id)
            {
                MessageBox.Show("Вы не можете закрыть этот заказ");
                return;
            }

            try
            {
                db.CloseOrder(orderId);
                MessageBox.Show("Заказ успешно закрыт");
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии заказа: {ex.Message}");
            }
        }
    }
}