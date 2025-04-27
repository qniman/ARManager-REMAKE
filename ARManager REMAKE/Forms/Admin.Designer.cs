namespace ARManager_REMAKE.Forms
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CustomersTab = new System.Windows.Forms.TabPage();
            this.CustomersDataGrid = new System.Windows.Forms.DataGridView();
            this.DeleteCustomerButton = new System.Windows.Forms.Button();
            this.EditCustomerButton = new System.Windows.Forms.Button();
            this.AddCustomerButton = new System.Windows.Forms.Button();
            this.ServicesTab = new System.Windows.Forms.TabPage();
            this.ServicesDataGrid = new System.Windows.Forms.DataGridView();
            this.DeleteServiceButton = new System.Windows.Forms.Button();
            this.EditServiceButton = new System.Windows.Forms.Button();
            this.AddServiceButton = new System.Windows.Forms.Button();
            this.EmployeesTab = new System.Windows.Forms.TabPage();
            this.EmployeesDataGrid = new System.Windows.Forms.DataGridView();
            this.DeleteEmployeeButton = new System.Windows.Forms.Button();
            this.EditEmployeeButton = new System.Windows.Forms.Button();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.DatabaseTab = new System.Windows.Forms.TabPage();
            this.exportButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.CustomersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGrid)).BeginInit();
            this.ServicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).BeginInit();
            this.EmployeesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGrid)).BeginInit();
            this.DatabaseTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.CustomersTab);
            this.tabControl1.Controls.Add(this.ServicesTab);
            this.tabControl1.Controls.Add(this.EmployeesTab);
            this.tabControl1.Controls.Add(this.DatabaseTab);
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 485);
            this.tabControl1.TabIndex = 0;
            // 
            // CustomersTab
            // 
            this.CustomersTab.Controls.Add(this.CustomersDataGrid);
            this.CustomersTab.Controls.Add(this.DeleteCustomerButton);
            this.CustomersTab.Controls.Add(this.EditCustomerButton);
            this.CustomersTab.Controls.Add(this.AddCustomerButton);
            this.CustomersTab.Location = new System.Drawing.Point(4, 22);
            this.CustomersTab.Margin = new System.Windows.Forms.Padding(0);
            this.CustomersTab.Name = "CustomersTab";
            this.CustomersTab.Padding = new System.Windows.Forms.Padding(3);
            this.CustomersTab.Size = new System.Drawing.Size(768, 459);
            this.CustomersTab.TabIndex = 0;
            this.CustomersTab.Text = "Клиенты";
            this.CustomersTab.UseVisualStyleBackColor = true;
            // 
            // CustomersDataGrid
            // 
            this.CustomersDataGrid.AllowUserToAddRows = false;
            this.CustomersDataGrid.AllowUserToDeleteRows = false;
            this.CustomersDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CustomersDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.CustomersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CustomersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.CustomersDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.CustomersDataGrid.MultiSelect = false;
            this.CustomersDataGrid.Name = "CustomersDataGrid";
            this.CustomersDataGrid.ReadOnly = true;
            this.CustomersDataGrid.RowHeadersVisible = false;
            this.CustomersDataGrid.RowHeadersWidth = 56;
            this.CustomersDataGrid.RowTemplate.Height = 24;
            this.CustomersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CustomersDataGrid.ShowEditingIcon = false;
            this.CustomersDataGrid.Size = new System.Drawing.Size(768, 424);
            this.CustomersDataGrid.TabIndex = 4;
            this.CustomersDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomersDataGrid_CellDoubleClick);
            // 
            // DeleteCustomerButton
            // 
            this.DeleteCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteCustomerButton.Location = new System.Drawing.Point(387, 424);
            this.DeleteCustomerButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteCustomerButton.Name = "DeleteCustomerButton";
            this.DeleteCustomerButton.Size = new System.Drawing.Size(127, 35);
            this.DeleteCustomerButton.TabIndex = 3;
            this.DeleteCustomerButton.Text = "Удалить";
            this.DeleteCustomerButton.UseVisualStyleBackColor = true;
            this.DeleteCustomerButton.Click += new System.EventHandler(this.DeleteCustomerButton_Click);
            // 
            // EditCustomerButton
            // 
            this.EditCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditCustomerButton.Location = new System.Drawing.Point(514, 424);
            this.EditCustomerButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditCustomerButton.Name = "EditCustomerButton";
            this.EditCustomerButton.Size = new System.Drawing.Size(127, 35);
            this.EditCustomerButton.TabIndex = 2;
            this.EditCustomerButton.Text = "Изменить";
            this.EditCustomerButton.UseVisualStyleBackColor = true;
            this.EditCustomerButton.Click += new System.EventHandler(this.EditCustomerButton_Click);
            // 
            // AddCustomerButton
            // 
            this.AddCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddCustomerButton.Location = new System.Drawing.Point(641, 424);
            this.AddCustomerButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddCustomerButton.Name = "AddCustomerButton";
            this.AddCustomerButton.Size = new System.Drawing.Size(127, 35);
            this.AddCustomerButton.TabIndex = 1;
            this.AddCustomerButton.Text = "Добавить";
            this.AddCustomerButton.UseVisualStyleBackColor = true;
            this.AddCustomerButton.Click += new System.EventHandler(this.AddCustomerButton_Click);
            // 
            // ServicesTab
            // 
            this.ServicesTab.Controls.Add(this.ServicesDataGrid);
            this.ServicesTab.Controls.Add(this.DeleteServiceButton);
            this.ServicesTab.Controls.Add(this.EditServiceButton);
            this.ServicesTab.Controls.Add(this.AddServiceButton);
            this.ServicesTab.Location = new System.Drawing.Point(4, 22);
            this.ServicesTab.Margin = new System.Windows.Forms.Padding(0);
            this.ServicesTab.Name = "ServicesTab";
            this.ServicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ServicesTab.Size = new System.Drawing.Size(768, 459);
            this.ServicesTab.TabIndex = 1;
            this.ServicesTab.Text = "Услуги";
            this.ServicesTab.UseVisualStyleBackColor = true;
            // 
            // ServicesDataGrid
            // 
            this.ServicesDataGrid.AllowUserToAddRows = false;
            this.ServicesDataGrid.AllowUserToDeleteRows = false;
            this.ServicesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServicesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.ServicesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicesDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ServicesDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.ServicesDataGrid.MultiSelect = false;
            this.ServicesDataGrid.Name = "ServicesDataGrid";
            this.ServicesDataGrid.ReadOnly = true;
            this.ServicesDataGrid.RowHeadersVisible = false;
            this.ServicesDataGrid.RowHeadersWidth = 56;
            this.ServicesDataGrid.RowTemplate.Height = 24;
            this.ServicesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServicesDataGrid.ShowEditingIcon = false;
            this.ServicesDataGrid.Size = new System.Drawing.Size(768, 424);
            this.ServicesDataGrid.TabIndex = 7;
            this.ServicesDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServicesDataGrid_CellDoubleClick);
            // 
            // DeleteServiceButton
            // 
            this.DeleteServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteServiceButton.Location = new System.Drawing.Point(387, 424);
            this.DeleteServiceButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteServiceButton.Name = "DeleteServiceButton";
            this.DeleteServiceButton.Size = new System.Drawing.Size(127, 35);
            this.DeleteServiceButton.TabIndex = 6;
            this.DeleteServiceButton.Text = "Удалить";
            this.DeleteServiceButton.UseVisualStyleBackColor = true;
            this.DeleteServiceButton.Click += new System.EventHandler(this.DeleteServiceButton_Click);
            // 
            // EditServiceButton
            // 
            this.EditServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditServiceButton.Location = new System.Drawing.Point(514, 424);
            this.EditServiceButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditServiceButton.Name = "EditServiceButton";
            this.EditServiceButton.Size = new System.Drawing.Size(127, 35);
            this.EditServiceButton.TabIndex = 5;
            this.EditServiceButton.Text = "Изменить";
            this.EditServiceButton.UseVisualStyleBackColor = true;
            this.EditServiceButton.Click += new System.EventHandler(this.EditServiceButton_Click);
            // 
            // AddServiceButton
            // 
            this.AddServiceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddServiceButton.Location = new System.Drawing.Point(641, 424);
            this.AddServiceButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddServiceButton.Name = "AddServiceButton";
            this.AddServiceButton.Size = new System.Drawing.Size(127, 35);
            this.AddServiceButton.TabIndex = 4;
            this.AddServiceButton.Text = "Добавить";
            this.AddServiceButton.UseVisualStyleBackColor = true;
            this.AddServiceButton.Click += new System.EventHandler(this.AddServiceButton_Click);
            // 
            // EmployeesTab
            // 
            this.EmployeesTab.Controls.Add(this.EmployeesDataGrid);
            this.EmployeesTab.Controls.Add(this.DeleteEmployeeButton);
            this.EmployeesTab.Controls.Add(this.EditEmployeeButton);
            this.EmployeesTab.Controls.Add(this.AddEmployeeButton);
            this.EmployeesTab.Location = new System.Drawing.Point(4, 22);
            this.EmployeesTab.Margin = new System.Windows.Forms.Padding(0);
            this.EmployeesTab.Name = "EmployeesTab";
            this.EmployeesTab.Size = new System.Drawing.Size(768, 459);
            this.EmployeesTab.TabIndex = 2;
            this.EmployeesTab.Text = "Сотрудники";
            this.EmployeesTab.UseVisualStyleBackColor = true;
            // 
            // EmployeesDataGrid
            // 
            this.EmployeesDataGrid.AllowUserToAddRows = false;
            this.EmployeesDataGrid.AllowUserToDeleteRows = false;
            this.EmployeesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.EmployeesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.EmployeesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmployeesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeesDataGrid.Location = new System.Drawing.Point(0, 0);
            this.EmployeesDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.EmployeesDataGrid.MultiSelect = false;
            this.EmployeesDataGrid.Name = "EmployeesDataGrid";
            this.EmployeesDataGrid.ReadOnly = true;
            this.EmployeesDataGrid.RowHeadersVisible = false;
            this.EmployeesDataGrid.RowHeadersWidth = 56;
            this.EmployeesDataGrid.RowTemplate.Height = 24;
            this.EmployeesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmployeesDataGrid.ShowEditingIcon = false;
            this.EmployeesDataGrid.Size = new System.Drawing.Size(768, 424);
            this.EmployeesDataGrid.TabIndex = 8;
            this.EmployeesDataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmployeesDataGrid_CellDoubleClick);
            // 
            // DeleteEmployeeButton
            // 
            this.DeleteEmployeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteEmployeeButton.Location = new System.Drawing.Point(387, 424);
            this.DeleteEmployeeButton.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteEmployeeButton.Name = "DeleteEmployeeButton";
            this.DeleteEmployeeButton.Size = new System.Drawing.Size(127, 35);
            this.DeleteEmployeeButton.TabIndex = 6;
            this.DeleteEmployeeButton.Text = "Удалить";
            this.DeleteEmployeeButton.UseVisualStyleBackColor = true;
            this.DeleteEmployeeButton.Click += new System.EventHandler(this.DeleteEmployeeButton_Click);
            // 
            // EditEmployeeButton
            // 
            this.EditEmployeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditEmployeeButton.Location = new System.Drawing.Point(514, 424);
            this.EditEmployeeButton.Margin = new System.Windows.Forms.Padding(0);
            this.EditEmployeeButton.Name = "EditEmployeeButton";
            this.EditEmployeeButton.Size = new System.Drawing.Size(127, 35);
            this.EditEmployeeButton.TabIndex = 5;
            this.EditEmployeeButton.Text = "Изменить";
            this.EditEmployeeButton.UseVisualStyleBackColor = true;
            this.EditEmployeeButton.Click += new System.EventHandler(this.EditEmployeeButton_Click);
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmployeeButton.Location = new System.Drawing.Point(641, 424);
            this.AddEmployeeButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(127, 35);
            this.AddEmployeeButton.TabIndex = 4;
            this.AddEmployeeButton.Text = "Добавить";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // DatabaseTab
            // 
            this.DatabaseTab.Controls.Add(this.exportButton);
            this.DatabaseTab.Controls.Add(this.importButton);
            this.DatabaseTab.Location = new System.Drawing.Point(4, 22);
            this.DatabaseTab.Name = "DatabaseTab";
            this.DatabaseTab.Size = new System.Drawing.Size(768, 459);
            this.DatabaseTab.TabIndex = 3;
            this.DatabaseTab.Text = "База данных";
            this.DatabaseTab.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(137, 222);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(488, 35);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Экспорт в JSON";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(137, 181);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(488, 35);
            this.importButton.TabIndex = 2;
            this.importButton.Text = "Импорт из JSON";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 503);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(572, 404);
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.tabControl1.ResumeLayout(false);
            this.CustomersTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersDataGrid)).EndInit();
            this.ServicesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesDataGrid)).EndInit();
            this.EmployeesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeesDataGrid)).EndInit();
            this.DatabaseTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CustomersTab;
        private System.Windows.Forms.TabPage ServicesTab;
        private System.Windows.Forms.TabPage EmployeesTab;
        private System.Windows.Forms.Button DeleteCustomerButton;
        private System.Windows.Forms.Button EditCustomerButton;
        private System.Windows.Forms.Button AddCustomerButton;
        private System.Windows.Forms.Button DeleteServiceButton;
        private System.Windows.Forms.Button EditServiceButton;
        private System.Windows.Forms.Button AddServiceButton;
        private System.Windows.Forms.Button DeleteEmployeeButton;
        private System.Windows.Forms.Button EditEmployeeButton;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.DataGridView CustomersDataGrid;
        private System.Windows.Forms.DataGridView ServicesDataGrid;
        private System.Windows.Forms.DataGridView EmployeesDataGrid;
        private System.Windows.Forms.TabPage DatabaseTab;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button importButton;
    }
}