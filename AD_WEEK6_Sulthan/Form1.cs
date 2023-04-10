using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_WEEK6_Sulthan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int X=Convert.ToInt32(input.Text);
            if (X > 1)
            {
                Form2 game = new Form2();
                Form2.join = X;
                game.Show();
            }
            else
            {
                MessageBox.Show("Minimal 3 !!"); 
            }
        }
    }
}
