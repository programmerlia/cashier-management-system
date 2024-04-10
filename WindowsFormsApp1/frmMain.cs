using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        //curselclass = currently selected food class
        public String curselclass = "";
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            new frmProduct().ShowDialog();
        }


        private void formActivated(object sender, EventArgs e)
        {
            try
            {
                DB.Connect();

                //Binary keyword basically means its case sensitive :)) remember dis
                MySqlCommand msn = new MySqlCommand("SELECT * FROM tblcompany WHERE BINARY CompID = @ID", DB.con);
                msn.Parameters.AddWithValue("@ID", Variables.MAINCOMPANYID);

                MySqlDataReader reader = msn.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text = reader.GetString("CompName");
                    label2.Text = reader.GetInt32("CompBID").ToString();
                    label3.Text = reader.GetString("CompAddr");

                    reader.Close();
                }

                MySqlDataAdapter da = new MySqlDataAdapter(msn);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblcompany");
                int c = ds.Tables["tblcompany"].Rows.Count;

                if (c > 0)
                {
                    byte[] img = (byte[])ds.Tables["tblcompany"].Rows[0][6];
                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);

                }
            }


            catch (Exception ex)
            {
                AMB.GetInstance().Show(ex.Message, 1500);
            }
            finally
            {
                DB.Disconnect();
            }

            createTableFunc("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            foreach (var lbl in control.Parent.Controls.OfType<Label>())
            {
                lbl.Text = (Convert.ToInt64(lbl.Text)-1).ToString();
                if (Convert.ToInt64(lbl.Text)<0) 
                {
                    lbl.Text = "0";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            foreach (var lbl in control.Parent.Controls.OfType<Label>())
            {
                lbl.Text = (Convert.ToInt64(lbl.Text) + 1).ToString();
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            createTableFunc("SELECT * FROM tblproduct WHERE ProdComp=@CompID AND ProdName LIKE @ProdName");
        }


        private void createTableFunc(string cmd) 
        {
            try
            {
                int setcolumncount = 5;
                tableLayoutPanel1.ColumnCount = setcolumncount;
                while (tableLayoutPanel1.Controls.Count > 0)
                {
                    tableLayoutPanel1.Controls[0].Dispose();
                }
                DB.Connect();


                MySqlCommand msn = new MySqlCommand(cmd, DB.con);
                msn.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);
                msn.Parameters.AddWithValue("@ProdName", "%"+textBox1.Text+"%");

                MySqlDataReader reader = msn.ExecuteReader();
                int count = 0;
                int currentRow = 0;
                int currentColumn = 0;


                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if ((count + 1) % setcolumncount == 0)
                        {
                            currentRow++;
                            currentColumn = 0;
                            tableLayoutPanel1.RowCount += 1;
                        }

                        GroupBox groupBox1 = new GroupBox { Height = 180, Padding = new Padding(5, 5, 5, 5) };
                        Panel panel1 = new Panel { Width = 100, Height = 45, Location = new Point(13, 110) };
                        tableLayoutPanel1.Controls.Add(groupBox1, currentColumn, currentRow);
                        Label label1 = new Label { Text = reader.GetString("ProdName"), Font = new Font("Century Gothic", 10), AutoSize = true };
                        Button button1 = new Button { Text = "-", Location = new Point(10, 10), Size = new Size(34, 34) };
                        button1.Click += button1_Click;
                        Button button2 = new Button { Text = "+", Location = new Point(55, 10), Size = new Size(34, 34) };
                        button2.Click += button2_Click;
                        Label label2 = new Label { Text = "0", Location = new Point(43, 20), AutoSize = true };
                        groupBox1.Controls.Add(label1);
                        panel1.Controls.Add(button1);
                        panel1.Controls.Add(button2);
                        panel1.Controls.Add(label2);
                        groupBox1.Controls.Add(panel1);
                        label1.Left = (label1.Parent.Size.Width - label1.Size.Width) / 2;
                        label1.Top = 110;
                        panel1.Left = (panel1.Parent.Size.Width - panel1.Size.Width) / 2;
                        panel1.Top = 120;

                    };
                    count++;
                    currentColumn++;


                    reader.Close();
                }
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

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            createTableFunc("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
            textBox1.Text = "";
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
