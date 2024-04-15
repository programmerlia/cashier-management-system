using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }


        private void btnUpload_Click(object sender, EventArgs e)
        //pag pindot ng upload button basta mga process lang ito para ilagay yung image sa picture box
        //may file dialog na lalabas tapos pagpindot ng ok, converson from file to byte
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

        private void btnClear_Click(object sender, EventArgs e)
        //nagdedelete ng mga laman ng textboxes and picture box
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            pictureBox1.Image = null;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        //check muna kung may laman lahat ng textbox
        //tapos check yung Picture box kung may laman, if walang laman edi magstore ng default na logo 
        //ayun add na sa dbase

        {
            if (string.IsNullOrEmpty(textBox1.Text) &&
                string.IsNullOrEmpty(textBox2.Text) &&
                string.IsNullOrEmpty(textBox3.Text) &&
                string.IsNullOrEmpty(textBox4.Text))
            {

                AMB.GetInstance().Show("Please fill all fields", 2000);
            }
            else //if all fields are filled
            {
                if (pictureBox1.Image == null) //default logo pag wala yung luma
                {
                    pictureBox1.Image = Properties.Resources.logo;
                }

                try
                {
                    DB.Connect();

                    string query = "INSERT INTO tblcompany (CompBID, CompName, CompAddr, CompType, CompImg) " +
                                   "VALUES (@CompBID, @CompName, @CompAddress, @CompType, @CompImg);";

                    using (MySqlConnection connection = DB.con)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@CompBID", textBox1.Text);
                            command.Parameters.AddWithValue("@CompName", textBox2.Text);
                            command.Parameters.AddWithValue("@CompAddress", textBox3.Text);
                            command.Parameters.AddWithValue("@CompType", textBox4.Text);
                            command.Parameters.AddWithValue("@CompImg", Shit.ImageToBlob(pictureBox1.Image)); //basta yung func return sya ng blob, img as parameters
                            command.ExecuteNonQuery();
                            sql.addHistTbl(textBox2.Text.ToString());
                        }
                    }
                    AMB.GetInstance().Show("Created successfully.", 1500);
                    Variables.MAINCOMPANYNAME = textBox2.Text;

                }
                catch (Exception ex)
                {
                    AMB.GetInstance().Show(ex.Message, 1500); //pag may error para makita ko ano error
                }
                finally
                {
                    DB.Disconnect();
                }



                try
                {
                    DB.Connect();

                    //set theme colors ng newly created company to default theme color
                    string queryy = "INSERT INTO tbltheme (colorheader, colormainbutton, colorsecondarybutton) " +
                                    "VALUES (@colorheader, @colormainbutton, @colorsecondarybutton);";

                    using (MySqlConnection connection = DB.con)
                    {
                        using (MySqlCommand command = new MySqlCommand(queryy, connection))
                        {
                            //yung mga hex codes here equivalent ng default rgb values/system colors
                            command.Parameters.AddWithValue("@colorheader", "#485f78");
                            command.Parameters.AddWithValue("@colormainbutton", "#99B4D1");
                            command.Parameters.AddWithValue("@colorsecondarybutton", "#696969");
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    AMB.GetInstance().Show(ex.Message, 1500); //pag may error para makita ko ano error
                }
                finally
                {
                    DB.Disconnect();
                }

                new frmSignup().Show();
                this.Hide();
            }
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frmCompany_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
