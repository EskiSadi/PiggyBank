using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PiggyBankLast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Para
        {
            // Field
            public string money_name;
            static public double money_value;
            static public string money_material;
            static public double hacim;
            static public bool is_folded = false;
            // Constructor
            public Para(double the_value, string the_name, string material, double the_hacim)
            {
                money_name = the_name;
                money_value = the_value;
                money_material = material;
                hacim = the_hacim;
            }
            // A display method, just for debugging
            public void Print()
            {
                Console.WriteLine("This money is worth {0} kurus and its name is {1}", money_value, money_name);
            }
            static public double GetMoneyValue()
            {
                return money_value;
            }
            static public double hacimValue()
            {
                return hacim;
            }
        }

        public class Kumbara
        {
            // The private list of moneys inside the bank
            public List<Para> list_of_money;
            // Is broken
            public bool is_broken = false;
            int breakcount = 0;
            public double toplam = 0;
            double dolanHacim = 0;
            const double kumbaraHacim = 50950;
            double dolanHacimShaken = 0;
            // A public method to add money inside the bank
            public void AddMoney(Para new_money)
            {
                if (is_broken == false && dolanHacim <= kumbaraHacim)
                {
                    if (Para.money_material == "Banknote")
                    {
                        if (Para.is_folded == false)
                        {
                            Form2 form = new Form2();
                            form.ShowDialog();
                            if (form.is_FoldingAccepted == 1)
                            {
                                Para.is_folded = true;
                            }
                        }
                    }
                    if (Para.money_material == "Coin")
                    {
                        Random generator = new Random();
                        double x = generator.NextDouble();
                        double y = 1.25 + x / 2;
                        Console.WriteLine(y);
                        if (!(kumbaraHacim <= (dolanHacim + (Para.hacim) * y)))
                        {
                            dolanHacim += (Para.hacim) * y;
                            dolanHacimShaken += (Para.hacim);
                            list_of_money.Add(new_money);
                            toplam += Para.GetMoneyValue();
                            MessageBox.Show("Money added!");
                        }
                        else
                        {
                            MessageBox.Show("Piggy Bank is full of money. Therefore you can no longer add this type of money. Try other money kinds.");
                        }
                    }
                    else if (Para.money_material == "Banknote" && Para.is_folded == true)
                    {
                        Random generator = new Random();
                        double x = generator.NextDouble();
                        double y = 1.25 + x / 2;
                        Console.WriteLine(y);
                        if (!(kumbaraHacim <= (dolanHacim + (Para.hacim) * y)))
                        {
                            dolanHacim += (Para.hacim) * y;
                            dolanHacimShaken += (Para.hacim);
                            list_of_money.Add(new_money);
                            toplam += Para.GetMoneyValue();
                            MessageBox.Show("Money added!");
                            Para.is_folded = false;
                        }
                        else
                        {
                            Para.is_folded = false;
                            MessageBox.Show("Piggy Bank is full of money. Therefore you can no longer add this type of money. Try adding other types of money.");
                        }
                        


                    }
                }
                else if (is_broken == true)
                {

                    MessageBox.Show("Piggy Bank is broken, therefore you can't add money.");
                }
            }

          
            public Kumbara()
            {
                //MessageBox.Show("You have made a piggy bank!");
                list_of_money = new List<Para>();
            }
            // Break
            public List<Para> Break()
            {
                if (is_broken == true)
                {
                    MessageBox.Show("You already have broken the bank!");
                    List<Para> empty_list = new List<Para>();
                    return empty_list;
                }
                else
                {
                    MessageBox.Show("You have broken the bank!");
                    MessageBox.Show("Balance: " + toplam.ToString());
                    toplam = 0;
                    dolanHacim = 0;
                }
                is_broken = true;
                breakcount++;
                return list_of_money;
            }
            public void Fix()
            {
                if (breakcount <= 1)
                {
                    if (is_broken == true)
                    {
                        MessageBox.Show("Piggy bank is fixed");
                        is_broken = false;
                    }
                    else
                    {
                        MessageBox.Show("Piggy bank is already doing alright. No need to fix it.");
                    }
                }
                else
                {
                    MessageBox.Show("You can only repair the piggy bank for once.");
                }
            }
            public void Shake()
            {
                if (is_broken == false)
                {
                    MessageBox.Show($"%{(int)(dolanHacim / kumbaraHacim * 100)} kadarı doluydu.");
                    dolanHacim = dolanHacimShaken;
                    MessageBox.Show($"Salladıktan sonra %{(int)(dolanHacim / kumbaraHacim * 100)} kadarı dolu");
                }
                else
                {
                    MessageBox.Show("Piggy Bank is broken, therefore you can not shake it.");
                }

            }
        }
        Kumbara my_kumbara = new Kumbara();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            my_kumbara.Break();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            my_kumbara.Fix();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Para elliKurus = new Para(0.50, "50 Kuruş", "Coin", 848.39875875);
            my_kumbara.AddMoney(elliKurus);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Para birkurus = new Para(0.01, "1 Kuruş", "Coin", 288.5169375);
            my_kumbara.AddMoney(birkurus);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Para onkurus = new Para(0.10, "10 Kuruş", "Coin", 443.2993125);
            my_kumbara.AddMoney(onkurus);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Para yirmibeskurus = new Para(0.25, "25 Kuruş", "Coin", 544.3288125);
            my_kumbara.AddMoney(yirmibeskurus);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Para birLira = new Para(1, "1 Lira", "Coin", 1019.92125875);
            my_kumbara.AddMoney(birLira);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Para besLira = new Para(5, "5 Lira", "Banknote", 8320);
            my_kumbara.AddMoney(besLira);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Para onLira = new Para(10, "10 Lira", "Banknote", 8704);
            my_kumbara.AddMoney(onLira);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Para yirmiLira = new Para(20, "20 Lira", "Banknote", 9656);
            my_kumbara.AddMoney(yirmiLira);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Para elliLira = new Para(50, "50 Lira", "Banknote", 10064);
            my_kumbara.AddMoney(elliLira);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Para yuzLira = new Para(100, "100 Lira", "Banknote", 11088);
            my_kumbara.AddMoney(yuzLira);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Para ikiYuzLira = new Para(200, "200 Lira", "Banknote", 11520);
            my_kumbara.AddMoney(ikiYuzLira);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Para besKurus = new Para(0.05, "5 Kuruş", "Coin", 396.6703125);
            my_kumbara.AddMoney(besKurus);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            my_kumbara.Shake();
        }
    }
}
 