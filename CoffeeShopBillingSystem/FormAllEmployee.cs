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
    public partial class FormAllEmployee : Form
    {

        private DataAccess Da { get; set; }
        public FormAllEmployee()
        {
            InitializeComponent();
            this.Da = new DataAccess();
           this.PopulateGridView();
            
        }


        private void PopulateGridView(string sql = "select * from UserInfoTable; ")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvShowAllEmployee.AutoGenerateColumns = false;
            this.dgvShowAllEmployee.DataSource = ds.Tables[0];
        }

        private bool isValidToSave()
        {

            if (string.IsNullOrEmpty(this.txtEmployeeId.Text) || string.IsNullOrEmpty(this.txtEmployeeName.Text)  || string.IsNullOrEmpty(this.texEmployeePassword.Text) || string.IsNullOrEmpty(this.txtEmployeeRole.Text ))
                return false;
            else
                return true;

        }


        private void btnAddEmployee_Click(object sender, EventArgs e)
        {


            

            try
            {
                if (!this.isValidToSave())
                {
                    MessageBox.Show("Please fill up all the fields properly");
                    return;
                }





                var query = "select * from UserInfoTable where id = '" + this.txtEmployeeId.Text + "'";

                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {

                    var sql = @"update UserInfoTable
                                set  Role ='" + this.txtEmployeeRole.Text + @"',
                                UserName ='" + this.txtEmployeeName.Text + @"',
                                Password ='" + this.texEmployeePassword.Text + @"'
                                where id ='" + this.txtEmployeeId.Text + "' ;";


                   



                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data has been updated Properly");
                    else
                        MessageBox.Show("data Hasn't been updated properly");




                }




                else
                {
                    var sql = "insert into UserInfoTable values('" + this.txtEmployeeId.Text + "','" + this.txtEmployeeName.Text + "', '" + this.texEmployeePassword.Text+"','" + this.txtEmployeeRole.Text + "');";

                    int count = this.Da.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Employee info Added Successfully");
                    else
                        MessageBox.Show("Data Insertion Failed");
                }

                this.PopulateGridView();
                this.ClearAll();

            }
            catch (Exception exc)
            {
                MessageBox.Show("An Error has occurred: " + exc.Message);
            }





        }



        private void ClearAll()
        {
            this.txtEmployeeId.Clear();
            this.txtEmployeeName.Clear();
            this.texEmployeePassword.Clear();
            this.txtEmployeeRole.Clear();
            this.txtSearchEmployee.Clear();

            this.dgvShowAllEmployee.ClearSelection();
            this.AutoIdGenerate();
        }


        private void AutoIdGenerate()
        {
            var query = "select max(id) from UserInfoTable;";
            var dt = this.Da.ExecuteQueryTable(query);
            var oldId = dt.Rows[0][0].ToString();
            String[] temp = oldId.Split('-');
            var num = Convert.ToInt32(temp[1]);
            var newId = "u-" + (++num).ToString();
            this.txtEmployeeId.Text = newId;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormAllEmployee_Load(object sender, EventArgs e)
        {
            this.dgvShowAllEmployee.ClearSelection();
            this.AutoIdGenerate();
        }

        private void dgvAllEmployee_doubleClick(object sender, EventArgs e)
        {
            this.txtEmployeeId.Text = this.dgvShowAllEmployee.CurrentRow.Cells["id"].Value.ToString();
            this.txtEmployeeName.Text = this.dgvShowAllEmployee.CurrentRow.Cells["UserName"].Value.ToString();
            this.texEmployeePassword.Text = this.dgvShowAllEmployee.CurrentRow.Cells["Password"].Value.ToString();
            this.txtEmployeeRole.Text = this.dgvShowAllEmployee.CurrentRow.Cells["Role"].Value.ToString();

            
        }

        private void btnShowAllEmployee_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
         

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgvShowAllEmployee.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var id = this.dgvShowAllEmployee.CurrentRow.Cells[0].Value.ToString();
                var UserName = this.dgvShowAllEmployee.CurrentRow.Cells[1].Value.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + UserName + "?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                var sql = "delete from UserInfoTable where id = '" + id + "';";
                var count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                    MessageBox.Show(UserName.ToUpper() + " has been removed from the list.");
                else
                    MessageBox.Show("Data hasn't been removed properly");

                this.PopulateGridView();
                this.ClearAll();


            }

            catch (Exception exc)
            {
                MessageBox.Show("An error has occured, please check: " + exc.Message);

            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            var sql = "select * from UserInfoTable where UserName = '" + this.txtSearchEmployee.Text + "';";
            this.PopulateGridView(sql);
            this.ClearAll();

        }

        private void btnBackWindow_Click(object sender, EventArgs e)
        {
            this.Hide();
           
           
        }
    }
}
