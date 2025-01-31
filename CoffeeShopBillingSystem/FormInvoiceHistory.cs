using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CoffeeShopBillingSystem
{
    public partial class FormInvoiceHistory : Form
    {
        private DataAccess Da { get; set; }

        public FormInvoiceHistory()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulatedGridView();
        }

        
        



        private void PopulatedGridView(string sql = "SELECT InvoiceId, TotalAmount, InvoiceDate FROM InvoiceDataTable")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvInvoiceHistory.AutoGenerateColumns = false;
            this.dgvInvoiceHistory.DataSource = ds.Tables[0];
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        

        private void btnInvoiceHistory_Click(object sender, EventArgs e)
        {
            this.PopulatedGridView();
        }
    }
}
