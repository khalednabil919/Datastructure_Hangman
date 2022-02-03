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
    public partial class Form4 : Form
    {
        int wrong = 0;
        string rec;
        string word;
        char[] arr;
        int i = 9;
        public static int count1 = 0;
        public Form4()
        {
            InitializeComponent();
        }
        public void intialize1(string recievedword)
        {
          word = recievedword;
             rec = "";
            for (int i = 0; i < recievedword.Length; i++)
            {
                if (word[i] != ' ')
                {
                    rec += "-";
                }
                else
                {
                    rec += " ";
                }
            }
            label1.Text = rec;
        }



        public void fun (char x)
        {
            bool check = false;

            arr = rec.ToCharArray();
            for(int i=0;i<word.Length;i++)
            {
                if(word[i]==x)
                {
                    arr[i] = x;
                    check = true;
                }
            }
            if(check==false)
            {
                wrong++;
                pictureBox1.Image = Form2.images[wrong];
                i--;
            }

            rec = new string(arr);

            label1.Text = rec;
            if (i == 0)
            {
                Form1.losssound();
                DialogResult result = MessageBox.Show("You Lost", "player 2 your round", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Form5 f5 = new Form5();
                    this.Hide();
                    f5.ShowDialog();

                }
         
            }
            else if (label1.Text == word)
            {
                Form1.winsound();
                count1++;
                DialogResult result = MessageBox.Show("You Won", "player 2 your round", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Form5 f5 = new Form5();
                    this.Hide();
                    f5.ShowDialog();
                }
            }
            label2.Text = i.ToString();
            label2.Text += " lifes remaining";
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button1.Enabled = false;
            char x = 'A';
            fun(x);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button6.Enabled = false;
            char x = 'B';
            fun(x);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button5.Enabled = false;
            char x = 'C';
            fun(x);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button4.Enabled = false;
            char x = 'D';
            fun(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button3.Enabled = false;
            char x = 'E';
            fun(x);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button2.Enabled = false;
            char x = 'F';
            fun(x);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button26.Enabled = false;
            char x = 'G';
            fun(x);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button13.Enabled = false;
            char x = 'H';
            fun(x);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button14.Enabled = false;
            char x = 'I';
            fun(x);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button15.Enabled = false;
            char x = 'J';
            fun(x);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button12.Enabled = false;
            char x = 'K';
            fun(x);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button7.Enabled = false;
            char x = 'L';
            fun(x);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button8.Enabled = false;
            char x = 'M';
            fun(x);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button9.Enabled = false;
            char x = 'N';
            fun(x);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button10.Enabled = false;
            char x = 'O';
            fun(x);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button11.Enabled = false;
            char x = 'P';
            fun(x);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button18.Enabled = false;
            char x = 'Q';
            fun(x);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button17.Enabled = false;
            char x = 'R';
            fun(x);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button16.Enabled = false;
            char x = 'S';
            fun(x);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button22.Enabled = false;
            char x = 'T';
            fun(x);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button19.Enabled = false;
            char x = 'U';
            fun(x);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button20.Enabled = false;
            char x = 'V';
            fun(x);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button21.Enabled = false;
            char x = 'W';
            fun(x);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button23.Enabled = false;
            char x = 'X';
            fun(x);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button24.Enabled = false;
            char x = 'Y';
            fun(x);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button25.Enabled = false;
            char x = 'Z';
            fun(x);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            Form5 f5 = new Form5();
            this.Hide();
            f5.ShowDialog();

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }
    }
}
