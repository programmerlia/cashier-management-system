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
using System.Drawing.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Cashetor
{
    public partial class frmMain : Form
    {
        double total = 0;
        public frmMain()
        {
            InitializeComponent();
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
            loadColors();
            flowLayoutPanel2.Controls.Clear();
            LoadCategories();
            if (Variables.MAINTYPE == "Admin")
            {
                bttnsetting.Visible = true;
                pclogo.Click += pclogo_Click;
            } else if (Variables.MAINTYPE == "User")
            {
                bttnsetting.Visible = false;
                pclogo.Click += pclogo_Click;
            }



        }


        private void loadColors()
        {
            DB.Connect();
            try
            {


                MySqlCommand msn = new MySqlCommand("SELECT * FROM tbltheme WHERE CompID = @ID", DB.con);
                msn.Parameters.AddWithValue("@ID", Variables.MAINCOMPANYID);

                MySqlDataReader reader = msn.ExecuteReader();
                while (reader.Read())
                {
                    Variables.clrheader = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colorheader"));
                    Variables.clrmainbtn = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colormainbutton"));
                    Variables.clrsecondarybtn = System.Drawing.ColorTranslator.FromHtml(reader.GetString("colorsecondarybutton"));

                    Variables.setColors(Variables.clrheader, panel1);
                    Variables.setColorsBunifu(Variables.clrmainbtn, btnviewallproducts, btnsearch, btnlogout);
                    Variables.setColorsBunifu(Variables.clrmainbtn, btnreceipt, btnaddproduct);

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
            resetColors();
            loadProducts("SELECT * FROM tblproduct WHERE ProdComp=@CompID");
        }

        private void loadProducts(string cmd)
        {
            try
            {
                DB.Connect();

                MySqlCommand msn = new MySqlCommand(cmd, DB.con);
                msn.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);
                msn.Parameters.AddWithValue("@ProdName", "%" + textBox1.Text + "%");

                MySqlDataReader reader = msn.ExecuteReader();
                if (!reader.HasRows)
                {
                    Label labelno = new Label { Text = "NO PRODUCTS FOUND", Font = new Font("Century Gothic", 20, FontStyle.Bold), Location = new Point(0, 0), TextAlign = ContentAlignment.MiddleCenter };
                    labelno.Size = flowLayoutPanel1.Size;
                    flowLayoutPanel1.Controls.Add(labelno);
                    btnreceipt.Visible = false;
                }

                if (reader.HasRows)
                {
                    btnreceipt.Visible = true;
                    flowLayoutPanel1.Controls.Clear();
                    while (reader.Read())
                    {
                        BunifuCards bunifuCard = new BunifuCards { Size = new Size(150, 150), BorderRadius = 20, color = Variables.clrheader };
                        flowLayoutPanel1.Controls.Add(bunifuCard);

                        PictureBox pictureBox = new PictureBox { SizeMode = PictureBoxSizeMode.StretchImage, Size = new Size(80, 80), Location = new Point(30, 10), };
                        pictureBox.Click += buttonOrder_Click;
                        pictureBox.Cursor = Cursors.Hand;
                        byte[] imageData = (byte[])reader["ProdImg"];
                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBox.Image = Image.FromStream(ms);
                        }
                        bunifuCard.Controls.Add(pictureBox);
                        pictureBox.Left = (pictureBox.Parent.Width - pictureBox.Width) / 2;


                        ContextMenu cm = new ContextMenu();
                        cm.MenuItems.Add("Delete", new EventHandler(item1_Click));
                        pictureBox.ContextMenu = cm;


                        Label labelProdName = new Label
                        {
                            Text = reader.GetString("ProdName"),
                            Font = new Font("Century Gothic", 9, FontStyle.Bold),
                            Location = new Point(0, 90),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Padding = new Padding(2, 0, 2, 0),
                            Name = "labelProdName",
                            Width = bunifuCard.Width,

                        };
                        Size size = TextRenderer.MeasureText(labelProdName.Text, labelProdName.Font, new Size(labelProdName.Width, int.MaxValue), TextFormatFlags.WordBreak);
                        labelProdName.Height = size.Height;
                        bunifuCard.Controls.Add(labelProdName);



                        Label labelPrice = new Label
                        {
                            Text = reader.GetDouble("Price").ToString(),
                            Font = new Font("Century Gothic", 8),
                            Location = new Point(labelProdName.Location.X, labelProdName.Location.Y + labelProdName.Height + 5),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Name = "labelPrice",
                            Padding = new Padding(2, 0, 2, 0),
                            Width = bunifuCard.Width
                        };
                        Size size2 = TextRenderer.MeasureText(labelPrice.Text, labelPrice.Font, new Size(labelPrice.Width, int.MaxValue), TextFormatFlags.WordBreak);

                        labelPrice.Height = size2.Height;
                        bunifuCard.Controls.Add(labelPrice);



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


        private void Item2_Click(object sender, EventArgs e)
        {
            MenuItem lal = (MenuItem)sender;
            ContextMenu cm = lal.GetContextMenu();
            Control p = cm.SourceControl as Control;
            Control fl = p.Parent;
            fl.Controls.Remove(p);
            updateTotal();
        }

                private void item1_Click(object sender, EventArgs e)
        {
            MenuItem lal = (MenuItem)sender;
            ContextMenu cm = lal.GetContextMenu();
            Control pb = cm.SourceControl as Control;
            Control button = pb.Parent;
            button.Parent.Controls.Remove(button);  

            Console.WriteLine(button.ToString());
            Label lbl2 = button.Controls.OfType<Label>().FirstOrDefault(b => b.Name == "labelProdName");
            Console.WriteLine(lbl2.Text);

            foreach (Control control in flowLayoutPanel2.Controls)
            {
                foreach (Label l in control.Controls)
                {
                    if (l.Text == lbl2.Text)
                    {
                        l.Parent.Parent.Controls.Remove(control);
                        updateTotal();
                        break;
                    }
                    break;
                }


            }

            try
            {

                DB.Connect();

                string query = "DELETE FROM tblproduct WHERE ProdComp =@CompID AND ProdName =@1;";
                
                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);
                        command.Parameters.AddWithValue("@1", lbl2.Text);
                        command.ExecuteNonQuery();
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

                DB.Connect();

                string query = "SELECT CategoryName, ID FROM tblcategory WHERE CompID = @CompID";
                MySqlCommand command = new MySqlCommand(query, DB.con);
                command.Parameters.AddWithValue("@CompID", Variables.MAINCOMPANYID);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Label labelno = new Label { Text = "No CATEGORIES FOUND", Font = new Font("Century Gothic", 12, FontStyle.Bold), Location = new Point(0, 0), TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
                        pnlcategory.Controls.Add(labelno);
                        btnviewallproducts.Visible = false;
                    }
                    if (reader.HasRows)
                    {
                        pnlcategory.Controls.Clear();
                        btnviewallproducts.Visible = true;
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
                    reader.Close();
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
            Control button = lal.Parent;
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
            createReceiptPanel();
            
            
        }

        private void createReceiptPanel()
        {

            int count = 0;
            int idofinserted=0;
            string tableName = $"tblhistory_{Extensions.cleanString(Variables.MAINCOMPANYNAME)}";
            Variables.prodname.Clear();
            Variables.prodquant.Clear();
            Variables.prodprice.Clear();
            Variables.prodqp.Clear();

            try
            {
                DB.Connect();

                
                string query = $"INSERT INTO {tableName} (Name, AccID) VALUES (@1, @2);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@1", Variables.MAINNAME);
                        command.Parameters.AddWithValue("@2", Variables.MAINID);
                        command.ExecuteNonQuery();
                        idofinserted = Convert.ToInt32(command.LastInsertedId);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                DB.Disconnect();
            }

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

                string tblcol = Extensions.cleanString(labelName.Text.ToString());
                int tblval = Int32.Parse(labelQuantity.Text.ToString());

                try
                {
                    DB.Connect();

                    string query = $"UPDATE {tableName} SET {tblcol} = @2 WHERE ID = @3;";

                    using (MySqlConnection connection = DB.con)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@2", tblval);
                            command.Parameters.AddWithValue("@3", idofinserted);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    DB.Disconnect();
                }

                count++;
            }
            var receiptForm = new frmReceipt();
            receiptForm.FormClosed += (sender, e) => {
                flowLayoutPanel2.Controls.Clear();
            };
            receiptForm.ShowDialog();

        }

   

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Variables.MAINNAME=null;
            Variables.MAINCOMPANYID=0;
            Variables.MAINCOMPANYNAME="";
            Variables.MAINID=0;
            Variables.MAINTYPE="";
            Variables.MAINCOMPANYADDR="";
            Variables.MAINCOMPANYBID=0;

            Program.LoggedIN = false;
            Properties.Settings.Default.loggedin = false;
            Properties.Settings.Default.maincompanyid = Variables.MAINCOMPANYID;
            Properties.Settings.Default.mainname = Variables.MAINNAME;
            Properties.Settings.Default.mainid = Variables.MAINID;
            Properties.Settings.Default.maintype = Variables.MAINTYPE;
            Properties.Settings.Default.maincompanyname = Variables.MAINCOMPANYNAME;
            Properties.Settings.Default.maincompanyaddr = Variables.MAINCOMPANYADDR;
            Properties.Settings.Default.maincompanybid = Variables.MAINCOMPANYBID;
            Properties.Settings.Default.Save();
            Variables.ACCACCESS=false;
            Variables.ACCTYPE=0;
            this.Hide();
            new frmLogin().Show();
        }


        private void addtopanel10(string n, string p)
        {

            Panel panpan = new Panel {
                AutoSize = true,
                MaximumSize = new Size(315, 0),
                MinimumSize = new Size(315, 0),
                BackColor = Variables.clrheader,
                 Location = new Point(0,0 ),
                 Padding = new Padding(0,5,0,5),
                Anchor = AnchorStyles.Top| AnchorStyles.Left | AnchorStyles.Right

            };
            flowLayoutPanel2.Controls.Add(panpan);


            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Delete", new EventHandler(Item2_Click));
            panpan.ContextMenu = cm;


            Label labelName = new Label { 
                Text = n, 
                TextAlign = ContentAlignment.MiddleLeft, 
                Font = new Font("Century Gothic", 10), 
                ForeColor = Color.White, 
                Location = new Point(11, 0), 
                AutoSize = true,
                MaximumSize = new Size(155, 0)
            };
            labelName.Name = "labelName";
            panpan.Controls.Add(labelName);




            Label labelQuantity = new Label {
                Text = "1",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 12),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(203,0), 
                Size = new Size(17, panpan.Height),
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
                Location = new Point(173, (panpan.Height - 20) / 2),
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
                Location = new Point(222, (panpan.Height - 20) / 2),
                Anchor = AnchorStyles.Right
            
            };
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Click += button2_Click;
            panpan.Controls.Add(buttonPlus);

            labelName.Location = new Point(10, ((panpan.Height - labelName.Height) / 2)+3);


            Label labelPrice = new Label { Text = p, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Century Gothic", 10), ForeColor = Color.White, Anchor=AnchorStyles.Right,
                Location = new Point(266, 7),
                Size = new Size(45, 37), Visible = false,};
            labelPrice.Name = "labelPrice";
            panpan.Controls.Add(labelPrice);

            //label na mag-didisplay nung price as P00.00 na format and the only one visible
            Label labelPriceNew = new Label { Text = "P"+p, 
                TextAlign = ContentAlignment.MiddleRight, 
                Font = new Font("Century Gothic", 10), 
                ForeColor = Color.White, 
                Location = new Point(buttonPlus.Width+buttonPlus.Left +10, 0),
                Size = new Size(55, panpan.Height),
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

        private void pclogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pclogo.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                MemoryStream ms = new MemoryStream();
                pclogo.Image.Save(ms, pclogo.Image.RawFormat);
                try
                {
                    DB.Connect();

                    string query = "UPDATE tblcompany SET CompImg=@1 WHERE CompID=@2;";

                    using (MySqlConnection connection = DB.con)
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@2", Variables.MAINCOMPANYID);
                            command.Parameters.AddWithValue("@1", Shit.ImageToBlob(pclogo.Image)); 
                            command.ExecuteNonQuery();
                        }
                    }
                    AMB.GetInstance().Show("LOGO CHANGED SUCCESFULY", 1500);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); //pag may error para makita ko ano error
                }
                finally
                {
                    DB.Disconnect();
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new frmhistory().ShowDialog();
        }

        private void label4_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Variables.clrsecondarybtn;
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Black;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
