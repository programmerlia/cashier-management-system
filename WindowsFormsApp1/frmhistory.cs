using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashetor
{
    public partial class frmhistory : Form
    {
        string tableName = $"tblhistory_{Extensions.cleanString(Variables.MAINCOMPANYNAME)}";
        public frmhistory()
        {
            InitializeComponent();
            Variables.setColorsBunifu(Variables.clrmainbtn, bunifuButton1, bunifuButton2, bunifuButton3, bunifuButton4);
            Shit.setupTableClr(tbl);

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
                using (MySqlConnection connection = DB.con)
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
                        productlbl.Padding = new Padding(2, 2, 2, 2);
                        productlbl.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        productlbl.ForeColor = Color.White;
                        panel.Controls.Add(productlbl);
                        productlbl.Width = 200;

                        Label quantlbl = new Label();
                        quantlbl.BackColor = Variables.clrheader;
                        quantlbl.Text = "Quantity Purchased";
                        quantlbl.AutoSize = true;
                        quantlbl.Location = new Point(productlbl.Width + 10, 0);
                        quantlbl.Padding = new Padding(2, 2, 2, 2);
                        quantlbl.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                        quantlbl.ForeColor = Color.White;
                        panel.Controls.Add(quantlbl);
                        quantlbl.Width = 390;



                        int y = productlbl.Height;
                        int count = 0;
                        foreach (var kvp in columnTotals)
                        {
                            Label labelColumnName = new Label();
                            labelColumnName.Name = "labelColumnName";
                            labelColumnName.Text = kvp.Key + ":";
                            labelColumnName.Location = new Point(10, y);
                            labelColumnName.Padding = new Padding(2, 2, 2, 2);
                            labelColumnName.Font = new Font("Century Gothic", 10);
                            panel.Controls.Add(labelColumnName);
                            labelColumnName.AutoSize = true;
                            labelColumnName.MaximumSize = new Size(productlbl.Width, 0);
                            labelColumnName.MinimumSize = new Size(productlbl.Width, 0);
                            labelColumnName.Text = labelColumnName.Text.Replace("_", " ");


                            Label labelTotalQuantity = new Label();
                            labelColumnName.Name = "labelTotalQuantity";
                            labelTotalQuantity.Text = kvp.Value.ToString();
                            labelTotalQuantity.Location = new Point(labelColumnName.Width + 10, y);
                            labelTotalQuantity.Width = quantlbl.Width;
                            labelTotalQuantity.Padding = new Padding(2, 2, 2, 2);
                            labelTotalQuantity.Font = new Font("Century Gothic", 10);
                            labelTotalQuantity.Height = labelColumnName.Height;
                            labelTotalQuantity.TextAlign = ContentAlignment.MiddleCenter;
                            panel.Controls.Add(labelTotalQuantity);

                            //to alternate between colors
                            if (count % 2 == 0)
                            {
                                labelColumnName.BackColor = Shit.LightenHexColor(Variables.clrmainbtn, .5f);
                                labelTotalQuantity.BackColor = Shit.LightenHexColor(Variables.clrmainbtn, .5f);
                            }
                            else
                            {
                                labelColumnName.BackColor = Shit.LightenHexColor(Variables.clrmainbtn, .9f);
                                labelTotalQuantity.BackColor = Shit.LightenHexColor(Variables.clrmainbtn, .9f);
                            }

                            count++;
                            y += labelColumnName.Height;
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

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            tbl.Visible = true;
            GetMonthData();


        }

        private void GetMonthData()
        {
                try
                {
                    DB.Connect();

                    List<string> columnNames = new List<string>();
                    using (MySqlCommand command = new MySqlCommand($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}';", DB.con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                columnNames.Add(reader.GetString(0));
                            }
                        reader.Close();
                        }
                    }

                    List<string> quantityColumnNames = columnNames.Skip(4).ToList();

                    string sumQuery = string.Join(" + ", quantityColumnNames.Select(col => $"COALESCE({col}, 0)"));
                string query = $@"
                SELECT 
                        DATE_FORMAT(Date, '%M') AS Month,
                        SUM({sumQuery}) AS ProductSold 
                    FROM {tableName} 
                    GROUP BY MONTH(Date);
                ";

                // Execute the query and populate the DataGridView
                using (MySqlCommand command = new MySqlCommand(query, DB.con))
                    {
                        DataTable dataTable = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        tbl.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DB.Disconnect();
                }
            }




    }
}
