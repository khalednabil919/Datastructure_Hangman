using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using WMPLib;
namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public static Stack<int> swr = new Stack<int>(); //da stack eli byshel index bta3 el swr
        public static int music_on=int.Parse(File.ReadAllText("music.txt"));
        public static Dictionary<string, List<string>> mycat=new Dictionary<string,List<string>>();
        public static string chossencat;
        public static string level;
        public static bool musicon = false;
        public static string username;
        public static string lastsavedname;
        bool gooutoffunction=false;
        public static WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent(); // ay 7aga fe public form1 de intializecomponent de bt3rf kol 7aga mogrd ma el form bttft7 abl ama ados 3la ay button
            comboBox3.Items.Clear(); // kol mara bfdi el combobox 3shan myktbsh kol el asma2 tani mrten
            string allusers=File.ReadAllText("selectuser.txt");
            string fillcombobox="";
            for (int i = 0; i < allusers.Length; i++)
            {
                if (allusers[i] != ',')
                {
                    fillcombobox += allusers[i]; 
                }
                else
                {
                    comboBox3.Items.Add(fillcombobox); //hna bmla lw l2et coma b7ot el klma eli 2blha fl combobox w b3d kda bfdi el string 3shan a7ot feh klma tanya 2bl el coma eli b3deha
                    fillcombobox = ""; 
                }
            }
        }
       
        
        private void button2_Click(object sender, EventArgs e)
        {
            playsound();
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        public static void reset()
        {
            Form2 f2 = new Form2();
            f2.func1();
            f2.ShowDialog();

        }
        public void caller()
        {
            this.button1.PerformClick();
        }
       public static void playsound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "button.wav"; //dy ely feha el sot el zrair
            player.Play();
        }
       public static void winsound()
       {
           System.Media.SoundPlayer player = new System.Media.SoundPlayer();
           player.SoundLocation = "win.wav";  // dy ely feha sot el mksb
           player.Play();
       }
       public static void losssound()
       {
           System.Media.SoundPlayer player = new System.Media.SoundPlayer();
           player.SoundLocation = "loss.wav"; // dy ely feha sot el 5osara
           player.Play();
       }
        public void button1_Click(object sender, EventArgs e)
        {
            playsound();
            if (textBox1.Text.Length > 0)
            {
                File.AppendAllText("selectuser.txt", textBox1.Text+","); //b7ot hna asm new user fl file w b3deh coma
                 username = textBox1.Text + ".txt"; //.txt 3shan yob2a file ytktb feh
                using (StreamWriter sw = File.CreateText(username))
                {
                    sw.WriteLine("0"); //ay wa7d geded el score bta3o lsa b 0
                }
                lastsavedname = textBox1.Text; //b3ml string a7ot feh a5r 7aga 3shan b3d kda a7otha fl file bta3 last user 
               
            }
            else if (comboBox3.Text != "USER.."&&comboBox3.Text.Length>0) //hna 3shan lw el combobox msh fadya wla btsawi el 7aga el default
            {
                username = comboBox3.Text+".txt"; 
                lastsavedname = comboBox3.Text;
               
            }
            else
            {
                gooutoffunction = true; // dy y3ni el 2 fadyen bs msh htl3 el message bta3t please enter the data 8er lma at2kd ano msh hydos yes fy do you want to continue
            }
            List<string> file = new List<string>();
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                string path = Environment.CurrentDirectory + "/" + comboBox1.Items[i].ToString() + ".txt";

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {

                        file.Add(line);
                    }
                    string items = comboBox1.Items[i].ToString();
                    mycat[items] = file;
                    file = new List<string>();
                }
            }
            chossencat = comboBox1.Text;
            level = comboBox2.Text;
            //Form1 f1 = new Form1();
            //string f = "khaled";
            string continueornot = File.ReadAllText("savegame.txt"); 
            if (continueornot == "1")  //continueornot de b5liha b 1 lw  dost yes fe do you want to save wlw ksbt aw 5srt aw dost no htb2a bzero
            {
                string lastuser = File.ReadAllText("lastname.txt");
                
                DialogResult result = MessageBox.Show("do you want to continue as the last user", "hello", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    username = lastuser+".txt";
                    lastsavedname = lastuser;
                    Form2 f2 = new Form2();
                    f2.func2();  //hna hy3ml code el save lw 3aiz ykml
                    this.Hide();
                    f2.ShowDialog();

                }
                else
                {
                 swr.Push(0); //lw no hya5od awl sora 5als
                    if (gooutoffunction == true)
                    {
                        MessageBox.Show("you must choose a user or add new user", "invalid", MessageBoxButtons.OK);
                        gooutoffunction = false;
                        return;
                    }
                    Form2 f2 = new Form2();
                    f2.func1();
                    this.Hide();
                    f2.ShowDialog();
                    
                }
            }
       
        else{
            if (gooutoffunction==true)
            {
                MessageBox.Show("you must choose a user or add new user", "invalid", MessageBoxButtons.OK);
                gooutoffunction = false;
                return;
            }
            swr.Push(0);
        Form2 f2 = new Form2();
                    f2.func1();
                    this.Hide();
                    f2.ShowDialog();

          }
}

        private void button4_Click(object sender, EventArgs e)
        {
            playsound();
            Form7 f7 = new Form7();
            this.Hide();
            f7.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playsound();
            DialogResult result = MessageBox.Show("Are you sure you want to exit", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                System.IO.File.WriteAllText("music.txt", "0");
                Application.ExitThread();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
