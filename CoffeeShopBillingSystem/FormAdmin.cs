using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopBillingSystem
{
    public partial class FormAdmin : Form
    {

        private DataAccess Da { get; set; }

        private string userId;
        private FormLogin Fl { get; set; }


      

        public FormAdmin()
        {
            InitializeComponent();
        }




     


        public FormAdmin(String info, string userId, FormLogin fl) : this()
        {
            this.Da = new DataAccess();
            this.userId = userId;
            this.lblAdminName.Text = info.ToUpper();
            this.Fl = fl;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInvoiceHistory_Click(object sender, EventArgs e)
        {
            new FormInvoiceHistory().Show();
        }

        private void btnAllProduct_Click(object sender, EventArgs e)
        {
            
            new FormAllProduct().Show();
        }

        private void btnShowAllEmployee_Click(object sender, EventArgs e)
        {
            
            new FormAllEmployee().Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblAdminName_Click(object sender, EventArgs e)
        {

        }





        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                if (string.IsNullOrWhiteSpace(this.txtUpdatePassword.Text) ||
                    string.IsNullOrWhiteSpace(this.txtConfirmPassword.Text))
                {
                    MessageBox.Show("Please fill both password fields", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (this.txtUpdatePassword.Text != this.txtConfirmPassword.Text)
                {
                    MessageBox.Show("both the Password Feilds Must Match !", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newPassword = this.txtUpdatePassword.Text;

                // Check if admin exists
                string query = "SELECT * FROM UserInfoTable WHERE Id = '" + this.userId + "' AND Role = 'admin';";
                DataTable dt = this.Da.ExecuteQueryTable(query);

                if (dt.Rows.Count == 1)
                {
                    // Update password
                    string updateQuery = @"UPDATE UserInfoTable 
                                SET Password = '" + newPassword + @"'
                                WHERE Id = '" + this.userId + "' AND Role = 'admin';";

                    int count = this.Da.ExecuteDMLQuery(updateQuery);

                    if (count == 1)
                    {
                        MessageBox.Show("Password updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        this.txtUpdatePassword.Text = "";
                        this.txtConfirmPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Password update failed! Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Admin ID not found or unauthorized access!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }














        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("You have been logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Fl.Show();

        }
    }
}
