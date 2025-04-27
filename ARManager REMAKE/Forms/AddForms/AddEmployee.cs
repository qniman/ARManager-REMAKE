using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.AddForms
{
    public partial class AddEmployee : Form
    {
        Database db = new Database();
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text) ||
                string.IsNullOrWhiteSpace(passwordTextBox.Text) ||
                string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(contactNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(positionComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }

            if (db.CheckLoginExists(loginTextBox.Text))
            {
                MessageBox.Show("Логин уже существует");
                return;
            }

            if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            Employee employee = new Employee()
            {
                Login = loginTextBox.Text,
                Password = passwordTextBox.Text,
                FirstName = firstNameTextBox.Text,
                LastName = lastNameTextBox.Text,
                ContactNumber = contactNumberTextBox.Text,
                Position = positionComboBox.Text
            };
            db.AddEmployee(employee);
            Close();
        }
    }
}
