using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.EditForms
{
    public partial class EditEmployee : Form
    {
        public Employee employee = null;
        Database db = new Database();
        public EditEmployee()
        {
            InitializeComponent();
        }

        private void LoadEmployee()
        {
            if (employee != null)
            {
                loginTextBox.Text = employee.Login;
                firstNameTextBox.Text = employee.FirstName;
                lastNameTextBox.Text = employee.LastName;
                contactNumberTextBox.Text = employee.ContactNumber;
                positionComboBox.Text = employee.Position;
            }
        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployee();
            if (employee.Login == "admin")
            {
                positionComboBox.Enabled = false;
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(contactNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(positionComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
                return;
            }



            if (!string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                !string.IsNullOrWhiteSpace(confirmPasswordTextBox.Text))
            {
                if (passwordTextBox.Text != confirmPasswordTextBox.Text)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                employee.Password = passwordTextBox.Text;
            }
            employee.FirstName = firstNameTextBox.Text;
            employee.LastName = lastNameTextBox.Text;
            employee.ContactNumber = contactNumberTextBox.Text;
            employee.Position = positionComboBox.Text;

            db.UpdateEmployee(employee);
            Close();
        }
    }
}
