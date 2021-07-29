using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WMPLib;
using System.Speech.Synthesis;

namespace Final_OOP_Project
{
    public partial class Form3 : Form
    {
        double item1 = 0, item2 = 0, item3 = 0, item4 = 0, item5 = 0, item6 = 0, total, discountRate, FinalResultDisscount;
        double totalEarning = 0;

        double setItem1 = 160, setItem2 = 180, setItem3 = 150, setItem4 = 200, setItem5 = 120, setItem6 = 120;

        double TotalZingerSold, TotalChickenBiryaniSold, TotalTikaBotiSold, TotalChickenBroastSold, TotalChickenQormaSold, TotalDrinkSold;

        double paidAmountOfUser;

        Form6 form6 = new Form6();

        

        //WindowsMediaPlayer media = new WindowsMediaPlayer();



        SpeechSynthesizer s = new SpeechSynthesizer();




        public Form3()
        {
            InitializeComponent();

            s.Speak("welcome to faraz khan tarka resturant ");

            //media.URL = "himanshu-katara_channa-mereya-mereya-instrumental-himanshu-katara-ae-dil-hai-mushkil.mp3";
        }





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult askToExit;
            s.Speak("are you sure you want to exit ");
            askToExit = MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT ", "SHOPPING CART", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (askToExit.Equals(DialogResult.Yes))
            {
                form6.ShowDialog();
                s.Speak("Thanks to choose our product " + "your comfort our passion ");
                Application.Exit();
            }

        }




        private void defaultPriceOfItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Speak("price of zinger burger is 160 rupees, price of tika boti is 180 rupees, price of chicken biryani is 150 rupees, price of chicken broast is 200 rupees, price of chicken qorma is 120 rupees, price of coca cola drink is 120 rupees Thanks ");

            MessageBox.Show("1 : ZINGER BURGER = 160 \n2 : TIKA BOTI = 180\n3 : CHICKEN BIRYANI = 150\n4 : CHICKEN BROAST = 200\n5 : CHICKEN QORMA =120\n6 : COCA-COLA DRINK = 120", "ITEMS PRICE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void aboutProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.ShowDialog();
        }





        private void Calculating_Price()
        {
            try
            {
                if (numericUpDown1.Value > 0 || numericUpDown2.Value > 0 || numericUpDown3.Value > 0 || numericUpDown4.Value > 0 || numericUpDown5.Value > 0 || numericUpDown6.Value > 0)
                {
                    item1 = setItem1 * Convert.ToDouble(numericUpDown1.Value);
                    item2 = setItem2 * Convert.ToDouble(numericUpDown2.Value);
                    item3 = setItem3 * Convert.ToDouble(numericUpDown3.Value);
                    item4 = setItem4 * Convert.ToDouble(numericUpDown4.Value);
                    item5 = setItem5 * Convert.ToDouble(numericUpDown5.Value);
                    item6 = setItem6 * Convert.ToDouble(numericUpDown6.Value);

                    total = item1 + item2 + item3 + item4 + item5 + item6;

                    AmountToPay.Text = total.ToString();
                    discountRate = double.Parse(InsertDisscount.Text);

                    if (discountRate > 0 || discountRate.Equals(0))
                    {
                        FinalResultDisscount = (total * (100 - discountRate) / 100);
                        //totalEarning += FinalResultDisscount;
                        TotalAmount.Text = FinalResultDisscount.ToString();

                    }
                    else
                    {
                        s.Speak("price of disscount can not be in negative thanks");
                        MessageBox.Show("DISSCOUNT CAN NOT BE IN NEGATIVE ", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    s.Speak("price of disscount can not be in negative thanks or PLEASE SELECT ITEMS BEFORE CALCULATING  thanks");
                    
                    MessageBox.Show("PLEASE SELECT ITEMS BEFORE CALCULATING !!! ", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                s.Speak("values of payments can not calculate in charsacters so please enter values in digits Thanks");
                MessageBox.Show("VALUES CAN NOT BE IN ALPHABATES \nENTER VALUES IN DIGITS ", "CALCULATIONS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void Calculating_Paid_Amount()
        {
            try
            {
                paidAmountOfUser = double.Parse(Paid_Amount_OF_User.Text);

                if (paidAmountOfUser > 0 && (Paid_Amount_OF_User.Text.Equals(TotalAmount.Text)))
                {
                    tokenNumber.Text = TokenNumber.getnextvalue() + "";

                    totalEarning += paidAmountOfUser;

                    todayEarning.Text = totalEarning + "";
                    TotalAmount.Text = FinalResultDisscount.ToString();

                    TotalZingerSold += Convert.ToDouble(numericUpDown1.Value);
                    TotalZingerSoldTextBox.Text = TotalZingerSold.ToString();

                    TotalTikaBotiSold += Convert.ToDouble(numericUpDown2.Value);
                    TotalTikaSoldTextBox.Text = TotalTikaBotiSold.ToString();

                    TotalChickenBiryaniSold += Convert.ToDouble(numericUpDown3.Value);
                    TotalChickenBiryaniSoldTextBox.Text = TotalChickenBiryaniSold.ToString();

                    TotalChickenBroastSold += Convert.ToDouble(numericUpDown4.Value);
                    TotalChickenBroastSoldTextBox.Text = TotalChickenBroastSold.ToString();

                    TotalChickenQormaSold += Convert.ToDouble(numericUpDown5.Value);
                    TotalChickenQormaSoldTextBox.Text = TotalChickenQormaSold.ToString();

                    TotalDrinkSold += Convert.ToDouble(numericUpDown6.Value);
                    TotalCoca_ColaDrinkSoldTextBox.Text = TotalDrinkSold.ToString();


                    StreamWriter sw = new StreamWriter(@"D:\TokenNumber.txt");
                    sw.WriteLine(tokenNumber.Text);
                    s.Speak("Congratulations your data succesfully saved Thanks");
                    MessageBox.Show("RECORD SAVED ", "TARKA RESTURANT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sw.Close();

                    StreamWriter sw1 = new StreamWriter(@"D:\TotalEarning.txt");
                    sw1.WriteLine(todayEarning.Text);
                    sw1.Close();

                    StreamWriter sw2 = new StreamWriter(@"D:\TotalZingerSold.txt");
                    sw2.WriteLine(TotalZingerSoldTextBox.Text);
                    sw2.Close();

                    StreamWriter sw3 = new StreamWriter(@"D:\TotalTikaSold.txt");
                    sw3.WriteLine(TotalTikaSoldTextBox.Text);
                    sw3.Close();

                    StreamWriter sw4 = new StreamWriter(@"D:\TotalChickenBiryaniSold.txt");
                    sw4.WriteLine(TotalChickenBiryaniSoldTextBox.Text);
                    sw4.Close();

                    StreamWriter sw5 = new StreamWriter(@"D:\TotalChickenBroastSold.txt");
                    sw5.WriteLine(TotalChickenBroastSoldTextBox.Text);
                    sw5.Close();

                    StreamWriter sw6 = new StreamWriter(@"D:\TotalQormaSold.txt");
                    sw6.WriteLine(TotalChickenQormaSoldTextBox.Text);
                    sw6.Close();

                    StreamWriter sw7 = new StreamWriter(@"D:\TotalDrinkSold.txt");
                    sw7.WriteLine(TotalCoca_ColaDrinkSoldTextBox.Text);
                    sw7.Close();

                }
                else
                {
                    s.Speak("please enter given amount of customer, other wise your token number and any calculation can not be calculate Thanks");
                    MessageBox.Show("TOKEN NUMBER AND TOTAL EARNING CANT BE CALCULATE \nENTER YOUR PAID AMOUNT FIRST \nPAID AMOUNT NOT EQUALS TO TOTAL AMOUNT \nSO TOKEN AND EARNING CAN NOT CALCULATE !!!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                s.Speak("please do not insert amount in characters insert amount in values or digits Thanks ");
                MessageBox.Show("AMOUNT CAN NOT BE IN ALPHABATES OR STRNG !!!", "TARKA RESTURANT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            string strFileName = @"D:\TokenNumber.txt";
            string fileText = File.ReadAllText(strFileName);

            string strFileName1 = @"D:\TotalEarning.txt";
            string fileText1 = File.ReadAllText(strFileName1);

            string strFileName2 = @"D:\TotalZingerSold.txt";
            string fileText2 = File.ReadAllText(strFileName2);

            string strFileName3 = @"D:\TotalTikaSold.txt";
            string fileText3 = File.ReadAllText(strFileName3);

            string strFileName4 = @"D:\TotalChickenBiryaniSold.txt";
            string fileText4 = File.ReadAllText(strFileName4);

            string strFileName5 = @"D:\TotalChickenBroastSold.txt";
            string fileText5 = File.ReadAllText(strFileName5);

            string strFileName6 = @"D:\TotalQormaSold.txt";
            string fileText6 = File.ReadAllText(strFileName6);

            string strFileName7 = @"D:\TotalDrinkSold.txt";
            string fileText7 = File.ReadAllText(strFileName7);


            MessageBox.Show("YESTURDAY TOKEN'S = " + fileText + "\nYESTURDAY EARNING = " + fileText1 + "\nYESTURDAY ZINGER SOLD = " + fileText2 + "\nYESTURDAY TIKA SOLD = " + fileText3 + "\nYESTURDAY CHICKEN BIRYANI SOLD = " + fileText4 + "\nYESTURDAY CHICKEN BROAST SOLD = " + fileText5 + "\nYESTURDAY CHICKEN QORMA SOLD = " + fileText6 + "\nYESTURDAY COCA-COLA SOLD = " + fileText7, "YESTURDAY CALCULATION ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }





        private void PaidAmount_Click(object sender, EventArgs e)
        {
            Calculating_Paid_Amount();
        }

        private void CALCULATE_TOTAL_AMOUNT_Click(object sender, EventArgs e)
        {
            Calculating_Price();
        }





        private void SET_ITEM1_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem1 = double.Parse(SetZingerTextBox.Text);

                s.Speak("congratulations price successfully changed Thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits  Thanks");

                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SET_ITEM2_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem2 = double.Parse(SetTikaTextbox.Text);

                s.Speak("congratulations price successfully changed Thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits Thanks ");

                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SET_ITEM3_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem3 = double.Parse(SetBiryaniTextBox.Text);

                s.Speak("congratulations price successfully changed Thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits thanks");

                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SET_ITEM4_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem4 = double.Parse(SetBroastTextBox.Text);

                s.Speak("congratulations price successfully changed thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits thanks");

                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SET_ITEM5_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem5 = double.Parse(SetQormaTextBox.Text);

                s.Speak("congratulations price successfully changed thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits thanks ");
                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void SET_ITEM6_PRICE_Click(object sender, EventArgs e)
        {
            try
            {
                setItem6 = double.Parse(SetDrinkTextBox.Text);

                s.Speak("congratulations price successfully changed thanks");

                MessageBox.Show("PRICE SUCCESSFULLY CHANGE !!", "SHOPPING CART", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                s.Speak("values can not be in characters please enter values in digits  thanks");

                MessageBox.Show("PLEASE ENTER VALUES IN DIGITS !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }




        private void CLEAR_TEXT_Click(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = 0;
            this.numericUpDown2.Value = 0;
            this.numericUpDown3.Value = 0;
            this.numericUpDown4.Value = 0;
            this.numericUpDown5.Value = 0;
            this.numericUpDown6.Value = 0;

            this.AmountToPay.Text = "0";
            this.TotalAmount.Text = "0";
            this.InsertDisscount.Text = "0";

            this.SetQormaTextBox.Text = "0";
            this.SetDrinkTextBox.Text = "0";
            this.SetZingerTextBox.Text = "0";
            this.SetTikaTextbox.Text = "0";
            this.SetBiryaniTextBox.Text = "0";
            this.SetBroastTextBox.Text = "0";
            this.Paid_Amount_OF_User.Text = "0";
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }



        
        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToLongTimeString();
            label5.Text = DateTime.Now.ToLongDateString();



            CheckingCheckBox1();
            CheckingCheckBox2();
            CheckingCheckBox3();
            CheckingCheckBox4();
            CheckingCheckBox5();
            CheckingCheckBox6();
            CheckingCheckBox7();
            CheckingCheckBox8();
            CheckingCheckBox9();
            CheckingCheckBox10();
            CheckingCheckBox11();
            CheckingCheckBox12();
            CheckingCheckBox13();


            CALCULATE_TOTAL_AMOUNT.BackColor = Color.RosyBrown;
            CLEAR_TEXT.BackColor = Color.RosyBrown;
            Exit_Application.BackColor = Color.RosyBrown;
            PaidAmount.BackColor = Color.RosyBrown;
            button1.BackColor = Color.RosyBrown;


            SET_ITEM1_PRICE.BackColor = Color.RosyBrown;
            SET_ITEM2_PRICE.BackColor = Color.RosyBrown;
            SET_ITEM3_PRICE.BackColor = Color.RosyBrown;
            SET_ITEM4_PRICE.BackColor = Color.RosyBrown;
            SET_ITEM5_PRICE.BackColor = Color.RosyBrown;
            SET_ITEM6_PRICE.BackColor = Color.RosyBrown;

            label6.BackColor = Color.PaleGreen;
            label7.BackColor = Color.PaleGreen;
            label8.BackColor = Color.PaleGreen;
            label9.BackColor = Color.PaleGreen;
            label10.BackColor = Color.PaleGreen;
            label11.BackColor = Color.PaleGreen;
            label12.BackColor = Color.PaleGreen;
            label13.BackColor = Color.PaleGreen;
            label14.BackColor = Color.PaleGreen;
            label15.BackColor = Color.PaleGreen;
            label16.BackColor = Color.PaleGreen;
            label17.BackColor = Color.PaleGreen;
            label19.BackColor = Color.PaleGreen;
            label20.BackColor = Color.PaleGreen;
            label21.BackColor = Color.PaleGreen;
            label22.BackColor = Color.PaleGreen;
            label23.BackColor = Color.PaleGreen;

            checkBox1.BackColor = Color.PaleGreen;
            checkBox2.BackColor = Color.PaleGreen;
            checkBox3.BackColor = Color.PaleGreen;
            checkBox4.BackColor = Color.PaleGreen;
            checkBox5.BackColor = Color.PaleGreen;
            checkBox6.BackColor = Color.PaleGreen;
            checkBox7.BackColor = Color.PaleGreen;
            checkBox8.BackColor = Color.PaleGreen;
            checkBox9.BackColor = Color.PaleGreen;
            checkBox10.BackColor = Color.PaleGreen;
            checkBox11.BackColor = Color.PaleGreen;
            checkBox12.BackColor = Color.PaleGreen;

            timer2.Start();

            //media.controls.play();
            
        }


        private void CheckingCheckBox1()
        {
            numericUpDown1.Enabled = checkBox1.Checked;
        }
        private void CheckingCheckBox2()
        {
            numericUpDown2.Enabled = checkBox2.Checked;
        }
        private void CheckingCheckBox3()
        {
            numericUpDown3.Enabled = checkBox3.Checked;
        }
        private void CheckingCheckBox4()
        {
            numericUpDown4.Enabled = checkBox4.Checked;
        }
        private void CheckingCheckBox5()
        {
            numericUpDown5.Enabled = checkBox5.Checked;
        }
        private void CheckingCheckBox6()
        {
            numericUpDown6.Enabled = checkBox6.Checked;
        }
        private void CheckingCheckBox7()
        {
            SET_ITEM1_PRICE.Enabled = checkBox7.Checked;
            SetZingerTextBox.Enabled = checkBox7.Checked;
        }
        private void CheckingCheckBox8()
        {
            SET_ITEM2_PRICE.Enabled = checkBox8.Checked;
            SetTikaTextbox.Enabled = checkBox8.Checked;
        }
        private void CheckingCheckBox9()
        {
            SET_ITEM3_PRICE.Enabled = checkBox9.Checked;
            SetBiryaniTextBox.Enabled = checkBox9.Checked;
        }
        private void CheckingCheckBox10()
        {
            SET_ITEM4_PRICE.Enabled = checkBox10.Checked;
            SetBroastTextBox.Enabled = checkBox10.Checked;
        }
        private void CheckingCheckBox11()
        {
            SET_ITEM5_PRICE.Enabled = checkBox11.Checked;
            SetQormaTextBox.Enabled = checkBox11.Checked;
        }
        private void CheckingCheckBox12()
        {
            SET_ITEM6_PRICE.Enabled = checkBox12.Checked;
            SetDrinkTextBox.Enabled = checkBox12.Checked;
        }
        private void CheckingCheckBox13()
        {
            InsertDisscount.Enabled = checkBox13.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox1();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox2();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox3();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox4();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox5();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox6();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox7();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox8();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox9();
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox10();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox11();
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox12();
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            CheckingCheckBox13();
        }



        private void Exit_Application_Click(object sender, EventArgs e)
        {
            DialogResult askToExit;

            s.Speak("Are you sure you want to exit ");

            askToExit = MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT ", "LOGIN", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (askToExit.Equals(DialogResult.Yes))
            {   
                form6.ShowDialog();
                s.Speak("Thanks to choose our product " + "your comfort our passion Thanks");
                Application.Exit();
            }
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();

            label1.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void gameForKidsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        private void googleCurrencyConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();

            f8.ShowDialog();
        }
    }
}
