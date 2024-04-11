using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
            LoadCategories();
        }

        private void frmMain2_Activated(object sender, EventArgs e)
        {
            try
            {
                DB.Connect();

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
                    pclogo.Image = System.Drawing.Image.FromStream(ms);

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

            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
        }

        private void loadProducts(string cmd)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                DB.Connect();

                MySqlCommand msn = new MySqlCommand(cmd, DB.con);
                msn.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);
                msn.Parameters.AddWithValue("@ProdName", "%" + textBox1.Text + "%");

                MySqlDataReader reader = msn.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BunifuCards bunifuCard = new BunifuCards { Height = 250, Width = 200, BorderRadius = 20, Padding = new Padding(10), color = Variables.clrheader };
                        flowLayoutPanel1.Controls.Add(bunifuCard);

                        Panel panel1 = new Panel { Dock = DockStyle.Fill };
                        bunifuCard.Controls.Add(panel1);

                        PictureBox pictureBox = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Size = new Size(130, 130), Location = new Point(10, 10), };
                        byte[] imageData = (byte[])reader["ProdImg"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                        }
                        panel1.Controls.Add(pictureBox);

                        Panel panel2 = new Panel { Dock = DockStyle.Bottom, Size = new Size(198, 90) };
                        bunifuCard.Controls.Add(panel2);

                        Label labelProdName = new Label { Text = reader.GetString("ProdName"), Font = new Font("Century Gothic", 12, FontStyle.Bold), Size = new Size(176, 48), Location = new Point(10, 10), TextAlign = ContentAlignment.MiddleCenter };
                        labelProdName.Name = "labelProdName";
                        panel2.Controls.Add(labelProdName);

                        BunifuButton buttonMinus = new BunifuButton { Text = "-", Size = new Size(20, 20), IdleBorderRadius = 20, IdleBorderColor = Color.Transparent, BackColor = Color.Transparent, IdleFillColor = Variables.clrsecondarybtn, ForeColor = Color.White, Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(21, 68) };
                        buttonMinus.Name = "buttonMinus";
                        buttonMinus.Click += button1_Click;
                        panel2.Controls.Add(buttonMinus);

                        Label labelQuantity = new Label { Text = "0", TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 12), ForeColor = Color.DarkGray, Location = new Point(55, 68), Size = new Size(20, 20) };
                        labelQuantity.Name = "labelQuantity";

                        panel2.Controls.Add(labelQuantity);


                        BunifuButton buttonPlus = new BunifuButton { Text = "+", Size = new Size(20, 20), IdleBorderRadius = 20, BackColor = Color.Transparent, IdleBorderColor = Color.Transparent, IdleFillColor = Variables.clrsecondarybtn, ForeColor = Color.White, Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(80, 68) };
                        buttonPlus.Name = "buttonPlus";
                        buttonPlus.Click += button2_Click;
                        panel2.Controls.Add(buttonPlus);
                      

                        BunifuButton buttonOrder = new BunifuButton { Text = "order", Size = new Size(60, 20), IdleBorderRadius = 10, BackColor = Color.Transparent, IdleBorderColor = Color.Transparent, IdleFillColor = Variables.clrsecondarybtn, ForeColor = Color.White, Cursor = Cursors.Hand, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(116, 68) };
                        buttonOrder.Name = "buttonOrder";
                        buttonOrder.Click += buttonOrder_Click;
                      
                        panel2.Controls.Add(buttonOrder);
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




        private void AddRowToDataGridView1(Label n, Label qtty)
        {

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(bunifuDataGridView1);
            row.Cells[0].Value = n.Text.ToString();
            row.Cells[1].Value = qtty.Text.ToString();
            bunifuDataGridView1.Rows.Add(row);
        }



        private void button2_Click(object sender, EventArgs e)
        {

            Control button = (Control)sender;
            Control parent = button.Parent; 
            Label lbl = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");
            foreach (Control c in parent.Controls)
            {
                Debug.WriteLine("Control: " + c.Name);
            }
            lbl.Text = (Convert.ToInt64(lbl.Text) + 1).ToString(); 


        }




        private void button1_Click(object sender, EventArgs e)
        {
            {
                Control button= (Control)sender;
                Control parent = button.Parent;
                Label lbl = parent.Controls.OfType <Label> ().FirstOrDefault(l => l.Name == "labelQuantity");

                lbl.Text = (Convert.ToInt64(lbl.Text) - 1).ToString();
                if (Convert.ToInt64(lbl.Text) < 0)
                {
                    lbl.Text = "0";
                }

            }

        }



        private void btnsearch_Click(object sender, EventArgs e)
        {
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID AND ProdName LIKE @ProdName");
        }

        private void btnviewallproducts_Click(object sender, EventArgs e)
        {
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
            textBox1.Text = "";
        }


        private void btnaddproduct_Click(object sender, EventArgs e)
        {
            new frmProduct().ShowDialog();
            LoadCategories();
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadCategories()
        {
            try
            {
                pnlcategory.Controls.Clear();

                DB.Connect();

                string query = "SELECT CategoryName, ID FROM tblcategory WHERE CompID = @CompID";
                MySqlCommand command = new MySqlCommand(query, DB.con);
                command.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string categoryName = reader.GetString("CategoryName");
                        int categoryId = reader.GetInt32("ID");

                        BunifuButton btnCategory = new BunifuButton();
                        btnCategory.Dock = DockStyle.Top;
                        btnCategory.Height = 55;
                        btnCategory.IdleFillColor = Variables.clrmainbtn;
                        btnCategory.IdleBorderRadius = 10;
                        btnCategory.IdleBorderColor = Color.Transparent;
                        btnCategory.ForeColor = Color.White;
                        btnCategory.Text = categoryName;
                        btnCategory.Click += (sender, e) => BtnCategory_Click(sender, e, categoryId);

                        btnCategory.onHoverState.BorderColor = Color.Transparent;
                        btnCategory.onHoverState.FillColor = SystemColors.ControlDark;
                        btnCategory.onHoverState.BorderColor = Color.Black;
                        btnCategory.onHoverState.BorderColor = Color.Transparent;
                        btnCategory.onHoverState.BorderColor = Color.Black;
                        btnCategory.onHoverState.BorderColor = Color.White;

                        pnlcategory.Controls.Add(btnCategory);
                    }
                }
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

        private void BtnCategory_Click(object sender, EventArgs e, int categoryId)
        {
            string query = "SELECT * FROM tblproduct WHERE ProdClass = " + categoryId;
            loadProducts(query);
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {

            Control button = (Control)sender;
            Control parent = button.Parent;
            Label lbl = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");
            Label lbl2 = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelProdName");
            AddRowToDataGridView1(lbl, lbl2);
        }
    }
}
