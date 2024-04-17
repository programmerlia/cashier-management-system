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

namespace Cashetor
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
            label12.Text = Variables.MAINNAME;
            retrieveValues();
            retrieveReceiptValues();

        }
        private void retrieveValues()
        {
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            for (int i = 0; i < Variables.prodname.Count; i++)
            {

                Panel panpan = new Panel { Width = flowLayoutPanel2.Width, Location = new Point(10, 10),Margin = new Padding(0, 0, 0, 0), Padding = new Padding(0, 0, 0, 0), };

                flowLayoutPanel2.Controls.Add(panpan);

                Label labelName = new Label { Text = Variables.prodname[i], TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true, MaximumSize = new Size(196, 0)};
                labelName.Name = "labelName";
                panpan.Controls.Add(labelName);
                labelName.Top = 0;

                panpan.Height = labelName.Height;

                Label labelQuant = new Label { Text = "    " + Variables.prodquant[i] + " @ " + "P" + Variables.prodprice[i], TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                labelQuant.Name = "labelQuant";
                if (Variables.prodquant[i] > 1)
                {
                    panpan.Height = (labelName.Height * 2) - 2;
                    panpan.Controls.Add(labelQuant);
                }

                labelQuant.Top = labelName.Height - 2;

                Label labelTotalPrice = new Label { Text = "P" + Variables.prodqp[i].ToString(), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                labelTotalPrice.Name = "labelTotalPrice";
                panpan.Controls.Add(labelTotalPrice);
                labelTotalPrice.Left = labelTotalPrice.Parent.Width - labelTotalPrice.Width;
                labelTotalPrice.Top = 0;
            }
            label5.Text = "Total: P" + Variables.total.ToString();
        }

        private void retrieveReceiptValues()
        {
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
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
                            Panel recpan = new Panel { Width = flowLayoutPanel3.Width, Height = 50, Location = new Point(10, 10), Margin = new Padding(0, 0, 0, 0), Padding = new Padding(0, 0, 0, 0) };


                            flowLayoutPanel3.Controls.Add(recpan);

                            Label labelRecName = new Label { Text = reader.GetString("RecName"), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                            labelRecName.Name = "labelRecName";
                            recpan.Controls.Add(labelRecName);
                            labelRecName.Top = 0;

                            recpan.Height = labelRecName.Height;

                            string rectype = reader.GetString("RecType");
                            string reciord = reader.GetString("RecIorD");
                            double recamount = Convert.ToDouble(reader.GetString("RecAmount"));

                            if (rectype == "P")
                            {
                                recamount = (recamount / 100) * Variables.total;
                            }
                            else if (rectype == "N")
                            {
                            }

                            if (reciord == "D")
                            {
                                amountdue -= recamount;
                            }
                            else if (reciord == "I")
                            {
                                amountdue += recamount;
                            }

                            Label labelRecValue = new Label { Text = "P" + recamount.ToString(), TextAlign = ContentAlignment.MiddleLeft, Font = new Font("Century Gothic", 10), ForeColor = Color.Black, Location = new Point(1, 7), AutoSize = true };
                            labelRecValue.Name = "labelRecValue";
                            recpan.Controls.Add(labelRecValue);
                            labelRecValue.Left = labelRecValue.Parent.Width - labelRecValue.Width;
                            labelRecValue.Top = 0;

                            rowheight = recpan.Height;
                            rowcount++;
                        }
                        
                    }
                    //flowLayoutPanel3.Height = rowheight * rowcount;
                    //label6.Top = flowLayoutPanel3.Top + flowLayoutPanel3.Height;
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
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReceipt2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
