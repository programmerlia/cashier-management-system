using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace WindowsFormsApp1
{
    public partial class frmReceipt : Form
    {
        public double amountdue = Variables.total;
        public frmReceipt()
        {
            InitializeComponent();
            label1.Text = Variables.MAINCOMPANYNAME;
            label2.Text = Variables.MAINCOMPANYBID.ToString();
            label3.Text = Variables.MAINCOMPANYADDR;

            label1.Left = (splitContainer1.Width - label1.Width) / 2;
            label2.Left = (splitContainer1.Width - label2.Width) / 2;
            label3.Left = (splitContainer1.Width - label3.Width) / 2;
            label4.Left = (splitContainer1.Width - label4.Width) / 2;
            label7.Left = (splitContainer1.Width - label4.Width) / 2;

            splitContainer1.Left = (this.ClientSize.Width - splitContainer1.Width) / 2;
            label5.Left = splitContainer1.Width - label5.Width - 10;
            label6.Left=(splitContainer1.Width - label6.Width) / 2;

            retrieveValues();
            retrieveReceiptValues();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void centerReceipt(object sender, EventArgs e)
        {
            splitContainer1.Left = (this.ClientSize.Width - splitContainer1.Width) / 2;
        }

        private void retrieveValues()
        {
            for (int i=0; i<Variables.prodname.Count; i++) {

                Panel panpan = new Panel { Width = 50, Height = 50, Location = new Point(10, 10), Dock = DockStyle.Top, Margin = new Padding(0, 0, 0, 0), Padding = new Padding(0, 0, 0, 0), };

                flowLayoutPanel1.Controls.Add(panpan);
                panpan.Width = panpan.Parent.Width;


                Label labelName = new Label { Text = Variables.prodname[i], TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize=true };
                labelName.Name = "labelName";
                panpan.Controls.Add(labelName);
                labelName.Top=0;

                panpan.Height=labelName.Height;

                Label labelQuant = new Label { Text = "    " + Variables.prodquant[i]+" @ " + "P" + Variables.prodprice[i], TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true};
                labelQuant.Name = "labelQuant";
                if (Variables.prodquant[i]>1)
                {
                    panpan.Height = (labelName.Height * 2) -2;
                    panpan.Controls.Add(labelQuant);
                }

                labelQuant.Top = labelName.Height-2;

                Label labelTotalPrice = new Label { Text = "P"+Variables.prodqp[i].ToString(), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true};
                labelTotalPrice.Name = "labelTotalPrice";
                panpan.Controls.Add(labelTotalPrice);
                labelTotalPrice.Left=labelTotalPrice.Parent.Width-labelTotalPrice.Width;
                labelTotalPrice.Top = 0;
            }
            label5.Text = "Total: P"+Variables.total.ToString();
        }

        private void retrieveReceiptValues()
        {
            try
            {
                DB.Connect();

                string query = "SELECT * FROM tblreceipt WHERE CompID = @CompID";
                MySqlCommand command = new MySqlCommand(query, DB.con);
                command.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    int rowheight = 0;
                    int rowcount = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Panel recpan = new Panel { Width = 50, Height = 50, Location = new Point(10, 10), Dock = DockStyle.Top, Margin = new Padding(0, 0, 0, 0), Padding = new Padding(0, 0, 0, 0)};

                            flowLayoutPanel2.Controls.Add(recpan);
                            recpan.Width = recpan.Parent.Width;


                            Label labelRecName = new Label { Text = reader.GetString("RecName"), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                            labelRecName.Name = "labelRecName";
                            recpan.Controls.Add(labelRecName);
                            labelRecName.Top = 0;

                            recpan.Height=labelRecName.Height;

                            string rectype=reader.GetString("RecType");
                            string reciord = reader.GetString("RecIorD");
                            double recamount = Convert.ToDouble(reader.GetString("RecAmount"));

                            if (rectype == "P") {
                                recamount = (recamount/100)*Variables.total;
                            } else if (rectype=="N") 
                            {
                            }

                            if (reciord=="D")
                            {
                                amountdue -= recamount;
                            } else if(reciord == "I")
                            {
                                amountdue += recamount;
                            }

                            Label labelRecValue = new Label { Text = "P"+recamount.ToString(), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                            labelRecValue.Name = "labelRecValue";
                            recpan.Controls.Add(labelRecValue);
                            labelRecValue.Left = labelRecValue.Parent.Width - labelRecValue.Width;
                            labelRecValue.Top = 0;

                            rowheight = recpan.Height;
                            rowcount++;
                        }
                    }
                    flowLayoutPanel2.Height = rowheight * rowcount;
                    label6.Top = flowLayoutPanel2.Top + flowLayoutPanel2.Height;
                }
                label6.Text = "Amount Due: P" + amountdue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DB.Disconnect();
            }
        }
    }
}
