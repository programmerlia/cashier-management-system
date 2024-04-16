using System;
using System.Windows.Forms;

namespace Cashetor
{
    internal static class Program
    {
        public static bool LoggedIN;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
                  
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Program.LoggedIN)
            {
                Application.Run(new frmMain());
            }
            else {
                Application.Run(new frmSplashScreen());
            }
            
        }
    }
}
