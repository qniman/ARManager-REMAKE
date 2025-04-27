namespace ARManager_REMAKE.Forms.PickerForms
{
    partial class ServicePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicePicker));
            this.servicesDataGrid = new System.Windows.Forms.DataGridView();
            this.addServiceButton = new System.Windows.Forms.Button();
            this.removeServiceButton = new System.Windows.Forms.Button();
            this.selectedServicesDataGrid = new System.Windows.Forms.DataGridView();
            this.confirmButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedServicesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // servicesDataGrid
            // 
            this.servicesDataGrid.AllowUserToAddRows = false;
            this.servicesDataGrid.AllowUserToDeleteRows = false;
            this.servicesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.servicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.servicesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.servicesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.servicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesDataGrid.Location = new System.Drawing.Point(11, 41);
            this.servicesDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.servicesDataGrid.MultiSelect = false;
            this.servicesDataGrid.Name = "servicesDataGrid";
            this.servicesDataGrid.ReadOnly = true;
            this.servicesDataGrid.RowHeadersVisible = false;
            this.servicesDataGrid.RowHeadersWidth = 56;
            this.servicesDataGrid.RowTemplate.Height = 24;
            this.servicesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.servicesDataGrid.ShowEditingIcon = false;
            this.servicesDataGrid.Size = new System.Drawing.Size(417, 440);
            this.servicesDataGrid.TabIndex = 1;
            // 
            // addServiceButton
            // 
            this.addServiceButton.Font = new System.Drawing.Font("Century Gothic", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addServiceButton.Location = new System.Drawing.Point(432, 11);
            this.addServiceButton.Margin = new System.Windows.Forms.Padding(2);
            this.addServiceButton.Name = "addServiceButton";
            this.addServiceButton.Size = new System.Drawing.Size(45, 233);
            this.addServiceButton.TabIndex = 2;
            this.addServiceButton.Text = ">";
            this.addServiceButton.UseVisualStyleBackColor = true;
            this.addServiceButton.Click += new System.EventHandler(this.addServiceButton_Click);
            // 
            // removeServiceButton
            // 
            this.removeServiceButton.Font = new System.Drawing.Font("Century Gothic", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeServiceButton.Location = new System.Drawing.Point(432, 248);
            this.removeServiceButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeServiceButton.Name = "removeServiceButton";
            this.removeServiceButton.Size = new System.Drawing.Size(45, 233);
            this.removeServiceButton.TabIndex = 3;
            this.removeServiceButton.Text = "<";
            this.removeServiceButton.UseVisualStyleBackColor = true;
            this.removeServiceButton.Click += new System.EventHandler(this.removeServiceButton_Click);
            // 
            // selectedServicesDataGrid
            // 
            this.selectedServicesDataGrid.AllowUserToAddRows = false;
            this.selectedServicesDataGrid.AllowUserToDeleteRows = false;
            this.selectedServicesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedServicesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.selectedServicesDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.selectedServicesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedServicesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedServicesDataGrid.Location = new System.Drawing.Point(481, 11);
            this.selectedServicesDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.selectedServicesDataGrid.MultiSelect = false;
            this.selectedServicesDataGrid.Name = "selectedServicesDataGrid";
            this.selectedServicesDataGrid.RowHeadersVisible = false;
            this.selectedServicesDataGrid.RowHeadersWidth = 56;
            this.selectedServicesDataGrid.RowTemplate.Height = 24;
            this.selectedServicesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.selectedServicesDataGrid.ShowEditingIcon = false;
            this.selectedServicesDataGrid.Size = new System.Drawing.Size(386, 470);
            this.selectedServicesDataGrid.TabIndex = 4;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Font = new System.Drawing.Font("Century Gothic", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.Location = new System.Drawing.Point(701, 489);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(166, 39);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Выбрать";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchTextBox.Location = new System.Drawing.Point(39, 11);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(389, 26);
            this.searchTextBox.TabIndex = 6;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // ServicePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.selectedServicesDataGrid);
            this.Controls.Add(this.removeServiceButton);
            this.Controls.Add(this.addServiceButton);
            this.Controls.Add(this.servicesDataGrid);
            this.MinimumSize = new System.Drawing.Size(894, 578);
            this.Name = "ServicePicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор услуг";
            this.Load += new System.EventHandler(this.ServicePicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servicesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedServicesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView servicesDataGrid;
        private System.Windows.Forms.Button addServiceButton;
        private System.Windows.Forms.Button removeServiceButton;
        private System.Windows.Forms.DataGridView selectedServicesDataGrid;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}