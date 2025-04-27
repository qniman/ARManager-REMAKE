using System;
using System.Windows.Forms;
using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;

namespace ARManager_REMAKE.Forms
{
    public partial class Auth : Form
    {
        private Database db = new Database();
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            db.Init();
        }

        private void Login()
        {
            string login = loginTextbox.Text.Trim();
            string password = passwordTextbox.Text.Trim();

            if (login == "" || password == "") return;

            Employee employee = db.GetEmployeeByLogin(login);
            if (employee == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != employee.Password)
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();
            Main form = new Main();
            form.User = employee;
            form.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
