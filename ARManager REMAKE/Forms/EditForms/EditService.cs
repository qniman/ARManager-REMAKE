using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.EditForms
{
    public partial class EditService : Form
    {
        Database db = new Database();
        public Service service = null;
        public EditService()
        {
            InitializeComponent();
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            LoadService();
        }

        void LoadService()
        {
            nameTextBox.Text = service.Name;
            priceTextBox.Text = service.Price.ToString();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            service.Name = nameTextBox.Text;
            service.Price = Convert.ToInt32(priceTextBox.Text);
            db.UpdateService(service);
            Close();
        }
    }
}
