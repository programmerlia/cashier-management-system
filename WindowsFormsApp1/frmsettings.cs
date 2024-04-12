using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using MySql.Data.MySqlClient;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp1
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
            resetColors();
            panel3.Hide();

            try
            {
                flowLayoutPanel2.Controls.Clear();

                DB.Connect();

                String query = "SELECT AccUser FROM tblaccount WHERE AccComp=@CompID AND AccAccess=0;";

                MySqlCommand msn = new MySqlCommand(query, DB.con);
                msn.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);

                MySqlDataReader reader = msn.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create 
                        int cardwidth = flowLayoutPanel2.Width;
                        BunifuCards bunifuCard = new BunifuCards { Height = 70, Width = cardwidth, BorderRadius = 20, Padding = new Padding(10), color = Variables.clrheader };
                        flowLayoutPanel2.Controls.Add(bunifuCard);

                        Panel panel1 = new Panel { Dock = DockStyle.Fill, BackColor = Variables.clrheader };
                        bunifuCard.Controls.Add(panel1);

                        Label label1 = new Label { AutoSize = true, Text=reader.GetString(0), ForeColor=Color.White, BackColor=Color.Transparent, MinimumSize=new Size(0,panel1.Height), TextAlign = ContentAlignment.MiddleLeft, Font=new Font("Century Gothic", 12) };
                        panel1.Controls.Add(label1);

                        Panel panel2 = new Panel { Dock = DockStyle.Right, BackColor = Color.Transparent, Width = 80, Height=panel1.Height };
                        panel1.Controls.Add(panel2);

                        int btnsize = 30;
                        BunifuButton buttonYes = new BunifuButton { Text = "v", Size = new Size(btnsize, btnsize), IdleBorderRadius = btnsize, BackColor = Color.Transparent, IdleBorderColor = Color.Transparent, IdleFillColor = Color.Green, ForeColor = Color.White, Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleCenter, Location=new Point(0,10) };
                        buttonYes.Name = "buttonYes";
                        buttonYes.Click += buttonYes_Click;
                        panel2.Controls.Add(buttonYes);
                        //--yung x-coordinate ng buttonNo ay panel2 width minus buttonNo width
                        BunifuButton buttonNo = new BunifuButton { Text = "x", Size = new Size(btnsize, btnsize), IdleBorderRadius = btnsize, BackColor = Color.Transparent, IdleBorderColor = Color.Transparent, IdleFillColor = Color.Red, ForeColor = Color.White, Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(50, 10) };
                        buttonNo.Name = "buttonNo";
                        buttonNo.Click += buttonNo_Click;
                        panel2.Controls.Add(buttonNo);
                    }
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

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

        }

        private void btnprofile_Click(object sender, EventArgs e)
        {
                    }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bttntheme_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }



        private void bttnreceipt_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void bttnaccess_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }


        private void lblColorChange(object sender, EventArgs e)
        {
            Color c = Color.Black;
            ColorDialog cd = new ColorDialog();
            Control label = (Control)sender;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                c = cd.Color;
            }

            label.BackColor = c;
        }
        private static String ToHex(System.Drawing.Color c)=> $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        private void resetColors()
        {
            Variables.setColors(Variables.clrheader, lblcol1);
            Variables.setColorsBunifu(Variables.clrmainbtn, bttntheme, bttnreceipt, bttnaccess);
            Variables.setColors(Variables.clrmainbtn, lblcol2);
            Variables.setColors(Variables.clrsecondarybtn, lblcol3);
        }

        private void bttnapply_Click(object sender, EventArgs e)
        {
            try
            {
                DB.Connect();

                string queryy = "UPDATE tbltheme SET colorheader=@colorheader, colormainbutton=@colormainbutton, colorsecondarybutton=colorsecondarybutton WHERE ThemeID=@ID;";

                Variables.clrheader = lblcol1.BackColor;
                Variables.clrmainbtn = lblcol2.BackColor;
                Variables.clrsecondarybtn = lblcol3.BackColor;

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(queryy, connection))
                    {
                        command.Parameters.AddWithValue("@colorheader", ToHex(lblcol1.BackColor));
                        command.Parameters.AddWithValue("@colormainbutton", ToHex(lblcol2.BackColor));
                        command.Parameters.AddWithValue("@colorsecondarybutton", ToHex(lblcol3.BackColor));
                        command.Parameters.AddWithValue("@ID", Variables.MAINCOMPANYID);
                        command.ExecuteNonQuery();
                    }
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

            resetColors();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            //first parent - panel2, second parent - panel1, third parent - bunifucard
            flowLayoutPanel2.Controls.Remove(cont.Parent.Parent.Parent);
            try
            {
                DB.Connect();

                string queryy = "UPDATE tblaccount SET AccAccess=1 WHERE BINARY AccUser=@User;";

                string usertext = cont.Parent.Parent.Controls.OfType<Label>().FirstOrDefault().Text;

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(queryy, connection))
                    {
                        command.Parameters.AddWithValue("@User", usertext);
                        command.ExecuteNonQuery();
                    }
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

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            flowLayoutPanel2.Controls.Remove(cont.Parent.Parent.Parent);
        }

        private void bttntheme_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void bttnreceipt_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            loadtblReceipt();
        }

        private void bttnaccess_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }


        private void loadtblReceipt() {
            try
            {
                DB.Connect();
                string query = @"
                    SELECT 
                        RecName AS Details,
                        CONCAT(
                            CASE 
                                WHEN RecIorD = 'D' THEN '-'
                                WHEN RecIorD = 'I' THEN '+'
                                ELSE ''
                            END,
                            ' ',
                            RecAmount,
                            CASE 
                                WHEN RecType = 'P' THEN '%'
                                WHEN RecType = 'N' THEN ''
                                ELSE RecType
                            END
                        ) AS Amount
                    FROM tblreceipt
                    WHERE CompId = @1";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", Variables.MAINCOMPANYID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                           
                            tblreceipt.Rows.Clear();

                            while (reader.Read())
                            {
                                string details = reader.GetString("Details"); 
                                string amount = reader.GetString("Amount");

                                tblreceipt.Rows.Add(details, amount);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {

                DB.Disconnect();
            }
        }

        private void bttninsert_Click(object sender, EventArgs e)
        {
            panel3.Show();
            clearpanel7();
            bttninsert.Enabled = false;

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            bttninsert.Enabled = true;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            bttninsert.Enabled = true;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                AMB.GetInstance().Show("Fill All Field", 1500);
            }
            else
            {

                try
                {
                    string recIorD;
                    if (bunifuRadioButton1.Checked) { recIorD = "I"; } else { recIorD = "D"; };
                    string recName = textBox1.Text;
                    string recValue =  textBox2.Text;
                    string recType;
                    if (bunifuRadioButton4.Checked) { recType = "P"; } else { recType = "N"; };

                    DB.Connect();
                    string query = "INSERT INTO tblreceipt (CompID, RecName, RecAmount, RecIorD, RecType) VALUES (@1, @2, @3, @4, @5)";
                    using (MySqlConnection connection = DB.con)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@1", Variables.MAINCOMPANYID);
                            command.Parameters.AddWithValue("@2", recName);
                            command.Parameters.AddWithValue("@3", recValue);
                            command.Parameters.AddWithValue("@4", recIorD);
                            command.Parameters.AddWithValue("@5", recType);
                            command.ExecuteNonQuery();
                            loadtblReceipt();
                            
                        }
                    }
                    DB.Disconnect();
                }
                catch (Exception ex)
                {
                     AMB.GetInstance().Show("An error occurred:" + ex.Message, 1500);
                }
                
            }
        }

        private void clearpanel7() {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void tblreceipt_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            foreach (DataGridViewColumn column in tblreceipt.Columns)
            {
                Console.WriteLine(column.Name);
            }
            try
            {
                DB.Connect();
                string recName = e.Row.Cells[0].Value.ToString();
                string deleteQuery = "DELETE FROM tblreceipt WHERE RecName = @1 AND CompID = @2";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@1", recName);
                        command.Parameters.AddWithValue("@2", Variables.MAINCOMPANYID);
                        command.ExecuteNonQuery();
                    }
                }
                DB.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting row: " + ex.Message);
            }
        }
    }
    }


