using MySql.Data.MySqlClient;
using System;


namespace Cashetor
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
            catch (Exception)
            {
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
