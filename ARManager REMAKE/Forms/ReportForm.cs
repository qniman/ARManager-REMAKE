using ARManager_REMAKE.Classes.Database;
using ARManager_REMAKE.Classes.Database.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ARManager_REMAKE.Forms
{
    public partial class ReportForm : Form
    {
        private readonly Database db;
        private readonly Employee user;
        private readonly string[] reportTypes = { "Все заказы", "Заказы по статусу", "Заказы по клиенту", "Финансовый отчет" };
        private readonly string[] exportFormats = { "Excel", "Word" };

        public ReportForm(Database db, Employee user)
        {
            InitializeComponent();
            this.db = db;
            this.user = user;
            InitializeControls();
        }

        private void InitializeControls()
        {
            reportTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            reportTypeComboBox.Items.AddRange(reportTypes);
            reportTypeComboBox.SelectedIndex = 0;

            exportFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            exportFormatComboBox.Items.AddRange(exportFormats);
            exportFormatComboBox.SelectedIndex = 0;

            startDatePicker.Value = DateTime.Today.AddMonths(-1);
            endDatePicker.Value = DateTime.Today;
            startDatePicker.Enabled = false;
            endDatePicker.Enabled = false;
            useDateRangeCheckBox.Checked = false;

            useDateRangeCheckBox.CheckedChanged += (s, e) =>
            {
                startDatePicker.Enabled = useDateRangeCheckBox.Checked;
                endDatePicker.Enabled = useDateRangeCheckBox.Checked;
            };
            generateButton.Click += GenerateButton_Click;
            cancelButton.Click += (s, e) => Close();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (useDateRangeCheckBox.Checked && startDatePicker.Value > endDatePicker.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var orders = db.GetOrders(user);
            if (useDateRangeCheckBox.Checked)
            {
                orders = orders.Where(o => o.OrderDate >= startDatePicker.Value && o.OrderDate <= endDatePicker.Value).ToList();
            }

            string reportType = reportTypeComboBox.SelectedItem.ToString();
            string exportFormat = exportFormatComboBox.SelectedItem.ToString();

            try
            {
                string filePath = SaveReportFile(exportFormat);
                if (string.IsNullOrEmpty(filePath)) return;

                switch (reportType)
                {
                    case "Все заказы":
                        GenerateAllOrdersReport(orders, exportFormat, filePath);
                        break;
                    case "Заказы по статусу":
                        GenerateOrdersByStatusReport(orders, exportFormat, filePath);
                        break;
                    case "Заказы по клиенту":
                        GenerateOrdersByCustomerReport(orders, exportFormat, filePath);
                        break;
                    case "Финансовый отчет":
                        GenerateFinancialReport(orders, exportFormat, filePath);
                        break;
                }

                MessageBox.Show($"Отчет успешно сохранен: {filePath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при формировании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveReportFile(string format)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = format == "Excel" ? "Excel файлы (*.xlsx)|*.xlsx" : "Word файлы (*.docx)|*.docx";
                saveFileDialog.Title = "Сохранить отчет";
                saveFileDialog.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.{format.ToLower()}";

                return saveFileDialog.ShowDialog() == DialogResult.OK ? saveFileDialog.FileName : null;
            }
        }

        private void GenerateAllOrdersReport(List<Order> orders, string format, string filePath)
        {
            if (format == "Excel")
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Заказы");
                    worksheet.Cell(1, 1).Value = "ID";
                    worksheet.Cell(1, 2).Value = "Статус";
                    worksheet.Cell(1, 3).Value = "Дата создания";
                    worksheet.Cell(1, 4).Value = "Клиент";
                    worksheet.Cell(1, 5).Value = "Сотрудник";
                    worksheet.Cell(1, 6).Value = "Общая стоимость";

                    for (int i = 0; i < orders.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = orders[i].Id;
                        worksheet.Cell(i + 2, 2).Value = orders[i].Status;
                        worksheet.Cell(i + 2, 3).Value = orders[i].OrderDate.ToString("dd.MM.yyyy");
                        worksheet.Cell(i + 2, 4).Value = $"{orders[i].CustomerFirstName} {orders[i].CustomerLastName}";
                        worksheet.Cell(i + 2, 5).Value = $"{orders[i].EmployeeFirstName} {orders[i].EmployeeLastName}";
                        worksheet.Cell(i + 2, 6).Value = orders[i].TotalCost;
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }
            }
            else
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();
                    Paragraph header = new Paragraph(new Run(new Text("Отчет: Все заказы")));
                    body.Append(header);

                    Table table = new Table();
                    TableRow headerRow = new TableRow();
                    headerRow.Append(
                        new TableCell(new Paragraph(new Run(new Text("ID")))),
                        new TableCell(new Paragraph(new Run(new Text("Статус")))),
                        new TableCell(new Paragraph(new Run(new Text("Дата создания")))),
                        new TableCell(new Paragraph(new Run(new Text("Клиент")))),
                        new TableCell(new Paragraph(new Run(new Text("Сотрудник")))),
                        new TableCell(new Paragraph(new Run(new Text("Общая стоимость"))))
                    );
                    table.Append(headerRow);

                    foreach (var order in orders)
                    {
                        TableRow row = new TableRow();
                        row.Append(
                            new TableCell(new Paragraph(new Run(new Text(order.Id.ToString())))),
                            new TableCell(new Paragraph(new Run(new Text(order.Status)))),
                            new TableCell(new Paragraph(new Run(new Text(order.OrderDate.ToString("dd.MM.yyyy"))))),
                            new TableCell(new Paragraph(new Run(new Text($"{order.CustomerFirstName} {order.CustomerLastName}")))),
                            new TableCell(new Paragraph(new Run(new Text($"{order.EmployeeFirstName} {order.EmployeeLastName}")))),
                            new TableCell(new Paragraph(new Run(new Text(order.TotalCost.ToString("0.00 ₽")))))
                        );
                        table.Append(row);
                    }

                    body.Append(table);
                    mainPart.Document.Append(body);
                }
            }
        }

        private void GenerateOrdersByStatusReport(List<Order> orders, string format, string filePath)
        {
            var groupedOrders = orders.GroupBy(o => o.Status).OrderBy(g => g.Key);
            if (format == "Excel")
            {
                using (var workbook = new XLWorkbook())
                {
                    foreach (var group in groupedOrders)
                    {
                        var worksheet = workbook.Worksheets.Add(group.Key);
                        worksheet.Cell(1, 1).Value = "ID";
                        worksheet.Cell(1, 2).Value = "Дата создания";
                        worksheet.Cell(1, 3).Value = "Клиент";
                        worksheet.Cell(1, 4).Value = "Сотрудник";
                        worksheet.Cell(1, 5).Value = "Общая стоимость";

                        int row = 2;
                        foreach (var order in group)
                        {
                            worksheet.Cell(row, 1).Value = order.Id;
                            worksheet.Cell(row, 2).Value = order.OrderDate.ToString("dd.MM.yyyy");
                            worksheet.Cell(row, 3).Value = $"{order.CustomerFirstName} {order.CustomerLastName}";
                            worksheet.Cell(row, 4).Value = $"{order.EmployeeFirstName} {order.EmployeeLastName}";
                            worksheet.Cell(row, 5).Value = order.TotalCost;
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                    }
                    workbook.SaveAs(filePath);
                }
            }
            else
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();
                    body.Append(new Paragraph(new Run(new Text("Отчет: Заказы по статусу"))));

                    foreach (var group in groupedOrders)
                    {
                        body.Append(new Paragraph(new Run(new Text($"Статус: {group.Key}"))));
                        Table table = new Table();
                        TableRow headerRow = new TableRow();
                        headerRow.Append(
                            new TableCell(new Paragraph(new Run(new Text("ID")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата создания")))),
                            new TableCell(new Paragraph(new Run(new Text("Клиент")))),
                            new TableCell(new Paragraph(new Run(new Text("Сотрудник")))),
                            new TableCell(new Paragraph(new Run(new Text("Общая стоимость"))))
                        );
                        table.Append(headerRow);

                        foreach (var order in group)
                        {
                            TableRow row = new TableRow();
                            row.Append(
                                new TableCell(new Paragraph(new Run(new Text(order.Id.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(order.OrderDate.ToString("dd.MM.yyyy"))))),
                                new TableCell(new Paragraph(new Run(new Text($"{order.CustomerFirstName} {order.CustomerLastName}")))),
                                new TableCell(new Paragraph(new Run(new Text($"{order.EmployeeFirstName} {order.EmployeeLastName}")))),
                                new TableCell(new Paragraph(new Run(new Text(order.TotalCost.ToString("0.00 ₽")))))
                            );
                            table.Append(row);
                        }
                        body.Append(table);
                    }

                    mainPart.Document.Append(body);
                }
            }
        }

        private void GenerateOrdersByCustomerReport(List<Order> orders, string format, string filePath)
        {
            var groupedOrders = orders.GroupBy(o => $"{o.CustomerFirstName} {o.CustomerLastName}").OrderBy(g => g.Key);
            if (format == "Excel")
            {
                using (var workbook = new XLWorkbook())
                {
                    foreach (var group in groupedOrders)
                    {
                        var worksheet = workbook.Worksheets.Add(group.Key.Length > 31 ? group.Key.Substring(0, 31) : group.Key);
                        worksheet.Cell(1, 1).Value = "ID";
                        worksheet.Cell(1, 2).Value = "Статус";
                        worksheet.Cell(1, 3).Value = "Дата создания";
                        worksheet.Cell(1, 4).Value = "Сотрудник";
                        worksheet.Cell(1, 5).Value = "Общая стоимость";

                        int row = 2;
                        foreach (var order in group)
                        {
                            worksheet.Cell(row, 1).Value = order.Id;
                            worksheet.Cell(row, 2).Value = order.Status;
                            worksheet.Cell(row, 3).Value = order.OrderDate.ToString("dd.MM.yyyy");
                            worksheet.Cell(row, 4).Value = $"{order.EmployeeFirstName} {order.EmployeeLastName}";
                            worksheet.Cell(row, 5).Value = order.TotalCost;
                            row++;
                        }

                        worksheet.Columns().AdjustToContents();
                    }
                    workbook.SaveAs(filePath);
                }
            }
            else
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();
                    body.Append(new Paragraph(new Run(new Text("Отчет: Заказы по клиенту"))));

                    foreach (var group in groupedOrders)
                    {
                        body.Append(new Paragraph(new Run(new Text($"Клиент: {group.Key}"))));
                        Table table = new Table();
                        TableRow headerRow = new TableRow();
                        headerRow.Append(
                            new TableCell(new Paragraph(new Run(new Text("ID")))),
                            new TableCell(new Paragraph(new Run(new Text("Статус")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата создания")))),
                            new TableCell(new Paragraph(new Run(new Text("Сотрудник")))),
                            new TableCell(new Paragraph(new Run(new Text("Общая стоимость"))))
                        );
                        table.Append(headerRow);

                        foreach (var order in group)
                        {
                            TableRow row = new TableRow();
                            row.Append(
                                new TableCell(new Paragraph(new Run(new Text(order.Id.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(order.Status)))),
                                new TableCell(new Paragraph(new Run(new Text(order.OrderDate.ToString("dd.MM.yyyy"))))),
                                new TableCell(new Paragraph(new Run(new Text($"{order.EmployeeFirstName} {order.EmployeeLastName}")))),
                                new TableCell(new Paragraph(new Run(new Text(order.TotalCost.ToString("0.00 ₽")))))
                            );
                            table.Append(row);
                        }
                        body.Append(table);
                    }

                    mainPart.Document.Append(body);
                }
            }
        }

        private void GenerateFinancialReport(List<Order> orders, string format, string filePath)
        {
            var totalCost = orders.Sum(o => o.TotalCost);
            var groupedByMonth = orders.GroupBy(o => o.OrderDate.ToString("yyyy-MM"))
                                       .Select(g => new { Month = g.Key, Total = g.Sum(o => o.TotalCost) })
                                       .OrderBy(g => g.Month);

            if (format == "Excel")
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Финансовый отчет");
                    worksheet.Cell(1, 1).Value = "Период";
                    worksheet.Cell(1, 2).Value = "Общая стоимость";
                    worksheet.Cell(3, 1).Value = "Итого";
                    worksheet.Cell(3, 2).Value = totalCost;

                    int row = 2;
                    foreach (var group in groupedByMonth)
                    {
                        worksheet.Cell(row, 1).Value = group.Month;
                        worksheet.Cell(row, 2).Value = group.Total;
                        row++;
                    }

                    worksheet.Columns().AdjustToContents();
                    workbook.SaveAs(filePath);
                }
            }
            else
            {
                using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = new Body();
                    body.Append(new Paragraph(new Run(new Text("Финансовый отчет"))));

                    Table table = new Table();
                    TableRow headerRow = new TableRow();
                    headerRow.Append(
                        new TableCell(new Paragraph(new Run(new Text("Период")))),
                        new TableCell(new Paragraph(new Run(new Text("Общая стоимость"))))
                    );
                    table.Append(headerRow);

                    foreach (var group in groupedByMonth)
                    {
                        TableRow row = new TableRow();
                        row.Append(
                            new TableCell(new Paragraph(new Run(new Text(group.Month)))),
                            new TableCell(new Paragraph(new Run(new Text(group.Total.ToString("0.00 ₽")))))
                        );
                        table.Append(row);
                    }

                    TableRow totalRow = new TableRow();
                    totalRow.Append(
                        new TableCell(new Paragraph(new Run(new Text("Итого")))),
                        new TableCell(new Paragraph(new Run(new Text(totalCost.ToString("0.00 ₽")))))
                    );
                    table.Append(totalRow);

                    body.Append(table);
                    mainPart.Document.Append(body);
                }
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}