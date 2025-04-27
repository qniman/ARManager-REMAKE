using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.EditForms
{
    public partial class EditCustomer : Form
    {
        Database db = new Database();
        public Customer customer = null;
        public EditCustomer()
        {
            InitializeComponent();
        }

        void LoadCustomer()
        {
            firstNameTextBox.Text = customer.FirstName;
            lastNameTextBox.Text = customer.LastName;
            contactNumberTextBox.Text = customer.ContactNumber;
            emailTextBox.Text = customer.Email;
            addressTextBox.Text = customer.Address;
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            customer.FirstName = firstNameTextBox.Text;
            customer.LastName = lastNameTextBox.Text;
            customer.ContactNumber = contactNumberTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Address = addressTextBox.Text;

            db.UpdateCustomer(customer);
            Close();
        }
    }
}
