using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            try
            {
                DB.Connect();

                string query = "INSERT INTO tblproduct (ProdName, ProdClass, ProdImg, ProdComp) " +
                           "VALUES (@ProdName, @ProdClass, @ProdImg, @ProdComp);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProdName", textBox1.Text);
                        command.Parameters.AddWithValue("@ProdClass", textBox2.Text);
                        command.Parameters.AddWithValue("@ProdImg", Shit.ImageToBlob(pictureBox1.Image));
                        command.Parameters.AddWithValue("@ProdComp", Variables.MAINCOMPANYID);
                        command.ExecuteNonQuery();
                    }
                }
                AMB.GetInstance().Show("Created successfully.", 1500);
                this.Hide();
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
    }
}
