using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tiktaktot01_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button  cliqué", "Message");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 10 cliqué", "Message");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 1 cliqué", "Message");
            button1.Text = "Off";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 2 cliqué", "Message");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 3 cliqué", "Message");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 4 cliqué", "Message");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 5 cliqué", "Message");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 6 cliqué", "Message");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 7 cliqué", "Message");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 8 cliqué", "Message");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button 9 cliqué", "Message");
        }

    }
}
