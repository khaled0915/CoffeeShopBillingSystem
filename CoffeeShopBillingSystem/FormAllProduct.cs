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
    public partial class FormAllProduct : Form
    {
        private DataAccess Da { get; set; }
        public FormAllProduct()
        {

            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulatedGridView();
        }


        private void PopulatedGridView(string sql = "select * from ProductTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvCoffee.AutoGenerateColumns = false;
            this.dgvCoffee.DataSource = ds.Tables[0];
        }



        private void btnShowAllProduct_Click(object sender, EventArgs e)
        {
            this.PopulatedGridView();
            this.ClearAll();
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            var sql = "select * from ProductTable where ProductName like '" + this.txtSearchProduct.Text + "%';";
            this.PopulatedGridView(sql);
        }

        

        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {


            try
            {
                if(!isValidToSave())
                {
                    MessageBox.Show("Please fill up all the fields properly");
                    return;
                }


                var query = "select * from ProductTable where ProductId = '" + this.txtProductId.Text + "'";
                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {

                    var sql = @"update ProductTable
                                set ProductName ='"+this.txtProductName.Text+ @"',
                                Price = '" + this.txtProductPrice.Text + @"'
                                where ProductId = '" + this.txtProductId.Text + "';";


                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data has been updated Properly");
                    else
                        MessageBox.Show("data Hasn't been updated properly");




                }




                else
                {
                    var sql = "insert into ProductTable values('" + this.txtProductId.Text + "','" + this.txtProductName.Text + "','" + this.txtProductPrice.Text + "');";

                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Product Added Successfully");
                    else
                        MessageBox.Show("Data Insertion Failed");
                }

                this.PopulatedGridView();
                this.ClearAll();

            }
            catch (Exception exc)
            {
                MessageBox.Show("An Error has occurred: " + exc.Message);
            }
        }





        private bool isValidToSave()
        {

            if (string.IsNullOrEmpty(this.txtProductId.Text) || string.IsNullOrEmpty(this.txtProductName.Text) || string.IsNullOrEmpty(this.txtProductPrice.Text))
                return false;
            else
                return true;

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void ClearAll()
        {

            this.txtProductId.Text = "";
            this.txtProductName.Clear();
            this.txtProductPrice.Clear();
            this.txtSearchProduct.Clear();
            this.dgvCoffee.ClearSelection();
            this.AutoIdGenerate();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {

                if(this.dgvCoffee.SelectedRows.Count<1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var ProductId = this.dgvCoffee.CurrentRow.Cells[0].Value.ToString();
                var ProductName = this.dgvCoffee.CurrentRow.Cells[1].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete " + ProductName + "?" , "Alert" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;
                var sql = "delete from ProductTable where ProductId='" + ProductId + "';";
                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(ProductName.ToUpper() + " has been removed from the list ");
                else
                    MessageBox.Show("Data hasn't been removed properly");

                this.PopulatedGridView();
                this.ClearAll();




            }
            catch(Exception exc) 
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);

            }
        }

        private void FormAllProduct_Load(object sender, EventArgs e)
        {
            this.dgvCoffee.ClearSelection();
            this.AutoIdGenerate();
        }



        private void AutoIdGenerate()
        {
            var query = "select max(ProductId) from ProductTable;";
            var dt = this.Da.ExecuteQueryTable(query);
            var oldId = dt.Rows[0][0].ToString();
            String[] temp = oldId.Split('-');
            var num = Convert.ToInt32(temp[1]);
            var newId = "p-" + (++num).ToString();
            this.txtProductId.Text = newId;

        }

        private void dgvCoffee_DoubleClick(object sender, EventArgs e)
        {
            this.txtProductId.Text = this.dgvCoffee.CurrentRow.Cells["ProductId"].Value.ToString();
            this.txtProductName.Text = this.dgvCoffee.CurrentRow.Cells["ProductName"].Value.ToString();
            this.txtProductPrice.Text = this.dgvCoffee.CurrentRow.Cells["Price"].Value.ToString();
        

        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnBack_Click(object sender, EventArgs e)
        {


            this.Hide();
            

        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
