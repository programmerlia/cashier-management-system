using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public static class Extensions
    {
        public static string cleanString(this string str)
        {
            return Regex.Replace(str, @"[\s\p{P}]", "_");

        }
    }
    public static class sql
    {

        public static void addHistTbl(string na)
        {
            string name = Extensions.cleanString(na);



            string tableName = $"tblhistory_{name}";
            try
            {
                DB.Connect();

                string query = $"CREATE TABLE {tableName} (ID INT AUTO_INCREMENT PRIMARY KEY, Name VARCHAR(255), AccID INT,  Date TIMESTAMP DEFAULT CURRENT_TIMESTAMP);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
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

        }


        public static void addHistTblProd(string pro)
        {
            string tbl = $"tblhistory_{Extensions.cleanString(Variables.MAINCOMPANYNAME)}";
            string prod =  Extensions.cleanString(pro);

            try
            {
                DB.Connect();

                string query = $"ALTER TABLE {tbl} ADD COLUMN {prod} int(11);";

                using (MySqlConnection connection = DB.con)
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
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
        }
    }

}