using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_WEEK6_Sulthan
{
    public partial class Form2 : Form
    {
        string[] copas = File.ReadAllText("Wordle Word List.txt").Split(',');
        Random kata = new Random();
        int jalan = 0;
        int baris = 0;
        int cek = 0;
        int cek1 = 0;
        int posisi = 10;
        int lokasi1 = 0;
        int lokasi2 = 0;
        int pembatas = 4;
        int pembatask = 0;
        int cheking = 0;
        int c = 0;
        int d = 4;
        int q = 0;
        int w = 0;
        string chek = "";
        string jawaban = "";
        string tampung = "";
        string nebak = "";
        string answer = "";
        string key = "";
        string jawab = "";
        public static int join = 0;
        List<Button> jwban = new List<Button>();
        List<Button> keyboard = new List<Button>();
        List<string> keylist = new List<string>() { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "ENTER", "Z", "X", "C", "V", "B", "N", "M", "DELATE" };
        List<string> rondom = new List<string>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            jawaban = copas[kata.Next(0, copas.Length)];
            for (int i = 0; i < 5; i++)
            {
                for (int x = 0; x < join; x++)
                {
                    Button but_kotak = new Button();
                    but_kotak.Enabled = true;
                    but_kotak.Size = new Size(70, 70);
                    but_kotak.Location = new Point(30 + (70 * x), 80 + (70 * i));
                    but_kotak.Tag = x.ToString() + "," + i.ToString();
                    jwban.Add(but_kotak);
                    this.Controls.Add(but_kotak);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (i >= 1)
                {
                    posisi = 9;

                }
                for (int x = 0; x < posisi; x++)
                {
                    Button btnkeyboard = new Button();
                    btnkeyboard.Enabled = true;
                    btnkeyboard.Size = new Size(55, 55);
                    btnkeyboard.Location = new Point(360 + (50 + lokasi1), 60 + (50 + lokasi2));
                    btnkeyboard.Tag = keylist[cek1];
                    btnkeyboard.Text = keylist[cek1];
                    keyboard.Add(btnkeyboard);
                    lokasi1 += 53;

                    cek1++;
                }
                lokasi2 += 53;
                lokasi1 = 0;

            }

            foreach (Button button in keyboard)
            {
                button.Click += button_keyboard;
                this.Controls.Add(button);
            }
            jawab = copas[kata.Next(0, copas.Length)];
            MessageBox.Show(jawab);
        }
        private void button_keyboard(object sender, EventArgs e)
        {
            Button but_kotak = sender as Button;
            if (cek <= pembatas)
            {

                foreach (Button button in keyboard)
                {
                    if (button.Tag == but_kotak.Tag && but_kotak.Tag.ToString() != "ENTER" && but_kotak.Tag.ToString() != "DELATE")
                    {
                        jwban[cek].Text = button.Text;
                        cek++;
                    }
                }
            }
            if (but_kotak.Tag.ToString() == "ENTER")
            {
                cheking = 0;
                if (cek == pembatas + 1)
                {
                    chek = "";
                    for (int i = c; i <= d; i++)
                    {
                        chek += jwban[i].Text;
                    }
                    for (int j = 0; j <= copas.Length - 1; j++)
                    {
                        if (chek.ToUpper() == copas[j].ToUpper())
                        {
                            cheking = 7;
                        }
                    }
                    if (cheking == 7)
                    {
                        warna();
                        pembatask += 5;
                        pembatas += 5;
                        c += 5;
                        d += 5;
                    }
                    else
                    {
                        MessageBox.Show(chek + "not on the word list");
                    }


                }
            }
            if (but_kotak.Tag.ToString() == "DELATE")
            {
                if (cek != pembatask)
                {
                    jwban[cek - 1].Text = "";
                    cek--;
                }

            }
        }
        public void warna()
        {

            rondom.Clear();
            q = 0;
            for (int i = 0; i < jawab.Length; i++)
            {
                rondom.Add(jawab[i].ToString().ToUpper());
            }
            for (int h = w; h <= pembatas; h++)
            {

                if (jwban[h].Text == jawab[q].ToString().ToUpper())
                {
                    jwban[h].BackColor = Color.Green;
                    rondom[q] = "";
                }
                q++;
            }
            for (int k = w; k <= pembatas; k++)
            {
                foreach (string cekkuning in rondom)
                {
                    if (jwban[k].Text == cekkuning)
                    {
                        jwban[k].BackColor = Color.Yellow;
                    }
                }
            }
            w += 5;
        }
    }
}
        

