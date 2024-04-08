using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AMB : Form
    {
        private static AMB instance;
        private readonly Timer _timer;

        private AMB()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
        }

        public static AMB GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AMB();
            }
            return instance;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public void Show(string message, int autoCloseTime)
        {
            bunifuLabel1.Text = message;
            _timer.Interval = autoCloseTime;
            _timer.Start();
            if (!Visible)
            {
                Show();
            }
        }
    }
}
