namespace ARManager_REMAKE.Forms.AddForms
{
    partial class AddOrder
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectCustomerButton = new System.Windows.Forms.Button();
            this.customerContactNumberLabel = new System.Windows.Forms.Label();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectEmployeeButton = new System.Windows.Forms.Button();
            this.employeePositionLabel = new System.Windows.Forms.Label();
            this.employeeNameLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.problemDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deviceSerialNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceModelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.servicesTotalCostLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clearServicesButton = new System.Windows.Forms.Button();
            this.selectServicesButton = new System.Windows.Forms.Button();
            this.servicesDataGrid = new System.Windows.Forms.DataGridView();
            this.confirmButton = new System.Windows.Forms.Button();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.selectCustomerButton);
            this.groupBox2.Controls.Add(this.customerContactNumberLabel);
            this.groupBox2.Controls.Add(this.customerNameLabel);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(383, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Клиент";
            // 
            // selectCustomerButton
            // 
            this.selectCustomerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCustomerButton.Location = new System.Drawing.Point(315, 13);
            this.selectCustomerButton.Name = "selectCustomerButton";
            this.selectCustomerButton.Size = new System.Drawing.Size(95, 51);
            this.selectCustomerButton.TabIndex = 2;
            this.selectCustomerButton.Text = "Выбрать";
            this.selectCustomerButton.UseVisualStyleBackColor = true;
            this.selectCustomerButton.Click += new System.EventHandler(this.selectCustomerButton_Click);
            // 
            // customerContactNumberLabel
            // 
            this.customerContactNumberLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerContactNumberLabel.Location = new System.Drawing.Point(7, 42);
            this.customerContactNumberLabel.Name = "customerContactNumberLabel";
            this.customerContactNumberLabel.Size = new System.Drawing.Size(251, 23);
            this.customerContactNumberLabel.TabIndex = 1;
            this.customerContactNumberLabel.Text = "Не выбрано";
            // 
            // customerNameLabel
            // 
            this.customerNameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customerNameLabel.Location = new System.Drawing.Point(6, 19);
            this.customerNameLabel.Name = "customerNameLabel";
            this.customerNameLabel.Size = new System.Drawing.Size(252, 23);
            this.customerNameLabel.TabIndex = 0;
            this.customerNameLabel.Text = "Не выбрано";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selectEmployeeButton);
            this.groupBox1.Controls.Add(this.employeePositionLabel);
            this.groupBox1.Controls.Add(this.employeeNameLabel);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 70);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сотрудник";
            // 
            // selectEmployeeButton
            // 
            this.selectEmployeeButton.Location = new System.Drawing.Point(264, 13);
            this.selectEmployeeButton.Name = "selectEmployeeButton";
            this.selectEmployeeButton.Size = new System.Drawing.Size(95, 51);
            this.selectEmployeeButton.TabIndex = 2;
            this.selectEmployeeButton.Text = "Выбрать";
            this.selectEmployeeButton.UseVisualStyleBackColor = true;
            this.selectEmployeeButton.Click += new System.EventHandler(this.selectEmployeeButton_Click);
            // 
            // employeePositionLabel
            // 
            this.employeePositionLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeePositionLabel.Location = new System.Drawing.Point(7, 42);
            this.employeePositionLabel.Name = "employeePositionLabel";
            this.employeePositionLabel.Size = new System.Drawing.Size(251, 23);
            this.employeePositionLabel.TabIndex = 1;
            this.employeePositionLabel.Text = "Не выбрано";
            // 
            // employeeNameLabel
            // 
            this.employeeNameLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employeeNameLabel.Location = new System.Drawing.Point(6, 19);
            this.employeeNameLabel.Name = "employeeNameLabel";
            this.employeeNameLabel.Size = new System.Drawing.Size(252, 23);
            this.employeeNameLabel.TabIndex = 0;
            this.employeeNameLabel.Text = "Не выбрано";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.problemDescriptionTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.deviceSerialNumberTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.deviceModelTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.deviceTypeComboBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(12, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(365, 354);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация";
            // 
            // problemDescriptionTextBox
            // 
            this.problemDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.problemDescriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.problemDescriptionTextBox.Location = new System.Drawing.Point(6, 215);
            this.problemDescriptionTextBox.Name = "problemDescriptionTextBox";
            this.problemDescriptionTextBox.Size = new System.Drawing.Size(353, 133);
            this.problemDescriptionTextBox.TabIndex = 13;
            this.problemDescriptionTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(2, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(357, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Описание проблемы";
            // 
            // deviceSerialNumberTextBox
            // 
            this.deviceSerialNumberTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceSerialNumberTextBox.Location = new System.Drawing.Point(6, 159);
            this.deviceSerialNumberTextBox.Name = "deviceSerialNumberTextBox";
            this.deviceSerialNumberTextBox.Size = new System.Drawing.Size(353, 27);
            this.deviceSerialNumberTextBox.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Серийный номер";
            // 
            // deviceModelTextBox
            // 
            this.deviceModelTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceModelTextBox.Location = new System.Drawing.Point(6, 103);
            this.deviceModelTextBox.Name = "deviceModelTextBox";
            this.deviceModelTextBox.Size = new System.Drawing.Size(353, 27);
            this.deviceModelTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(2, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Модель устройства";
            // 
            // deviceTypeComboBox
            // 
            this.deviceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deviceTypeComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceTypeComboBox.FormattingEnabled = true;
            this.deviceTypeComboBox.Items.AddRange(new object[] {
            "Ноутбук",
            "Настольный ПК",
            "Планшет",
            "Смартфон",
            "Другое"});
            this.deviceTypeComboBox.Location = new System.Drawing.Point(6, 45);
            this.deviceTypeComboBox.Name = "deviceTypeComboBox";
            this.deviceTypeComboBox.Size = new System.Drawing.Size(353, 29);
            this.deviceTypeComboBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(2, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(353, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тип устройства";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.servicesTotalCostLabel);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.clearServicesButton);
            this.groupBox4.Controls.Add(this.selectServicesButton);
            this.groupBox4.Controls.Add(this.servicesDataGrid);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(383, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 354);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Услуги";
            // 
            // servicesTotalCostLabel
            // 
            this.servicesTotalCostLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesTotalCostLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesTotalCostLabel.Location = new System.Drawing.Point(191, 266);
            this.servicesTotalCostLabel.Name = "servicesTotalCostLabel";
            this.servicesTotalCostLabel.Size = new System.Drawing.Size(218, 23);
            this.servicesTotalCostLabel.TabIndex = 4;
            this.servicesTotalCostLabel.Text = "0₽";
            this.servicesTotalCostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Стоимость услуг:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clearServicesButton
            // 
            this.clearServicesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearServicesButton.Font = new System.Drawing.Font("Century Gothic", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearServicesButton.Location = new System.Drawing.Point(5, 322);
            this.clearServicesButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearServicesButton.Name = "clearServicesButton";
            this.clearServicesButton.Size = new System.Drawing.Size(404, 27);
            this.clearServicesButton.TabIndex = 3;
            this.clearServicesButton.Text = "Очистить";
            this.clearServicesButton.UseVisualStyleBackColor = true;
            // 
            // selectServicesButton
            // 
            this.selectServicesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectServicesButton.Font = new System.Drawing.Font("Century Gothic", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectServicesButton.Location = new System.Drawing.Point(5, 291);
            this.selectServicesButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectServicesButton.Name = "selectServicesButton";
            this.selectServicesButton.Size = new System.Drawing.Size(405, 27);
            this.selectServicesButton.TabIndex = 2;
            this.selectServicesButton.Text = "Выбрать";
            this.selectServicesButton.UseVisualStyleBackColor = true;
            this.selectServicesButton.Click += new System.EventHandler(this.selectServicesButton_Click);
            // 
            // servicesDataGrid
            // 
            this.servicesDataGrid.AllowUserToAddRows = false;
            this.servicesDataGrid.AllowUserToDeleteRows = false;
            this.servicesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.servicesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.servicesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDataGrid.Location = new System.Drawing.Point(5, 21);
            this.servicesDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.servicesDataGrid.MultiSelect = false;
            this.servicesDataGrid.Name = "servicesDataGrid";
            this.servicesDataGrid.ReadOnly = true;
            this.servicesDataGrid.RowHeadersVisible = false;
            this.servicesDataGrid.RowHeadersWidth = 56;
            this.servicesDataGrid.RowTemplate.Height = 24;
            this.servicesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.servicesDataGrid.ShowEditingIcon = false;
            this.servicesDataGrid.Size = new System.Drawing.Size(405, 243);
            this.servicesDataGrid.TabIndex = 1;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.Location = new System.Drawing.Point(664, 452);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(134, 36);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Добавить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.saveOrderButton_Click);
            // 
            // statusComboBox
            // 
            this.statusComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.Enabled = false;
            this.statusComboBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(137, 455);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(240, 29);
            this.statusComboBox.TabIndex = 14;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(8, 458);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(123, 21);
            this.statusLabel.TabIndex = 15;
            this.statusLabel.Text = "Статус заказа";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 496);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.MinimumSize = new System.Drawing.Size(826, 535);
            this.Name = "AddOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление заказа";
            this.Load += new System.EventHandler(this.AddOrder_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Button selectCustomerButton;
        private System.Windows.Forms.Label customerContactNumberLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selectEmployeeButton;
        private System.Windows.Forms.Label employeePositionLabel;
        private System.Windows.Forms.Label employeeNameLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox deviceTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox deviceModelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox deviceSerialNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox problemDescriptionTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView servicesDataGrid;
        private System.Windows.Forms.Button selectServicesButton;
        private System.Windows.Forms.Button clearServicesButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label servicesTotalCostLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusComboBox;
    }
}