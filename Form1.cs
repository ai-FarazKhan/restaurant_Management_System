using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;
using System.Speech.Synthesis;

namespace Final_OOP_Project
{
    public partial class Form1 : Form
    {
        string userName = "ADMIN"; string password = "ABC123";

        Form5 form5 = new Form5();
        Form4 form4 = new Form4();
        Form6 form6 = new Form6();


        public Form1()
        {
            form5.ShowDialog();
            form5.Hide();

            form4.ShowDialog();
            form4.Hide();

            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userName.Equals(textBox1.Text) && password.Equals(textBox2.Text))
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();

                this.Hide();
            }
            else
            {
                SpeechSynthesizer s1 = new SpeechSynthesizer();

                s1.Speak("Your password is wrong please enter correct password to log in Thanks ");

                


                MessageBox.Show("PLEASE ENTER CORRECT USER NAME OR PASSWORD !!!", "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult askToExit;

            askToExit = MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT ", "LOGIN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (askToExit.Equals(DialogResult.Yes))
            {
                form6.ShowDialog();

                Application.Exit();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                button1.Focus();
            }
        }

        public void ResetPassword() 
        {
            //DialogResult askToChange;

            //askToChange = MessageBox.Show("ARE YOU SURE YOU FORGOT YOUR PASSWORD ", "LOGIN ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (askToChange.Equals(DialogResult.Yes))
            //{
            //    Form7 form7 = new Form7();

            //    form7.ShowDialog();

            //    Form1 form1 = new Form1();

            //    form1.Hide();
            //}
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
