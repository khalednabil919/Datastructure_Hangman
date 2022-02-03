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
namespace WindowsFormsApplication9
{
    public partial class Form2 : Form
    {
        public static Bitmap[] images = {
                                     WindowsFormsApplication9.Properties.Resources._1,
                                     WindowsFormsApplication9.Properties.Resources._2,
                                     WindowsFormsApplication9.Properties.Resources._3,
                                     WindowsFormsApplication9.Properties.Resources._4,
                                     WindowsFormsApplication9.Properties.Resources._5,
                                     WindowsFormsApplication9.Properties.Resources._6,
                                     WindowsFormsApplication9.Properties.Resources._7,
                                     WindowsFormsApplication9.Properties.Resources._8,
                                     WindowsFormsApplication9.Properties.Resources._9,
                                     WindowsFormsApplication9.Properties.Resources._10
                                 };
        public static int continuegame = 0;
        int score;
        bool savegame = true;
        bool resetgame = true;
        Dictionary<string, string> readfiles=new Dictionary<string,string>(); //de map el key bta3ha hwa esm el file wl value hwa el 7aga eli mwgoda gwa el file
        bool func1orfunc2;
        int COUNTERHINT; // da eli b3mlo 3shan a3rf lw a5r 7aga kant hint 2bl el undo wla l2 lw hint h5li b 1 lw zorarf 8er hint b 0
        Stack<char> carrybuttons = new Stack<char>(); //da eli byshel el buttons kola eli mat8ot 3leha
        //Stack<int> swr = new Stack<int>();
        
        Stack<string> carryhint = new Stack<string>(); //da byshel klmt hint nfsha 
        Stack<string> carrylabel = new Stack<string>(); //da byshel el label
        Stack<string> carrylives = new Stack<string>();  //da byshel el string bta3 3dd el lives
        Stack<int> carrycounthint = new Stack<int>();  // da byshel 3dd el hints 
        List<char> fillword = new List<char>();
        string buttonfiles="";
        string word = "";
        char guesschar;
        int I = 9,a=0;   //el I de 3dd el trails eli hma el 9 m7wlat
        string h;
        string filltheword = "";
        string l = "";
        int count = 0;
        int counterhint = 3;
        
        private void intialize()
        {

            for (int i = 0; i < h.Length; i++)
            {
                if (h[i] != ' ') //el h eli string
                    l += '-';
                else
                    l += ' ';
               
               
            }
            carrylabel.Push(l); //hna hn3ml push ll label whwa kolo shorat
            pushfunc();
            carrycounthint.Push(counterhint); //b3ml push l3dd el hint
        }
        private void eachplayercodeformultiplayers(char guess)
        {
            
            button27.Enabled = true;
            carrycounthint.Push(counterhint);
            bool check = false;
            if (count == 0)
            {
                intialize();
                count++;
            }
            l = carrylabel.Peek();
            carrybuttons.Push(guess);
            char[] arr = l.ToCharArray();
            for (int i = 0; i < h.Length; i++)
            {
                if (h[i] == guess)
                {
                    arr[i] = guess;
                    check = true;
                }
            }
            if (check == false)
            {
                a++;
                I--;
                pictureBox1.Image = images[a];
            }
            l = new string(arr);

            label1.Text = l;
            if (I == 0)
            {
                Form1.losssound();
                continuegame = 0;
                System.IO.File.WriteAllText("savegame.txt", continuegame.ToString());
                savegame = false;
                DialogResult result = MessageBox.Show("You Lost", "do you want to play again", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    this.Close();
                    this.Hide();
                }
                else
                {
                    resetgame = false;
                    this.Close();
                    this.Hide();
                    Form1.reset();
                } 
            }
            else if (label1.Text == h)
            {
                int highscore=int.Parse(File.ReadAllText(Form1.username));
                score = h.Length * 15 - (9 - I) * 6;
                if (score > highscore)
                {
                    System.IO.File.WriteAllText(Form1.username, score.ToString());
                }
                Form1.winsound();
                continuegame = 0;
                System.IO.File.WriteAllText("savegame.txt", continuegame.ToString());
                savegame = false;
                DialogResult result = MessageBox.Show("You Won", "do you want to play again", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    this.Close();
                    this.Hide();
                }
                else
                {
                    resetgame = false;
                    this.Close();
                    this.Hide();
                    Form1.reset();

                }
            }
            Form1.swr.Push(a);
            label2.Text = I.ToString();
            label2.Text += " lifes remaining";
            pushfunc();
        }

        private void files() //awl ama bdos yes 3la el save bya5od kolo ymla fe form2
        {
            System.IO.File.WriteAllText("WORD.txt", h); //hna b7ot fl file esm el word eli 5dtha random 
            System.IO.File.WriteAllText("image.txt",Convert.ToString(a)); //hna b7ot fl file bta3 el image el index bta3 el sora 
            System.IO.File.WriteAllText("LABEL.txt", label1.Text); //hna b7ot el label eli fe el text
            System.IO.File.WriteAllText("HINT.txt", Hintbutton.Text); //hna b7ot el text bta3 el button fe el file bta3 el hint
            System.IO.File.WriteAllText("LIFE.txt", label2.Text); //hna b7ot el string bta3 el lives remaining fl file
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    if (c.Enabled == true)
                    {
                        continue;
                    }
                    else
                    {
                        if(c!=Hintbutton&&c!=button27) //3shan mysawish la el hint wla el undo eli hwa button 27
                        buttonfiles += c.Text;
                    }
                }
            }   //hna fl if de bshof el zrair el mdas 3leha w a7otha fl string eli esmha buttonfiles 
            System.IO.File.WriteAllText("BUTTON.txt", buttonfiles); //hna b7ot button fiiles de kolha fl file eli esmo button
            buttonfiles = ""; 
            
            
        }
        public void func2() //func1 bta5od random lakn func2 bta5od mn el files
        {
            func1orfunc2 = false;  //3shan y3rf eno d5l fl save
            button27.Enabled = false;
            readfiles["image"] = File.ReadAllText("image.txt"); 
            readfiles["word"] = File.ReadAllText("WORD.txt");
            readfiles["Label1"] = File.ReadAllText("LABEL.txt");
            readfiles["Label2"] = File.ReadAllText("LIFE.txt");
            readfiles["Hint"] = File.ReadAllText("HINT.txt");
            readfiles["button"] = File.ReadAllText("BUTTON.txt");  //hna ba5od eli fl file a7oto fl value bta3 el map
            h = readfiles["word"]; //h7ot elkey bta3 el map bta3 el word fl klma
            a = Convert.ToInt32(readfiles["image"]); //bna5od mn el map el index bta3 el sora w n7oto fl a
            pictureBox1.Image = images[a]; //by3rd el sora
            label1.Text = readfiles["Label1"];
            label2.Text = readfiles["Label2"];
            Hintbutton.Text = readfiles["Hint"];
            for (int i = 0; i < readfiles["button"].Count(); i++)
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Button&&c.Text==readfiles["button"][i].ToString())
                    {
                        c.Enabled = false;     
                    }
                }
            } //hna bndos 3la el zrair eli kan mdas 3leha  hna bn3ml nested loop 3shan nlf 3la kol zorar fl file m3a kol el zrair
            I = label2.Text[0]-'0'; //el trails htsawi awl index fl label   -0 de bt7wl l int
            if (Hintbutton.Text != "Hint")
                counterhint = Hintbutton.Text[5] - '0'; 
            else
                Hintbutton.Enabled = false; 
        }
        public void func1()
        {
            button27.Enabled = false;
            func1orfunc2 = true;//3shan y3rf eno md5lsh fl save
            List<char> fillword = new List<char>();
            string leveldifficulity;
            List<string> file1 = new List<string>();
            Dictionary<string, List<string>> mycategory = new Dictionary<string, List<string>>();
            string catname;
            catname = Form1.chossencat;
            mycategory = Form1.mycat;
            leveldifficulity = Form1.level;
            /*
            for(int i=0;i<mycat[catname].Count();i++)
            {
                file1.Add(mycat[catname][i]);
            }
             */
           /* using (StreamReader sr = new StreamReader((catname+".txt"))
            {
                for (int i = 0; i <11; i++)
                {
                    file.Add(sr.ReadLine());
                }
            }*/
            if (leveldifficulity == "EASY")
            {
                while (true)
                {
                    Random RN = new Random();
                    word = mycategory[catname][RN.Next(0, mycategory[catname].Count())];
                    if (word.Length <= 5)
                        break;
                }
            }
            else if (leveldifficulity == "MEDIUM")
            {
                while (true)
                {
                    Random RN = new Random();
                    word = mycategory[catname][RN.Next(0, mycategory[catname].Count())];
                    if (word.Length > 5&&word.Length<10)
                        break;
                }
            }
            else if (leveldifficulity == "HARD")
            {
                while (true)
                {
                    Random RN = new Random();
                    word = mycategory[catname][RN.Next(0, mycategory[catname].Count())];
                    if (word.Length >= 10)
                        break;
                }
            }
            h = word;
            for (int i = 0; i < word.Count(); i++)
            {
                if (h[i] != ' ')
                    fillword.Add('-');
                else
                    fillword.Add(' ');
            }
            string f = "";
            for (int i = 0; i < fillword.Count(); i++)
            {
                f += fillword[i];
            }
            label1.Text = f;

        }
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText(Form1.username);  //hna awl ama aft7 ha7ot fl textbox bta3 el high score 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'A';
            COUNTERHINT = 0;
            button1.Enabled = false;
            eachplayercodeformultiplayers(b);

            // if(button1.clicked())

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'B';
            COUNTERHINT = 0;
            button6.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'C';
            COUNTERHINT = 0;
            button5.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'D';
            COUNTERHINT = 0;
            button4.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'E';
            COUNTERHINT = 0;
            button3.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'F';
            COUNTERHINT = 0;
            button2.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'H';
            COUNTERHINT = 0;
            button13.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'I';
            COUNTERHINT = 0;
            button14.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'J';
            COUNTERHINT = 0;
            button15.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'K';
            COUNTERHINT = 0;
            button12.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'L';
            COUNTERHINT = 0;
            button7.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'M';
            COUNTERHINT = 0;
            button8.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'N';
            COUNTERHINT = 0;
            button9.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'O';
            COUNTERHINT = 0;
            button10.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'P';
            COUNTERHINT = 0;
            button11.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'Q';
            COUNTERHINT = 0;
            button18.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'R';
            COUNTERHINT = 0;
            button17.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'S';
            COUNTERHINT = 0;
            button16.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'T';
            COUNTERHINT = 0;
            button22.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'U';
            COUNTERHINT = 0;
            button19.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'V';
            COUNTERHINT = 0;
            button20.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'W';
            COUNTERHINT = 0;
            button21.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'X';
            COUNTERHINT = 0;
            button23.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'Y';
            COUNTERHINT = 0;
            button24.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'Z';
            COUNTERHINT = 0;
            button25.Enabled = false;
            eachplayercodeformultiplayers(b);
         
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            char b = 'G';
            COUNTERHINT = 0;
            button26.Enabled = false;
            eachplayercodeformultiplayers(b);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Form1.playsound();
            button27.Enabled = true;
            COUNTERHINT = 1;
            if (count == 0)
            {
                intialize();
                count++;
            }
            List<char> hint = new List<char>(carrylabel.Peek());
           
            
            bool entered = false;
                while (true)
                {
                    Random randomchar = new Random();
                    int i = randomchar.Next(hint.Count());
                    if (hint[i] == '-')
                    {
                        entered = true;
                        char x = h[i];
                        carrybuttons.Push(x);
                        for (int j = 0; j < h.Length; j++)
                        {
                            if (h[j] == x)
                            {
                                hint[j] = h[j];
                            }
                        }
                        if (entered == true)
                        {
                      foreach (Control c in this.Controls)
                    {
                        if (c is Button)
                        {
                            string tmpchar = h[i].ToString();
                            if(c.Text==tmpchar){
                                c.Enabled = false;


                            }
                        }
                    }
                            break;
                        }
                    }
                    else
                        continue;
                    
                }
                char[] hinter = l.ToCharArray();
                for (int i = 0; i < h.Length; i++)
                {
                    hinter[i] = hint[i];
                }
                l = new string(hinter);
                label1.Text = l;
                counterhint--;
                carrycounthint.Push(counterhint);
                Hintbutton.Text = "Hint" + "("+counterhint.ToString()+")";
                if (Hintbutton.Text == "Hint(0)")
                {
                    Hintbutton.Text = "Hint";
                }
                if (l == h)
                {
                    int highscore = int.Parse(File.ReadAllText(Form1.username));
                    score = h.Length * 15 - (9 - I) * 6;
                    if (score > highscore)
                    {
                        System.IO.File.WriteAllText(Form1.username, score.ToString());
                    }
                    Form1.winsound();
                    continuegame = 0;
                    System.IO.File.WriteAllText("savegame.txt", continuegame.ToString());
                    savegame = false;
                   DialogResult result= MessageBox.Show("You Won","do you want to play again",MessageBoxButtons.YesNo);
                   if(result==DialogResult.No)
                   {
                       Form1 f1 = new Form1();
                       this.Close();
                       this.Hide();
                       f1.ShowDialog();

                   }
                   else
                   {
                       resetgame = false;
                       this.Close();
                       this.Hide();
                       Form1.reset();
                   }
                }
                if (counterhint == 0)
                {
                    Hintbutton.Text = "Hint";
                    Hintbutton.Enabled = false;
                }
                Form1.swr.Push(a);
                pushfunc();

        }
        
        private void button27_Click_1(object sender, EventArgs e)
        {
            Form1.playsound();
        }
        private void pushfunc()
        {
    
            carryhint.Push(Hintbutton.Text);  //push ll text bta3 zorfar el hint
            carrylabel.Push(label1.Text); //byshel el klma 
            carrylives.Push(label2.Text); //da byshel el lives remaining
        }
        private void undo()
        {
            int previouscounterhint = carrycounthint.Peek(); //da byshel eli fl front fl stack eli fe arkam el hint
            string previouslabel = label1.Text; //da hyb2a eli feh el klma 
            char BUTTON = carrybuttons.Peek(); //b7ot feha a5r zorar mwgod
            int C=carrycounthint.Peek(); //nfs eli fo2 
             Form1.swr.Pop();
            a = Form1.swr.Peek(); //el a de feha el index bta3 el array eli byshel el swr b3d m3a 3mlt el pop
            carrybuttons.Pop(); 
            carryhint.Pop();
            carrylabel.Pop();
            carrylives.Pop();  // kol el pop eli fo2 da hyrg3 el stack bl zmn 5atwa
            carrycounthint.Pop();
            label1.Text = carrylabel.Peek();
            label2.Text = carrylives.Peek();
            Hintbutton.Text = carryhint.Peek(); //swena el labels wl text bta3 el hint bli fl front
            string lives = carrylives.Peek(); ///\libes hyshel el string bta3 el lives remaining
           /* if (COUNTERHINT == 1 && counterhint == 0)
                Hintbutton.Enabled = true;
            */
            if (C != carrycounthint.Peek())
            {
                COUNTERHINT = 1;  // 5ltha b 1 3shan 3mlt undo ll hint
            }
            if (carrycounthint.Peek() > 0 && COUNTERHINT == 1)
                Hintbutton.Enabled = true; //ana hna bhandle lw a5r 7aga kant undo ll hint a5li yt3mlo enabled 3shan ynwr

            for (int i = 0; i < carrylives.Peek().Count(); i++)
            {
                if (lives[i] >= '0' && lives[i] <= '9')
                {
                    I = lives[i] - '0';
                }
            }                          // fl loop de bsawi el rkm eli f el lives remaining b I eli hya 3dd el trails
            string HINTER = carryhint.Peek();
            for (int i = 0; i < carryhint.Peek().Count(); i++)
            {
                if (HINTER[i] >= '0' && HINTER[i] <= '3')
                {
                    counterhint = HINTER[i] - '0';
                }
            }       //hna b3ml nfs el 7war eli fo2 b s m3a hint
            foreach (Control c in this.Controls) //de btlf 3la kol 7aga fl form
            {
                if (c is Button) //de hna b2olo lw el c de button
                {
                    if (c.Text == BUTTON.ToString())
                    {
                        c.Enabled = true;
                    }
                }
            }
            if (func1orfunc2 == true) //y3ni d5l fl random msh fl save
            {
                bool emptylabel = true; //y3ni el label eli b n5mn feh el klma fadi kolo b shorat
                if (label2.Text == "9 Lives Remaining")
                {
                    for (int i = 0; i < h.Count(); i++)
                    {
                        if (label1.Text[i] != '-'&&label1.Text[i]!=' ')
                        {
                            emptylabel = false;
                        }
                    }
                    if (emptylabel == true)
                        button27.Enabled = false;
                }
            }  // el if de 3shan lw md5lsh fl save fa by3ml diasble ll undo lma kol 7aga trg3 fadya y3ni el label ykon b shorat wl label eli fo2 ykon 9 lives wl zarair kolha tkon enabled
            else
            {
                bool lastlabel = true;
                if (label2.Text == readfiles["Label2"] && label1.Text == readfiles["Label1"])
                {
                    button27.Enabled = false;
                }
            } // hna 3shan lma ados save hytfi el undo l7d a5r 7aga kont 3mlha save fa byshof lw el labels wl button eli 3ndo nfs eli fl files y3m disable ll undo
            pictureBox1.Image = images[Form1.swr.Peek()]; //hna 5od el index bta3 el sora el adimaa w y7oto fl array 3shan ytl3 el sora el adima
        }

        private void button27_Click_2(object sender, EventArgs e)
        {
            Form1.playsound();
            undo();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (savegame == true)
            {
                DialogResult closing = new DialogResult();
                closing = MessageBox.Show("do you want to save", "exit", MessageBoxButtons.YesNo);
                if (closing == DialogResult.Yes)
                {
                    System.IO.File.WriteAllText("lastname.txt", Form1.lastsavedname);
                    files();
                    continuegame = 1;
                    System.IO.File.WriteAllText("savegame.txt", continuegame.ToString());
                }
                else
                {
                    continuegame = 0;
                    System.IO.File.WriteAllText("savegame.txt", continuegame.ToString());
                }
                
                savegame = true;
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
            }
            if (resetgame == true)
            {
                savegame = true;
                Form1 f1 = new Form1();
                this.Hide();
                f1.ShowDialog();
            }
           
        }
    }
}
