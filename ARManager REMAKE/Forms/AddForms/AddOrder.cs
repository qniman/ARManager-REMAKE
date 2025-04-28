using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using ARManager_REMAKE.Forms.PickerForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms.AddForms
{
    public partial class AddOrder : Form
    {
        private readonly Database db = new Database();
        private Employee selectedEmployee = null;
        private Customer selectedCustomer = null;
        private List<ServicePicker.SelectedService> selectedServices = new List<ServicePicker.SelectedService>();
        private readonly Order existingOrder;
        private readonly bool isEditMode;

        private readonly string[] orderStatuses = { "Создан", "В работе", "Выполнен" };

        public AddOrder(Order order = null)
        {
            InitializeComponent();
            existingOrder = order;
            isEditMode = order != null;
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            SetupServicesDataGrid();
            SetupDeviceTypeComboBox();
            SetupStatusComboBox();

            if (isEditMode)
            {
                LoadOrderData();
                confirmButton.Text = "Сохранить";
            }

            UpdateServicesDisplay();
            servicesDataGrid.CellValueChanged += servicesDataGrid_CellValueChanged;
        }

        private void SetupServicesDataGrid()
        {
            servicesDataGrid.Columns.Clear();
            servicesDataGrid.Columns.Add("Name", "Наименование");
            servicesDataGrid.Columns.Add("Price", "Стоимость");
            servicesDataGrid.Columns.Add("Quantity", "Количество");
            servicesDataGrid.Columns.Add("Total", "Итого");

            servicesDataGrid.Columns["Price"].DefaultCellStyle.Format = "0.00 ₽";
            servicesDataGrid.Columns["Total"].DefaultCellStyle.Format = "0.00 ₽";
            servicesDataGrid.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void SetupDeviceTypeComboBox()
        {
            deviceTypeComboBox.Items.AddRange(new[] { "Лаптоп", "Десктоп", "Планшет", "Смартфон" });
            deviceTypeComboBox.SelectedIndex = -1;
        }

        private void SetupStatusComboBox()
        {
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.Items.AddRange(orderStatuses);

            if (isEditMode)
            {
                int statusIndex = Array.IndexOf(orderStatuses, existingOrder.Status);
                statusComboBox.SelectedIndex = statusIndex >= 0 ? statusIndex : 0;
                statusComboBox.Enabled = true;
            }
            else
            {
                statusComboBox.SelectedIndex = 0;
                statusComboBox.Enabled = false;
            }
        }

        private void LoadOrderData()
        {
            Text = "Редактирование заказа";
            deviceTypeComboBox.Text = existingOrder.DeviceType;
            deviceModelTextBox.Text = existingOrder.DeviceModel;
            deviceSerialNumberTextBox.Text = existingOrder.DeviceSerialNumber;
            problemDescriptionTextBox.Text = existingOrder.ProblemDescription;

            selectedCustomer = db.GetCustomerById(existingOrder.CustomerId);
            if (selectedCustomer != null)
            {
                customerNameLabel.Text = $"{selectedCustomer.FirstName} {selectedCustomer.LastName}";
                customerContactNumberLabel.Text = selectedCustomer.ContactNumber;
            }

            selectedEmployee = db.GetEmployeeById(existingOrder.EmployeeId);
            if (selectedEmployee != null)
            {
                employeeNameLabel.Text = $"{selectedEmployee.FirstName} {selectedEmployee.LastName}";
                employeePositionLabel.Text = selectedEmployee.Position;
            }

            var orderDetails = db.GetOrderDetails(existingOrder.Id);
            selectedServices = orderDetails.Select(od => new ServicePicker.SelectedService
            {
                Service = db.GetServiceById(od.ServiceId),
                Quantity = od.Quantity
            }).ToList();
        }

        private void UpdateServicesDisplay()
        {
            servicesDataGrid.Rows.Clear();
            if (selectedServices.Any())
            {
                foreach (var service in selectedServices)
                {
                    servicesDataGrid.Rows.Add(
                        service.Service.Name,
                        service.Service.Price,
                        service.Quantity,
                        service.Service.Price * service.Quantity
                    );
                }
            }
        }

        private void selectCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerPicker form = new CustomerPicker();
            form.ShowDialog();
            selectedCustomer = form.selectedCustomer;
            if (selectedCustomer != null)
            {
                customerNameLabel.Text = $"{selectedCustomer.FirstName} {selectedCustomer.LastName}";
                customerContactNumberLabel.Text = selectedCustomer.ContactNumber;
            }
        }

        private void selectEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeePicker form = new EmployeePicker();
            form.ShowDialog();
            selectedEmployee = form.selectedEmployee;
            if (selectedEmployee != null)
            {
                employeeNameLabel.Text = $"{selectedEmployee.FirstName} {selectedEmployee.LastName}";
                employeePositionLabel.Text = selectedEmployee.Position;
            }
        }

        private void selectServicesButton_Click(object sender, EventArgs e)
        {
            ServicePicker form = new ServicePicker();
            if (form.ShowDialog() == DialogResult.OK)
            {
                selectedServices = form.SelectedServices;
                UpdateServicesDisplay();
            }
        }

        private void saveOrderButton_Click(object sender, EventArgs e)
        {
            if (selectedCustomer == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            if (selectedEmployee == null)
            {
                MessageBox.Show("Выберите сотрудника");
                return;
            }
            if (!selectedServices.Any())
            {
                MessageBox.Show("Выберите хотя бы одну услугу");
                return;
            }
            if (string.IsNullOrWhiteSpace(deviceTypeComboBox.Text))
            {
                MessageBox.Show("Выберите тип устройства");
                return;
            }
            if (string.IsNullOrWhiteSpace(problemDescriptionTextBox.Text))
            {
                MessageBox.Show("Укажите описание проблемы");
                return;
            }
            if (string.IsNullOrWhiteSpace(statusComboBox.Text))
            {
                MessageBox.Show("Выберите статус заказа");
                return;
            }

            var order = new Order
            {
                Id = isEditMode ? existingOrder.Id : 0,
                CustomerId = selectedCustomer.Id,
                EmployeeId = selectedEmployee.Id,
                OrderDate = isEditMode ? existingOrder.OrderDate : DateTime.Now,
                Status = statusComboBox.Text,
                DeviceType = deviceTypeComboBox.Text,
                DeviceModel = deviceModelTextBox.Text,
                DeviceSerialNumber = deviceSerialNumberTextBox.Text,
                ProblemDescription = problemDescriptionTextBox.Text,
                CompletionDate = isEditMode ? existingOrder.CompletionDate : default,
                TotalCost = selectedServices.Sum(s => s.Service.Price * s.Quantity)
            };

            try
            {
                if (isEditMode)
                {
                    db.UpdateOrder(order, selectedServices);
                }
                else
                {
                    db.SaveOrder(order, selectedServices);
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении заказа: {ex.Message}");
            }
        }

        private void servicesDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == servicesDataGrid.Columns["Quantity"].Index && e.RowIndex >= 0)
            {
                string serviceName = servicesDataGrid.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var selectedService = selectedServices.FirstOrDefault(s => s.Service.Name == serviceName);
                if (selectedService != null && int.TryParse(servicesDataGrid.Rows[e.RowIndex].Cells["Quantity"].Value?.ToString(), out int newQuantity))
                {
                    if (newQuantity > 0)
                    {
                        selectedService.Quantity = newQuantity;
                    }
                    else
                    {
                        selectedServices.Remove(selectedService);
                    }
                    UpdateServicesDisplay();
                }
            }
        }
    }
}