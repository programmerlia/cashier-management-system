using System;
using System.Windows.Forms;

namespace Cashetor
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 30;
            if (panel2.Width >= 700)
            {

                timer1.Stop();

                Variables.MAINNAME = Properties.Settings.Default.mainname;
                Variables.MAINCOMPANYID = Properties.Settings.Default.maincompanyid;
                Variables.MAINCOMPANYNAME = Properties.Settings.Default.maincompanyname;
                Variables.MAINID = Properties.Settings.Default.mainid;
                Variables.MAINTYPE = Properties.Settings.Default.maintype;
                Variables.MAINCOMPANYADDR = Properties.Settings.Default.maincompanyaddr;
                Variables.MAINCOMPANYBID = Properties.Settings.Default.maincompanybid;
                Program.LoggedIN = Properties.Settings.Default.loggedin;
                Properties.Settings.Default.Save();
                if (Program.LoggedIN == true)
                {
                    new frmMain().Show();
                }
                else
                {
                    new frmLogin().Show();
                }

                this.Hide();
            }
        }
    }
}
