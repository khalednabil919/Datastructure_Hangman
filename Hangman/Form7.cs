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
using System.IO;
using WMPLib;
namespace WindowsFormsApplication9
{
    public partial class Form7 : Form
    {
        
        int count = 0;
        public Form7()
        {
            InitializeComponent();
            Form1.music_on = int.Parse(File.ReadAllText("music.txt"));
            if (Form1.music_on == 0)
            {
                button2.Enabled =false;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("music.txt","1");
            Form1.music_on = 1;
            count++;
            Form1.player.URL = "closer.mp3";
            Form1.player.controls.play();
            button2.Enabled = true;
            button1.Enabled = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText("music.txt", "0");
            Form1.music_on = 0;
            Form1.player.URL = "closer.mp3";
            Form1.player.controls.stop();
            button1.Enabled = true;
            button2.Enabled = false;   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            Form1 f1 = new Form1();
            f1.ShowDialog();

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


       
    }
}
