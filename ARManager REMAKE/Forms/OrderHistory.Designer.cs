namespace ARManager_REMAKE.Forms
{
    partial class OrderHistory
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
            this.ordersDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDataGrid
            // 
            this.ordersDataGrid.AllowUserToAddRows = false;
            this.ordersDataGrid.AllowUserToDeleteRows = false;
            this.ordersDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ordersDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.ordersDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ordersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDataGrid.Location = new System.Drawing.Point(11, 11);
            this.ordersDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.ordersDataGrid.MultiSelect = false;
            this.ordersDataGrid.Name = "ordersDataGrid";
            this.ordersDataGrid.ReadOnly = true;
            this.ordersDataGrid.RowHeadersVisible = false;
            this.ordersDataGrid.RowHeadersWidth = 56;
            this.ordersDataGrid.RowTemplate.Height = 24;
            this.ordersDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDataGrid.ShowEditingIcon = false;
            this.ordersDataGrid.Size = new System.Drawing.Size(820, 457);
            this.ordersDataGrid.TabIndex = 1;
            // 
            // OrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 479);
            this.Controls.Add(this.ordersDataGrid);
            this.Name = "OrderHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "История заказов";
            this.Load += new System.EventHandler(this.OrderHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersDataGrid;
    }
}