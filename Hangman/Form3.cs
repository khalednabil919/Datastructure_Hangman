using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form3 : Form
    {
        string recievedword="";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "A";
            textBox1.Text += a;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "B";
            textBox1.Text += a;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "C";
            textBox1.Text += a;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "D";
            textBox1.Text += a;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "E";
            textBox1.Text += a;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "F";
            textBox1.Text += a;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "G";
            textBox1.Text += a;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "H";
            textBox1.Text += a;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "I";
            textBox1.Text += a;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "J";
            textBox1.Text += a;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "K";
            textBox1.Text += a;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "L";
            textBox1.Text += a;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "M";
            textBox1.Text += a;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "N";
            textBox1.Text += a;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "O";
            textBox1.Text += a;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "P";
            textBox1.Text += a;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "Q";
            textBox1.Text += a;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "R";
            textBox1.Text += a;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "S";
            textBox1.Text += a;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "T";
            textBox1.Text += a;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "U";
            textBox1.Text += a;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "V";
            textBox1.Text += a;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "W";
            textBox1.Text += a;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "X";
            textBox1.Text += a;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "Y";
            textBox1.Text += a;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            string a = "Z";
            textBox1.Text += a;
        }
        public void button27_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            Form4 f4=new Form4();
            recievedword = textBox1.Text;
            f4.intialize1(recievedword);
            this.Hide();
            f4.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
          
            this.Hide();
            f1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
