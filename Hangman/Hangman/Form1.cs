using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Variabler
        string word = "";
        List<Label> labels = new List<Label>();
        int guesses = 0;

        //Alla delar av Hangman
        enum hangmanParts
        {
            Head,
            Left_eye,
            Right_eye,
            Mouth,
            Body,
            Right_arm,
            Left_arm,
            Right_leg,
            Left_leg
        }

        //Ritar alla Hangman delar 
        void drawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(20, 269), new Point(20, 5));
            g.DrawLine(p, new Point(20, 10), new Point(120, 10));
            g.DrawLine(p, new Point(115, 10), new Point(115, 50));
        }

        void drawBodyPart(hangmanParts part)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);

            if(part == hangmanParts.Head)
            {
                g.DrawEllipse(p, 95, 50, 40, 40);
            }
            else if (part == hangmanParts.Left_eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 105, 60, 5, 5);
            }
            else if (part == hangmanParts.Right_eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 120, 60, 5, 5);
            }
            else if (part == hangmanParts.Mouth)
            {
                g.DrawArc(p, 105, 60, 20, 20, 45, 90);
            }
            else if (part == hangmanParts.Body)
            {
                g.DrawLine(p, new Point(115, 90), new Point(115, 170));
            }
            else if (part == hangmanParts.Left_arm)
            {
                g.DrawLine(p, new Point(115, 100), new Point(70, 85));
            }
            else if (part == hangmanParts.Right_arm)
            {
                g.DrawLine(p, new Point(115, 100), new Point(160, 85));
            }
            else if (part == hangmanParts.Left_leg)
            {
                g.DrawLine(p, new Point(115, 170), new Point(80, 190));
            }
            else if (part == hangmanParts.Right_leg)
            {
                g.DrawLine(p, new Point(115, 170), new Point(150, 190));
            }
        }

        void createLabels()
        {
            word = GetRandomWord();
            char[] chars = word.ToCharArray();
            int between = 330 / chars.Length - 1;
            for(int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 80); //Mellan = 40
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            label1.Text = "Ord längd: " + (chars.Length).ToString();
        }

        //Returnerar ett slumpmässigt ord ur words fältet
        string GetRandomWord()
        {
            Random rand = new Random();
            string[] words = new string[6];
            words[0] = "blå";
            words[1] = "kaka";
            words[2] = "dator";
            words[3] = "zoo";
            words[4] = "cykel";
            words[5] = "flygplan";

            return words[rand.Next(0, 6)];
        }

        
        private void btn_guessChar_Click(object sender, EventArgs e)
        {
            char letter = textBox1.Text.ToLower().ToCharArray()[0];
            if (!char.IsLetter(letter))
            {
                MessageBox.Show("Du kan bara gissa bokstäver!", "FEL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (word.Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for(int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                    {
                        labels[i].Text = letter.ToString();
                    }
                }
                foreach(Label l in labels)   
                    if (l.Text == "_") return;
                MessageBox.Show("Du vann!", "Grattis");
                resetGame();
                
            }
            else
            {
                MessageBox.Show("Bokstaven du gissade var inte korrekt!", "Ledsen");
                label2.Text += " " + letter.ToString() + ",";
                drawBodyPart((hangmanParts)guesses);
                guesses++;
                if(guesses == 9)
                {
                    MessageBox.Show("Du förlorade, Ordet var:" + word, "Pröva igen");
                    resetGame();
                }
            }
        }

        void resetGame()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            GetRandomWord();
            createLabels();
            drawHangPost();
            label2.Text = "Fel: ";
            textBox1.Text = "";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawHangPost();
            createLabels();
        }

        private void btn_guessString_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == word)
            {
                MessageBox.Show("Du vann", "Grattis");
                resetGame();
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Ordet du gissade var fel", "Ledsen");
                drawBodyPart((hangmanParts)guesses);
                guesses++;
                if (guesses == 9)
                {
                    MessageBox.Show("Du förlorade, Ordet var:" + word, "Pröva igen");
                    resetGame();
                }
            }
        }
    }
}
