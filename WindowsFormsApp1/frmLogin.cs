using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            tbusername.Text = null;
            tbpassword.Text = null;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connect();


                if (string.IsNullOrEmpty(tbusername.Text) || string.IsNullOrEmpty(tbpassword.Text))
                {
                    MessageBox.Show("Empty fields not allowed");
                    return;
                }


                string username = tbusername.Text;
                string password = tbpassword.Text;

                //Binary keyword basically means its case sensitive :)) remember dis
                MySqlCommand msn = new MySqlCommand("SELECT * FROM tblaccount WHERE BINARY AccUser = @Username AND BINARY AccPass = @Password", DB.con);
                msn.Parameters.AddWithValue("@Username", username);
                msn.Parameters.AddWithValue("@Password", password);

                MySqlDataReader reader = msn.ExecuteReader();
                if (reader.Read())
                {
                    // Get some shit for future referecnes bruhfiehrgiohergh
                    Variables.MAINCOMPANYID = reader.GetInt32("AccComp");
                    Variables.MAINNAME = reader.GetString("AccName");
                    Variables.MAINID = reader.GetInt32("AccID");
                    Variables.MAINTYPE = reader.GetString("AccType");
                    bool sossss = reader.GetBoolean("AccAccess");

                    if (sossss.Equals(true))
                    {

                        new frmMain().Show();
                        this.Hide();
                    }
                    else
                    {
                        AMB.GetInstance().Show("Wala Kang Acess Boi, hintay ka", 3000);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Log-In");
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                AMB.GetInstance().Show(ex.Message, 1500);
            }
            finally
            {
                DB.Disconnect();
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            new frmSignup().Show();
            this.Hide();
        }
    }
}


