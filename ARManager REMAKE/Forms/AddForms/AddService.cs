using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.AddForms
{
    public partial class AddService : Form
    {
        Database db = new Database();
        public AddService()
        {
            InitializeComponent();
        }

        private void AddService_Load(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.Name = nameTextBox.Text;
            service.Price = Convert.ToInt32(priceTextBox.Text);
            db.AddService(service);
            Close();
        }
    }
}
