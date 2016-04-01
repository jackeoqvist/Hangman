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

        enum hangmanParts
        {
            Head,
            Left_eye,
            Right_eye,
            Mouth,
            Right_arm,
            Left_arm,
            Body,
            Right_leg,
            Left_leg
        }

        void drawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(20, 269), new Point(20, 5));
            g.DrawLine(p, new Point(20, 10), new Point(120, 10));
            g.DrawLine(p, new Point(115, 10), new Point(115, 50));
            drawBodyPart(hangmanParts.Head);
            drawBodyPart(hangmanParts.Left_eye);
            drawBodyPart(hangmanParts.Right_eye);
            drawBodyPart(hangmanParts.Mouth);
            drawBodyPart(hangmanParts.Body);
            drawBodyPart(hangmanParts.Left_arm);
            drawBodyPart(hangmanParts.Right_arm);
            drawBodyPart(hangmanParts.Left_leg);
            drawBodyPart(hangmanParts.Right_leg);
            MessageBox.Show(GetRandomWord());
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

        string GetRandomWord()
        {
            Random rand = new Random();
            string[] words = new string[4];
            words[0] = "Blå";
            words[1] = "Kaka";
            words[2] = "Dator";
            words[3] = "Zoo";

            return words[rand.Next(0, 4)];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawHangPost();
        }
    }
}
