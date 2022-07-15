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
    public partial class Form2 : Form
    {

        public int is_FoldingAccepted;
        public Form2()
        {
            InitializeComponent();
            is_FoldingAccepted = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            is_FoldingAccepted = 1;
            MessageBox.Show("Money is folded.");
            Form2.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            is_FoldingAccepted = 0;
            ActiveForm.Close();
        }
    }
}
