using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmhistory : Form
    {
        string tableName = $"tblhistory_{Extensions.cleanString(Variables.MAINCOMPANYNAME)}";
        public frmhistory()
        {
            InitializeComponent();
            Variables.setColorsBunifu(Variables.clrmainbtn, bunifuButton1, bunifuButton2, bunifuButton3);
            tbl.HeaderBackColor = Variables.clrheader;
            tbl.GridColor = Shit.LightenHexColor(Variables.clrheader, 0.7f);
        }

        private void sendQuery(string qq)
        {
            try
            {
                DB.Connect();
                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(qq, connection))
                    {

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable tb = new DataTable();
                            adapter.Fill(tb);

                            tbl.DataSource = tb;
                            tbl.AutoGenerateColumns = true;
                        }
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
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string q = $"SELECT * FROM {tableName} ORDER BY Date";
            sendQuery(q);
            tbl.Visible = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string q = "SELECT * FROM " + tableName + " ORDER BY Name";
            sendQuery(q);
            tbl.Visible = true;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM {tableName};";
            try
            {
                DB.Connect();
                using (MySqlConnection connection =DB.con)
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    Dictionary<string, int> columnTotals = new Dictionary<string, int>();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (column.ColumnName != "ID" && column.ColumnName != "Name" && column.ColumnName != "Date" && column.ColumnName != "AccID")
                        {
                            int total = 0;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row[column] != DBNull.Value)
                                {
                                    total += Convert.ToInt32(row[column]);
                                }
                            }
                            columnTotals.Add(column.ColumnName, total);
                        }
                    }

                    Panel panel = new Panel();
                    panel.Dock = DockStyle.Fill;
                    panel.AutoScroll = true;


                        Label productlbl = new Label();
                        productlbl.BackColor = Variables.clrheader;
                        productlbl.Text = "Product";
                        productlbl.Location = new Point(10, 0);
                        //productlbl.Padding = new Padding(2, 2, 2, 2);
                        productlbl.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        productlbl.ForeColor = Color.White;
                        panel.Controls.Add(productlbl);

                        Label quantlbl = new Label();
                        quantlbl.BackColor = Variables.clrheader;
                        quantlbl.Text = "Quantity Purchased";
                        quantlbl.AutoSize = true;
                        quantlbl.Location = new Point(productlbl.Width+10, 0);
                        quantlbl.Padding = new Padding(2, 2, 2, 2);
                        quantlbl.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        quantlbl.ForeColor = Color.White;
                        panel.Controls.Add(quantlbl);



                        int y = productlbl.Height;
                        int count = 0;
                        int maxwidth = 0;
                    foreach (var kvp in columnTotals)
                    {
                        Label labelColumnName = new Label();
                            labelColumnName.Name = "labelColumnName";
                        labelColumnName.Text = kvp.Key + ":";
                        labelColumnName.Location = new Point(10, y);
                            labelColumnName.Padding = new Padding(2,2,2,2);
                            labelColumnName.Font = new Font("Century Gothic", 10);
                            labelColumnName.AutoSize = true;
                        panel.Controls.Add(labelColumnName);

                        Label labelTotalQuantity = new Label();
                            labelColumnName.Name = "labelTotalQuantity";
                            labelTotalQuantity.Text = kvp.Value.ToString();
                        labelTotalQuantity.Location = new Point(labelColumnName.Width+10, y);
                            labelTotalQuantity.Width=quantlbl.Width;
                            labelTotalQuantity.Padding = new Padding(2, 2, 2, 2);
                            labelTotalQuantity.Font = new Font("Century Gothic", 10);
                            panel.Controls.Add(labelTotalQuantity);

                            //to alternate between colors
                            if (count % 2 == 0)
                            {
                                labelColumnName.BackColor = Variables.clrmainbtn;
                                labelTotalQuantity.BackColor = Variables.clrmainbtn;
                            }
                            else {
                                labelColumnName.BackColor = Color.White;
                                labelTotalQuantity.BackColor = Color.White;
                            }

                            //,,very inefficient code fot getting longest width for reference mamaya
                            if (count == 0)
                            {
                                if (productlbl.Width >= labelColumnName.Width)
                                {
                                    maxwidth = productlbl.Width;
                                }
                                else
                                {
                                    maxwidth = labelColumnName.Width;
                                }
                            }
                            else {
                                if (maxwidth>=labelColumnName.Width) { 
                                } else 
                                { 
                                    maxwidth = labelColumnName.Width; 
                                }
                            }

                            count++;
                            y += labelTotalQuantity.Height;
                        }

                        //para ma-set yung width labelcolumnname to the longest width (basically para ma-autosize lahat ng width ng labelcolumnnames)
                        foreach (Label lbl in panel.Controls) {
                            if (lbl.Left == 10)
                            {
                                lbl.AutoSize=false;
                                lbl.Width = maxwidth;
                            }
                            else {
                                lbl.Left = maxwidth + 10;
                            }
                        }

                    splitContainer1.Panel2.Controls.Add(panel);
                    tbl.Visible = false;
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

        }
    }
}
