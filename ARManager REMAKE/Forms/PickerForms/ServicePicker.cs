using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.PickerForms
{
    public partial class ServicePicker : Form
    {
        private readonly Database db = new Database();
        private List<Service> allServices;
        private List<SelectedService> selectedServices = new List<SelectedService>();
        public List<SelectedService> SelectedServices => selectedServices;

        public ServicePicker()
        {
            InitializeComponent();
        }

        public class SelectedService
        {
            public Service Service { get; set; }
            public int Quantity { get; set; }
            public decimal Total => Service.Price * Quantity;
        }

        private void SetupServicesDatagrid()
        {
            servicesDataGrid.Columns.Clear();
            servicesDataGrid.Columns.Add("Id", "");
            servicesDataGrid.Columns.Add("Name", "Наименование");
            servicesDataGrid.Columns.Add("Price", "Стоимость");
            servicesDataGrid.Columns["Id"].Visible = false;
            servicesDataGrid.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        private void SetupSelectedServicesDatagrid()
        {
            selectedServicesDataGrid.Columns.Clear();
            selectedServicesDataGrid.Columns.Add("Id", "");
            selectedServicesDataGrid.Columns.Add("Name", "Наименование");
            selectedServicesDataGrid.Columns.Add("Price", "Стоимость");
            selectedServicesDataGrid.Columns.Add("Quantity", "Количество");
            selectedServicesDataGrid.Columns.Add("Total", "Итого");
            selectedServicesDataGrid.Columns["Id"].Visible = false;
            selectedServicesDataGrid.Columns["Price"].DefaultCellStyle.Format = "C2";
            selectedServicesDataGrid.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        private void LoadServices(List<Service> services = null)
        {
            if (services == null)
            {
                allServices = db.GetServices();
                services = allServices;
            }

            SetupServicesDatagrid();
            foreach (var service in services)
            {
                servicesDataGrid.Rows.Add(service.Id, service.Name, service.Price);
            }
        }

        private void LoadSelectedServices()
        {
            SetupSelectedServicesDatagrid();
            foreach (var selectedService in selectedServices)
            {
                selectedServicesDataGrid.Rows.Add(
                    selectedService.Service.Id,
                    selectedService.Service.Name,
                    selectedService.Service.Price,
                    selectedService.Quantity,
                    selectedService.Total
                );
            }
        }

        private void ServicePicker_Load(object sender, EventArgs e)
        {
            LoadServices();
            LoadSelectedServices();
        }

        private void addServiceButton_Click(object sender, EventArgs e)
        {
            if (servicesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите услугу для добавления");
                return;
            }

            int serviceId = (int)servicesDataGrid.SelectedRows[0].Cells["Id"].Value;
            var service = allServices.FirstOrDefault(s => s.Id == serviceId);

            if (service == null) return;

            var existingService = selectedServices.FirstOrDefault(s => s.Service.Id == serviceId);
            if (existingService != null)
            {
                existingService.Quantity++;
            }
            else
            {
                selectedServices.Add(new SelectedService { Service = service, Quantity = 1 });
            }

            LoadSelectedServices();
        }

        private void removeServiceButton_Click(object sender, EventArgs e)
        {
            if (selectedServicesDataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите услугу для удаления");
                return;
            }

            int serviceId = (int)selectedServicesDataGrid.SelectedRows[0].Cells["Id"].Value;
            var selectedService = selectedServices.FirstOrDefault(s => s.Service.Id == serviceId);

            if (selectedService != null)
            {
                selectedServices.Remove(selectedService);
                LoadSelectedServices();
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (selectedServices.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одну услугу");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadServices();
            }
            else
            {
                var filteredServices = allServices
                    .Where(s => s.Name.ToLower().Contains(searchText))
                    .ToList();
                LoadServices(filteredServices);
            }
        }
    }
}