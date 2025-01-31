using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopBillingSystem
{
    public partial class InVoicePage : Form
    {
        public InVoicePage()
        {
            InitializeComponent();
        }

        public InVoicePage(int invoiceId, decimal totalAmount)
        {
            InitializeComponent();
            LoadInvoice(invoiceId, totalAmount);
        }

        private DataAccess Da { get; set; }

        public InVoicePage(int invoiceId)
        {
            InitializeComponent();
            this.Da = new DataAccess();
            
        }

        private void LoadInvoice(int invoiceId, decimal totalAmount)
        {
            try
            {
              
                this.txtInvoiceId.Text = invoiceId.ToString();
                this.txtTotalAmount.Text = totalAmount.ToString()+ " TK " ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading invoice: " + ex.Message);
            }
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
