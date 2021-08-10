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

namespace ProjectNhom
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Select();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9L0KUCO\SQLEXPRESS;Initial Catalog=ShopPhone;Integrated Security=True");
            //Amazon
            SqlConnection con = new SqlConnection(@"Data Source=testdatabaseaws.c3lyzgwnjxrk.ap-southeast-1.rds.amazonaws.com;Initial Catalog=ShopPhone;User ID=admin;Password=12345678");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count (*) From Users Where userID='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                FormHome formHome = new FormHome() { userID = txtUsername.Text };
                formHome.Show();
            }
            else
            {
                MessageBox.Show("Try again! Check username or password.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormRegister formRegister = new FormRegister();
            formRegister.Show();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
