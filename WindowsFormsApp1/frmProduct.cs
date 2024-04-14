using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            getDropdownItems();
            panel1.Hide();

            Variables.setColors(Variables.clrheader, this, panel1);
            Variables.setColorsBunifu(Variables.clrmainbtn, btnUpload, bunifuButton1, bunifuButton2);
            linkLabel1.BackColor = Variables.clrheader;
            linkLabel2.BackColor = Variables.clrheader;
            linkLabel3.BackColor = Variables.clrheader;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string pclass = bunifuDropdown1.SelectedItem.ToString();

            label1.Text = pclass;

            getPclassId(pclass);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void insertNewClass(string text)
        {
            try
            {
                DB.Connect();

                string query = "INSERT INTO tblcategory (CompID, CategoryName)" +
                           "VALUES (@1, @2);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", Variables.MAINCOMPANYID);
                        command.Parameters.AddWithValue("@2", text);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
            }
            finally
            {
                DB.Disconnect();
            }
        }

        private int getPclassId(string pclass)
        {
            int categoryId = 0;
            string query = "SELECT ID FROM tblcategory WHERE CategoryName = @1 AND CompID = @2";
            try
            {
                DB.Connect();
                using (MySqlConnection connection = DB.con)
                {
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", pclass);
                        command.Parameters.AddWithValue("@2", Variables.MAINCOMPANYID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                categoryId = reader.GetInt32(0);
                            }
                        }
                    }
                }
                DB.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return categoryId;
        }

        private void getDropdownItems()
        {
            bunifuDropdown1.Items.Clear();

            try
            {
                DB.Connect();

                string query = "SELECT CategoryName FROM tblcategory WHERE CompID = @1;";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", Variables.MAINCOMPANYID);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            foreach (DataRow row in dataTable.Rows)
                            {
                                bunifuDropdown1.Items.Add(row["CategoryName"].ToString());
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

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            string pclass = bunifuDropdown1.SelectedItem.ToString();
      
            int pclassid = getPclassId(pclass);


            try
            {
                DB.Connect();

                string query = "INSERT INTO tblproduct (ProdName, ProdClass, ProdImg, ProdComp, Price) " +
                           "VALUES (@ProdName, @ProdClass, @ProdImg, @ProdComp, @p);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProdName", textBox1.Text);
                        command.Parameters.AddWithValue("@ProdClass", pclassid);
                        command.Parameters.AddWithValue("@ProdImg", validateImg());
                        command.Parameters.AddWithValue("@ProdComp", Variables.MAINCOMPANYID);
                        command.Parameters.AddWithValue("@p", textBox3.Text);
                        command.ExecuteNonQuery();
                    }
                }
                AMB.GetInstance().Show("Item Added.", 1500);
                this.Hide();
                    allClear();
            }

            catch (Exception ex)
            {

                Console.WriteLine(ex);             
            }
            finally
            {
                DB.Disconnect();
            }
        }
        private void allClear()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            bunifuDropdown1.Text = null;
            pictureBox1.Image = null;
        }
        private byte[] validateImg()
        {
            byte[] img;
            if(pictureBox1.Image == null)
            {
                img = Shit.ImageToBlob(Properties.Resources.logo);
            }
            else
            {
                img =  Shit.ImageToBlob(pictureBox1.Image);
            }
            return img;
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Show();
            textBox2.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             insertNewClass(textBox2.Text);
            panel1.Hide();
            getDropdownItems();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Hide();
            getDropdownItems();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
