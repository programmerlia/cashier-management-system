using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
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

                new frmLogin().Show();

                this.Hide();
            }
        }
    }
}
