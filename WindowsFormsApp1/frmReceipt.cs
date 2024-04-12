using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmReceipt : Form
    {
        public frmReceipt()
        {
            InitializeComponent();
            label1.Text = Variables.MAINCOMPANYNAME;
            label2.Text = Variables.MAINCOMPANYBID.ToString();
            label3.Text = Variables.MAINCOMPANYADDR;

            label1.Left= (splitContainer1.Width - label1.Width) / 2;
            label2.Left= (splitContainer1.Width - label1.Width) / 2;
            label3.Left= (splitContainer1.Width - label1.Width) / 2;
            label4.Left= (splitContainer1.Width - label1.Width) / 2;

            splitContainer1.Left = (this.ClientSize.Width - splitContainer1.Width) / 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void centerReceipt(object sender, EventArgs e) 
        {
            splitContainer1.Left = (this.ClientSize.Width - splitContainer1.Width) / 2;
        }
    }
}
