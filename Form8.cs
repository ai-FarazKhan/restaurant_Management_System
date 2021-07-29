using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Final_OOP_Project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Hide();

            Form3 f3 = new Form3();

            f3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://finance.google.com/finance/converter");
        }
    }
}
