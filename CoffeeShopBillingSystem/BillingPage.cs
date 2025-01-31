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
    public partial class BillingPage : Form
    {
        private decimal totalSum = 0;


        private FormLogin Fl { get; set; }


        private string employeeId;
        
        private DataAccess Da { get; set; }
       

        public BillingPage()
        {
            InitializeComponent();

            this.Da = new DataAccess();
           
            this.PopulatedGridView();
           

            
        }


        public BillingPage(string empId, string empName)
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulatedGridView();
           
        }


        private void PopulatedGridView(string sql = "select * from ProductTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvProductList.AutoGenerateColumns = true;
            this.dgvProductList.DataSource = ds.Tables[0];
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductList.DataSource != null && dgvProductList.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = string.Format("ProductName LIKE '%{0}%'", txtSearch.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

        private void dgvProductList_DoubleClick(object sender, EventArgs e)
        {
            this.txtCoffeeName.Text = this.dgvProductList.CurrentRow.Cells["ProductName"].Value.ToString();

            this.txtCoffeePrice.Text = this.dgvProductList.CurrentRow.Cells["Price"].Value.ToString();

        }

        private void btnTotalAmount_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(this.txtCoffeePrice.Text) || string.IsNullOrWhiteSpace(this.txtQuantity.Text))
                {
                    MessageBox.Show("Please enter both Price and Quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal price = Convert.ToDecimal(this.txtCoffeePrice.Text);
                int quantity = Convert.ToInt32(this.txtQuantity.Text);

                decimal productTotal = price * quantity;

                totalSum += productTotal;

              
                this.lblTotalPrice.Text = totalSum.ToString("F2") + " Taka";
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for Price and Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


          




        }


        private void Clear()
        {
            this.txtCoffeeName.Text = "";
            this.txtCoffeePrice.Text = "";
            this.txtQuantity.Text = "";

        }



        
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            try
            {
                
                if (totalSum <= 0)
                {
                    MessageBox.Show("The Bill is Epmty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string invoiceDate = DateTime.Now.ToString("yyyy-MM-dd");

                string getLastInvoiceIdQuery = "SELECT MAX(InvoiceId) FROM InvoiceDataTable";
                DataTable dt = this.Da.ExecuteQueryTable(getLastInvoiceIdQuery);

                int newInvoiceId = 1; 
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    newInvoiceId = Convert.ToInt32(dt.Rows[0][0]) + 1;
                }

               
                string insertInvoiceQuery = 
                    $@"
            INSERT INTO InvoiceDataTable (InvoiceId, EmployeeId, TotalAmount, InvoiceDate)
            VALUES ({newInvoiceId}, '{employeeId}', {totalSum}, '{invoiceDate}')
        ";

                DialogResult result = MessageBox.Show("Are you sure you want to generate invoice?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Invoice generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }

                int rowsAffected = this.Da.ExecuteDMLQuery(insertInvoiceQuery);

                if (rowsAffected == 1)
                {
                    

                    InVoicePage invoicePage = new InVoicePage(newInvoiceId, totalSum);
                    invoicePage.Show();

                   
                    totalSum = 0;
                    this.lblTotalPrice.Text = "0.00 Taka";
                }
                
                else
                {
                    MessageBox.Show("Failed to generate invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Clear();
            }

         
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.PopulatedGridView();
            this.Clear();
            this.txtSearch.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCoffeeName.Text = "";
            this.txtCoffeePrice.Text = "";
            this.lblTotalPrice.Text = "";
            this.txtQuantity.Text = "";
        }
    }

    }




