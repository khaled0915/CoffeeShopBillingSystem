using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopBillingSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                MessageBox.Show("Password field is empty. Please enter a password first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.txtPassword.UseSystemPasswordChar = !this.txtPassword.UseSystemPasswordChar;
            if (this.txtPassword.UseSystemPasswordChar)
            {
                this.btnShowPassword.Text = "Show Password";
            }
            else
            {
                this.btnShowPassword.Text = "Hide Password";
            }

        }

      



        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtUserId.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    MessageBox.Show("Please fill all the empty fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a DataAccess instance
                DataAccess da = new DataAccess();

                // First, check if the user ID exists
                string checkUserId = "SELECT * FROM UserInfoTable WHERE id = '" + this.txtUserId.Text + "'";
                DataTable userTable = da.ExecuteQueryTable(checkUserId);

                if (userTable.Rows.Count == 0)
                {
                    MessageBox.Show("Incorrect User ID. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If user ID exists, check if the password is correct

                string checkPasswordSql = "SELECT * FROM UserInfoTable WHERE id = '" + this.txtUserId.Text + "' AND Password = '" + this.txtPassword.Text + "'";
                DataTable passwordTable = da.ExecuteQueryTable(checkPasswordSql);

                if (passwordTable.Rows.Count == 0)
                {
                    MessageBox.Show("Incorrect Password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If login is successful, proceed to open the corresponding dashboard

                string name = passwordTable.Rows[0]["UserName"].ToString();
                string userId = passwordTable.Rows[0]["id"].ToString();
                string role = passwordTable.Rows[0]["Role"].ToString();

                this.Visible = false;

                if (role == "admin")
                {
                    new FormAdmin(name, userId, this).Show();
                    this.Clear();
                }
                else if (role == "employee")
                {
                    //MessageBox.Show("emoloyee login successful")
                    new EmployeeProfile(name, userId, this).Show();

                    this.Clear();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }







        }




        private void Clear()

        {
            this.txtPassword.Text = "";
            this.txtUserId.Text = "";
        }








        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            this.btnLogin.BackColor = SystemColors.Control;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserId.Text = "";
            this.txtPassword.Text = "";
            this.txtUserId.Focus(); // Set focus back to User ID field

            
        }
    }
}
