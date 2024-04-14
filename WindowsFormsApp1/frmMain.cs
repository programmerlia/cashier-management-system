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
        double total = 0;
        public frmMain()
        {
            InitializeComponent();
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");

            flowLayoutPanel2.Controls.Clear();
            LoadCategories();
            if (Variables.MAINTYPE == "Admin")
            {
                bttnsetting.Visible = true;
            } else if (Variables.MAINTYPE=="User")
            {
                bttnsetting.Visible = false;
            }

            DB.Connect();
            try
            {
                

                MySqlCommand msn = new MySqlCommand("SELECT * FROM tbltheme WHERE ThemeID = @ID", DB.con);
                msn.Parameters.AddWithValue("@ID", Variables.MAINCOMPANYID);

                MySqlDataReader reader = msn.ExecuteReader();
                while (reader.Read()) {
                    Variables.clrheader = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colorheader"));
                    Variables.clrmainbtn = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colormainbutton"));
                    Variables.clrsecondarybtn = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colorsecondarybutton"));

                    Variables.setColors(Variables.clrheader, panel1);
                    Variables.setColorsBunifu(Variables.clrmainbtn, btnviewallproducts, btnsearch, btnaddproduct);

                }
                reader.Close();
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
            resetColors();
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
                        BunifuCards bunifuCard = new BunifuCards { Size = new Size(150, 150), BorderRadius = 20, color = Variables.clrheader };
                        flowLayoutPanel1.Controls.Add(bunifuCard);

                        PictureBox pictureBox = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Size = new Size(80, 80), Location = new Point(30, 10), };
                        pictureBox.Click += buttonOrder_Click;
                        byte[] imageData = (byte[])reader["ProdImg"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                        }
                        bunifuCard.Controls.Add(pictureBox);
                        pictureBox.Left = (pictureBox.Parent.Width - pictureBox.Width) / 2;


                  


                        Label labelProdName = new Label { Text = reader.GetString("ProdName"), Font = new Font("Century Gothic", 10, FontStyle.Bold), Location = new Point(100,32), TextAlign = ContentAlignment.MiddleCenter };
                        labelProdName.Name = "labelProdName";
                        bunifuCard.Controls.Add(labelProdName);

                        labelProdName.Left=(labelProdName.Parent.Width-labelProdName.Width)/2;
                        labelProdName.Top=labelProdName.Parent.Height-labelProdName.Height- 35;


                        Label labelPrice = new Label
                        {
                            Text = reader.GetDouble("Price").ToString(),
                            Font = new Font("Century Gothic", 9, FontStyle.Bold),
                            Location = new Point(120, 20),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Name = "labelPrice"
                        };
                        bunifuCard.Controls.Add(labelPrice);
                        labelPrice.Left = (labelPrice.Parent.Width - labelPrice.Width) / 2;
                        labelPrice.Top = labelPrice.Parent.Height - labelPrice.Height - 17;



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



      


        private void btnsearch_Click(object sender, EventArgs e) => loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID AND ProdName LIKE @ProdName");

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

                        btnCategory.IdleBorderRadius = 10;

                        btnCategory.ForeColor = Color.White;
                        btnCategory.Text = categoryName;
                        btnCategory.Click += (sender, e) => BtnCategory_Click(sender, e, categoryId);

                        

                        Variables.setColorsBunifu(Variables.clrmainbtn, btnCategory);

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

            Control lal = (Control)sender;
            Control button = lal.Parent ;
            Label lbl2 = button.Controls.OfType<Label>().FirstOrDefault(b => b.Name == "labelProdName");
            Label lbl = button.Controls.OfType<Label>().FirstOrDefault(b => b.Name == "labelPrice");



            bool alreadyExists = false;
            if (flowLayoutPanel2.Controls.Count == 0)
            {
                alreadyExists = false;
            }
            else
            {
             foreach (Control control in flowLayoutPanel2.Controls)
                        {
                            foreach (Label l in control.Controls)
                            {
                                if (l.Text == lbl2.Text)
                                {
                                    BunifuButton buttonPlus = l.Parent.Controls.OfType<BunifuButton>().FirstOrDefault(b => b.Name == "buttonPlus");
                                    buttonPlus.PerformClick();
                            alreadyExists = true;
                                    break;
                                }
                        break;
                            }
               

                }


            }
           

            if (!alreadyExists)
            {
                addtopanel10(lbl2.Text.ToString(), lbl.Text.ToString());
                updateTotal();
            }
            alreadyExists = false;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void bttnsetting_Click(object sender, EventArgs e)
        {
            new frmsettings().Show();
        }

        private void resetColors() 
        {
            Variables.setColors(Variables.clrheader, panel1);
            Variables.setColorsBunifu(Variables.clrmainbtn, btnviewallproducts, btnsearch, btnaddproduct, btnreceipt);
            LoadCategories();
            btnviewallproducts.OnPressedState.FillColor = Color.Black;
            if (!(flowLayoutPanel2.Controls.OfType<Panel>().FirstOrDefault() == null))
            {
                foreach (Control panpan in flowLayoutPanel2.Controls)
                {
                    Label labelName = panpan.Controls.OfType<Label>().FirstOrDefault();
                    foreach (var button in panpan.Controls.OfType<BunifuButton>())
                    {
                        Variables.setColorsBunifuSecond(Variables.clrsecondarybtn, button);
                    }


                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnreceipt_Click(object sender, EventArgs e)
        {
            int count = 0;

            Variables.prodname.Clear();
            Variables.prodquant.Clear();
            Variables.prodprice.Clear();
            Variables.prodqp.Clear();

            foreach (var panpan in flowLayoutPanel2.Controls.OfType<Panel>())
            {

                Label labelName = panpan.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelName");
                Label labelQuantity = panpan.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");
                Label labelPrice = panpan.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPrice");
                Label labelPriceActual = panpan.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPriceActual");

                Variables.prodname.Add(labelName.Text);
                Variables.prodquant.Add(Convert.ToDouble(labelQuantity.Text));
                Variables.prodprice.Add(Convert.ToDouble(labelPrice.Text));
                Variables.prodqp.Add(Convert.ToDouble(labelPriceActual.Text));

                Variables.total = total;

                count++;
            }
            new frmReceipt().ShowDialog();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Variables.MAINNAME="";
            Variables.MAINCOMPANYID=0;
            Variables.MAINCOMPANYNAME="";
            Variables.MAINID=0;
            Variables.MAINTYPE="";
            Variables.MAINCOMPANYADDR="";
            Variables.MAINCOMPANYBID=0;


            Variables.ACCACCESS=false;
            Variables.ACCTYPE=0;
            this.Hide();
            new frmLogin().Show();
        }


        private void addtopanel10(string n, string p)
        {

            Panel panpan = new Panel {
                Width = 315,
                Height = 50,
                BackColor = Variables.clrheader,
                 Location = new Point(0,0 ),
                Anchor = AnchorStyles.Top| AnchorStyles.Left | AnchorStyles.Right

            };
            flowLayoutPanel2.Controls.Add(panpan);


            Label labelName = new Label { Text = n, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 10), ForeColor = Color.White, Location = new Point(11, 7), Size = new Size(155, 37) };
            labelName.Name = "labelName";
            panpan.Controls.Add(labelName);




            Label labelQuantity = new Label {
                Text = "1",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 12),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(203,7), 
                Size = new Size(17, 37),
                Anchor = AnchorStyles.Right
            };
            labelQuantity.Name = "labelQuantity";
            labelQuantity.TextChanged += LabelQuantity_TextChanged;
            panpan.Controls.Add(labelQuantity);

            BunifuButton buttonMinus = new BunifuButton
            {
                Text = "-",
                Size = new Size(20, 20),
                IdleBorderRadius = 20,
                IdleBorderColor = Color.Transparent,
                BackColor = Color.Transparent,
                IdleFillColor = Variables.clrsecondarybtn,
                ForeColor = Color.White,
                Location = new Point(173, 13),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.Right
            };
            buttonMinus.Name = "buttonMinus";

            panpan.Controls.Add(buttonMinus);
            buttonMinus.Click += button1_Click;


            BunifuButton buttonPlus = new BunifuButton { 
                Text = "+", Size = new Size(20, 20), 
                IdleBorderRadius = 20, 
                BackColor = Color.Transparent, 
                IdleBorderColor = Color.Transparent, 
                IdleFillColor = Variables.clrsecondarybtn, 
                ForeColor = Color.White, Cursor = Cursors.Hand, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Location = new Point(222, 18),
                Anchor = AnchorStyles.Right
            
            };
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Click += button2_Click;
            panpan.Controls.Add(buttonPlus);



            Label labelPrice = new Label { Text = p, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 10), ForeColor = Color.White, Anchor=AnchorStyles.Right,
                Location = new Point(266, 7),
                Size = new Size(45, 37), Visible = false,};
            labelPrice.Name = "labelPrice";
            panpan.Controls.Add(labelPrice);

            //label na mag-didisplay nung price as P00.00 na format and the only one visible
            Label labelPriceNew = new Label { Text = "P"+p, 
                TextAlign = ContentAlignment.MiddleCenter, 
                Font = new Font("Century Gothic", 10), 
                ForeColor = Color.White, 
                Location = new Point(266, 7), 
                Size = new Size(45, 37),
                Anchor = AnchorStyles.Right
            };
            labelPriceNew.Name = "labelPriceNew";
            panpan.Controls.Add(labelPriceNew);

            //label na mag-stostore nung actual double na price
            Label labelPriceActual = new Label { Text = p, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 10), ForeColor = Color.White, Location = new Point(0, 7), Size = new Size(45, 37), Visible=false };
            labelPriceActual.Name = "labelPriceActual";
            panpan.Controls.Add(labelPriceActual);

            Variables.setColorsBunifuSecond(Variables.clrsecondarybtn, buttonPlus, buttonMinus);

        }




        private void button2_Click(object sender, EventArgs e)
        {

            Control button = (Control)sender;
            Control parent = button.Parent;
            Label lbl = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");
            lbl.Text = (Convert.ToInt64(lbl.Text) + 1).ToString();


        }




        private void button1_Click(object sender, EventArgs e)
        {
            {
                Control button = (Control)sender;
                Control parent = button.Parent;
                Label lbl = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");

                lbl.Text = (Convert.ToInt64(lbl.Text) - 1).ToString();
                if (Convert.ToInt64(lbl.Text) == 0)
                {
                    parent.Parent.Controls.Remove(parent);
                }

            }

        }

        private void LabelQuantity_TextChanged(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            Control parent = button.Parent;//panpan
            Label labelQuantity = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelQuantity");
            Label labelPrice = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPrice");
            Label labelPriceNew = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPriceNew");
            Label labelPriceActual = parent.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPriceActual");

            double q = Convert.ToDouble(labelQuantity.Text);
            double p = Convert.ToDouble(labelPrice.Text);

            double totalPrice = q * p;
            labelPriceActual.Text = totalPrice.ToString();
            labelPriceNew.Text = "P" + labelPriceActual.Text;
            updateTotal();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void updateTotal() {
            total = 0;
            foreach (Control panpan in flowLayoutPanel2.Controls.OfType<Panel>())
            {
                Label labelPriceActual = panpan.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "labelPriceActual");

                total += Convert.ToDouble(labelPriceActual.Text);
            }

            label9.Text = "Total: P" + total;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Resize(object sender, EventArgs e)
        {
            int paddingleft = 0;

            if (!(flowLayoutPanel2.Controls.OfType<Panel>().FirstOrDefault()==null))
            {
                Control panpan = flowLayoutPanel2.Controls.OfType<Panel>().FirstOrDefault();

                paddingleft = (flowLayoutPanel2.Width - panpan.Width) / 2;
            }


            flowLayoutPanel2.Padding = new Padding(paddingleft, 0,0,0);
        }
    }
}
