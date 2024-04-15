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

                    int y = 0;
                    foreach (var kvp in columnTotals)
                    {
                        Label labelColumnName = new Label();
                        labelColumnName.Text = kvp.Key + ":";
                        labelColumnName.Location = new Point(10, y);
                        panel.Controls.Add(labelColumnName);

                        Label labelTotalQuantity = new Label();
                        labelTotalQuantity.Text = kvp.Value.ToString();
                        labelTotalQuantity.Location = new Point(120, y);
                        panel.Controls.Add(labelTotalQuantity);

                        y += 30;
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
