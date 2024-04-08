using MySql.Data.MySqlClient;
using System;


namespace WindowsFormsApp1
{
    public static class DB
    {


        public static MySqlConnection con;

        public static void Connect()
        {


            try
            {
                con = new MySqlConnection("server=127.0.0.1; user=root; database=cms; password=");
                con.Open();

            }
            catch (Exception ex)
            {
                AMB.GetInstance().Show(ex.Message, 1500);
            }

        }

        public static void Disconnect()
        {
            if (con != null)
            {

                con.Dispose();
                con.Close();
            }
        }
    }
}
