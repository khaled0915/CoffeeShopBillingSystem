namespace CoffeeShopBillingSystem
{
    partial class FormInvoiceHistory
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvInvoiceHistory = new System.Windows.Forms.DataGridView();
            this.btnInvoiceHistory = new System.Windows.Forms.Button();
            this.InvoiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dgvInvoiceHistory);
            this.flowLayoutPanel1.Controls.Add(this.btnInvoiceHistory);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(507, 358);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgvInvoiceHistory
            // 
            this.dgvInvoiceHistory.AllowUserToAddRows = false;
            this.dgvInvoiceHistory.AllowUserToDeleteRows = false;
            this.dgvInvoiceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceId,
            this.TotalAmount,
            this.InvoiceDate});
            this.dgvInvoiceHistory.Location = new System.Drawing.Point(3, 3);
            this.dgvInvoiceHistory.Name = "dgvInvoiceHistory";
            this.dgvInvoiceHistory.ReadOnly = true;
            this.dgvInvoiceHistory.RowHeadersWidth = 51;
            this.dgvInvoiceHistory.RowTemplate.Height = 24;
            this.dgvInvoiceHistory.Size = new System.Drawing.Size(504, 295);
            this.dgvInvoiceHistory.TabIndex = 0;
            // 
            // btnInvoiceHistory
            // 
            this.btnInvoiceHistory.BackColor = System.Drawing.Color.Orange;
            this.btnInvoiceHistory.Location = new System.Drawing.Point(3, 304);
            this.btnInvoiceHistory.Name = "btnInvoiceHistory";
            this.btnInvoiceHistory.Size = new System.Drawing.Size(130, 35);
            this.btnInvoiceHistory.TabIndex = 1;
            this.btnInvoiceHistory.Text = "Refresh";
            this.btnInvoiceHistory.UseVisualStyleBackColor = false;
            this.btnInvoiceHistory.Click += new System.EventHandler(this.btnInvoiceHistory_Click);
            // 
            // InvoiceId
            // 
            this.InvoiceId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvoiceId.DataPropertyName = "InvoiceId";
            this.InvoiceId.HeaderText = "InvoiceId";
            this.InvoiceId.MinimumWidth = 6;
            this.InvoiceId.Name = "InvoiceId";
            this.InvoiceId.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 125;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "Date";
            this.InvoiceDate.MinimumWidth = 6;
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 125;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Orange;
            this.btnBack.Location = new System.Drawing.Point(29, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 34);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "back>>";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // FormInvoiceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 494);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnBack);
            this.Name = "FormInvoiceHistory";
            this.Text = "FormInvoiceHistory";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvInvoiceHistory;
        private System.Windows.Forms.Button btnInvoiceHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.Button btnBack;
    }
}