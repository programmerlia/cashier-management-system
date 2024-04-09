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


            try
            {
                while (tableLayoutPanel1.Controls.Count > 0)
                {
                    tableLayoutPanel1.Controls[0].Dispose();
                }
                DB.Connect();
                MySqlCommand msn = new MySqlCommand("SELECT * FROM tblproduct WHERE ProdComp=@CompID", DB.con);
                msn.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);

                MySqlDataReader reader = msn.ExecuteReader();
                int count = 0;
                int currentRow = 0;
                int currentColumn = 0;
                /*if (reader.HasRows)
                {
                    do
                    {
                        if ((count + 1) % 6 == 0)
                        {
                            currentRow++;
                            currentColumn = 0;
                            tableLayoutPanel1.RowCount += 1;
                        }
                        while (reader.Read())
                        {
                            tableLayoutPanel1.GetControlFromPosition(currentRow, currentColumn).;
                            //tableLayoutPanel1.GetControlFromPosition(currentRow, currentColumn).Controls.Add(new Label { Text = "Type:", Anchor = AnchorStyles.Left, AutoSize = true }, currentRow, currentColumn);
                        }
                        currentColumn++;
                    } while (reader.NextResult());
                    count++;
                    reader.Close();
                }*/

                if (reader.HasRows)
                {

                    while (reader.Read()) 
                    {
                    if ((count + 1) % 6 == 0)
                        {
                            currentRow++;
                            currentColumn = 0;
                            tableLayoutPanel1.RowCount += 1;
                        }


                        GroupBox groupBox1 = new GroupBox { Width = 240, Height = 180 };
                        GroupBox groupBox2 = new GroupBox { Width = 100, Height = 45, Location = new Point(13, 120) };
                        tableLayoutPanel1.Controls.Add(groupBox1, currentColumn, currentRow);
                        Label label1 = new Label { Text = reader.GetString("ProdName"), Location=new Point (45,97), AutoSize=true};
                        Button button1 = new Button { Text = "-", Location = new Point(10,10), Size=new Size(34,34)};
                        button1.Click +=button1_Click;
                        Button button2 = new Button { Text = "+", Location = new Point(55,10), Size = new Size(34, 34) };
                        button2.Click += button2_Click;
                        Label label2 = new Label { Text = "0", Location = new Point(43,20), AutoSize = true };
                        groupBox1.Controls.Add(label1);
                        groupBox2.Controls.Add(button1);
                        groupBox2.Controls.Add(button2);
                        groupBox2.Controls.Add(label2);
                        groupBox1.Controls.Add(groupBox2);

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
    }
}
