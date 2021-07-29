using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Final_OOP_Project
{
    public partial class Form7 : Form
    {
        SpeechSynthesizer speek = new SpeechSynthesizer();

        public Form7()
        {
            InitializeComponent();
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult asktoExitGame;

            asktoExitGame=MessageBox.Show("Are you sure you want to exit game ","Game",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (asktoExitGame.Equals(DialogResult.Yes))
            {
                Form7 form7 = new Form7();
                form7.Hide();
                Form3 f3 = new Form3();
                f3.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            speek.Speak("A is for … Apple ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            speek.Speak("B is for … Ball");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            speek.Speak("C is for … Cat ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            speek.Speak("D is for … Dog");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            speek.Speak("E is for … Elephant");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            speek.Speak("F is for … Fish");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            speek.Speak("G is for … Ghost ");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            speek.Speak("H is for … Horse");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            speek.Speak("I is for … Ice-cream");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            speek.Speak("J is for… Jack o’lantern");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            speek.Speak("K is for … Kangaroo ");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            speek.Speak("L is for … Lamb");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            speek.Speak(" M is for … Moon ");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            speek.Speak("N is for … Nine");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            speek.Speak("O is for … Octopus ");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            speek.Speak("P is for … Pig");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            speek.Speak("Q is for … Queen ");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            speek.Speak("R is for … Ruler");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            speek.Speak("S is for… Schoolbag");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            speek.Speak("T is for … Train");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            speek.Speak("U is for … Umbrella");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            speek.Speak("V is for … Violet");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            speek.Speak("W is for … Witch ");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            speek.Speak("X is for … Xylophone");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            speek.Speak("Y is for … Yo-yo ");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            speek.Speak("Z is for … Zebra");
        }
    }
}
