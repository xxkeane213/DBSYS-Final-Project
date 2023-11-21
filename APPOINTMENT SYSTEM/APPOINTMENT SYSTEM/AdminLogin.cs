using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace APPOINTMENT_SYSTEM
{
    public partial class AdminLogin : Form
    {
        private SqlConnection con;
        public AdminLogin()
        {
            con = new SqlConnection("Data Source=DESKTOP-LOU3UGG;Initial Catalog=FinalProject;Integrated Security=True");
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                TxtPassword.PasswordChar = '\0';
            }
            else
            {
                TxtPassword.PasswordChar = ' ';
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM users WHERE userName = @Username AND userPassword = @Password";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Username", TxtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Login Successfully!");
                        AdminDatabase adminDatabase = new AdminDatabase();
                        adminDatabase.Show();
                    }
                    else
                    {
                        MessageBox.Show("User does not exist.");
                        TxtUsername.Clear();
                        TxtPassword.Clear();
                    }
                }
                con.Close();
            }
        }
    }
}
