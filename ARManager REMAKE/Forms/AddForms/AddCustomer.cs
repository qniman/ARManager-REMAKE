using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.AddForms
{
    public partial class AddCustomer : Form
    {
        Database db = new Database();
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.ContactNumber = contactNumberTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Address = addressTextBox.Text;

            db.AddCustomer(customer);
            Close();
        }
    }
}
