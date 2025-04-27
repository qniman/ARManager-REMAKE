using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARManager_REMAKE.Classes.Database.Models;

namespace ARManager_REMAKE.Forms
{
    public partial class Main : Form
    {
        public Employee User = null;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            userNameToolStripMenuItem.Text = User.Login;
            LoadOrders();
        }

        private void LoadOrders()
        {
            ordersDataGrid.Columns.Clear();
            ordersDataGrid.Columns.Add("Status", "Статус");
            ordersDataGrid.Columns.Add("OrderDate", "Дата создания");
            ordersDataGrid.Columns.Add("Customer", "Клиент");
            ordersDataGrid.Columns.Add("CompletionDate", "Дата сдачи");
            ordersDataGrid.Columns.Add("Employee", "Сотрудник");
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
    }
}
