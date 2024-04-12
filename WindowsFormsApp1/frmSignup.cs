using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmSignup : Form
    {
        int companyId;
        public frmSignup()
        {
            InitializeComponent();
            PopulateCompanyDropdown();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void PopulateCompanyDropdown()
        {
            bunifuDropdown1.Items.Clear();

            try
            {
                DB.Connect();

                string query = "SELECT CompName FROM tblcompany;";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                bunifuDropdown1.Items.Add(row["CompName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DB.Disconnect();
            }

        }


        private void btnSignup_Click(object sender, EventArgs e)
        {
            //check if same ba sa pinili na company yung ginawa na company para mabigyan ng admin acccess. kasi pwede namang gumawa ng company pero di yun yung pipiliin mo.


            //bawal p walang laman
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text) && string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text) && bunifuDropdown1.SelectedIndex == -1)
            {
                AMB.GetInstance().Show("FILL ALL FIELDS", 1500);
            }
            else
            {
                //pariho dapat password boi
                if (!(textBox3.Text == textBox4.Text))
                {
                    AMB.GetInstance().Show("Passwords do not Match", 1500);
                    return;
                }

                //validate yung email  kasi dapat may ano @
                if (!textBox2.Text.Contains("@") && !textBox2.Text.Contains(".com"))
                {
                    AMB.GetInstance().Show("Invalid Email", 1500);
                    return;
                }


            }


            try
            {
                DB.Connect();

                string query = "INSERT INTO tblaccount (AccName, AccUser, AccPass, AccType, AccComp, AccAccess) " +
                               "VALUES (@1, @2, @3, @4, @5, @6);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", textBox1.Text);
                        command.Parameters.AddWithValue("@2", textBox2.Text);
                        command.Parameters.AddWithValue("@3", textBox3.Text);
                        command.Parameters.AddWithValue("@5", companyId);
                        if (bunifuDropdown1.SelectedItem.ToString() ==Variables.MAINCOMPANYNAME)
                        {
                            command.Parameters.AddWithValue("@4", "Admin");
                            command.Parameters.AddWithValue("@6", 1);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@4", "User");
                            command.Parameters.AddWithValue("@6", 0);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                AMB.GetInstance().Show("Created successfully.", 1500);
                Variables.MAINCOMPANYNAME = textBox3.Text;
                new frmLogin().Show();
                this.Dispose();
            }

            catch (Exception ex)
            {
                AMB.GetInstance().Show(ex.Message, 1500); //pag may error para makita ko ano error
            }
            finally
            {
                DB.Disconnect();
            }
        }


        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //iscan yung id nung sinelect sa dropdown list para yun ilalagay na AccComp sa account.
            //ginagawa to kasi name lang nasa dropdown, eh dapat CompId kasi yun yung identifier for most parts of the program

            try
            {
                DB.Connect();
                string query = "SELECT CompID FROM tblcompany WHERE CompName = @1;";
                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", bunifuDropdown1.SelectedItem.ToString());
                        object yungid = command.ExecuteScalar();
                        companyId = Convert.ToInt32(yungid);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                DB.Disconnect();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            bunifuDropdown1.Text = null;

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmCompany().Show();
            this.Hide();
        }


    }
}
