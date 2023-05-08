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

namespace Smartphone
{
    public partial class Form1 : Form
    {
        string word;
        Button[] t9;
        Button[] keyboard;
        bool capc = true;
        public Form1()
        {
            word = File.ReadAllText("T9.txt");
            t9 = new Button[]
            {
                button7, button8, button9
            };
            keyboard = new Button[]
            {
            button1, button2, button3, button4, button5, button6, button10,button11,button12,
            button13,button14,button15,button16,button17,button18,button19,button20,button21,button22,
            button23,button24,button25,button26,button27,button28,button29,button30,button31,button32,
            button33,button34,button35

            };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length);
            if (textBox1.Text.Length == 0)
            {
                button7_Click(sender, e);
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] Buffer1 = textBox1.Text.Split();
            if (button9.Text == Buffer1[Buffer1.Length - 1] && word.Contains(Buffer1[Buffer1.Length - 1]))
            {
                File.AppendAllText("T9.txt", '\n' + Buffer1[Buffer1.Length - 1]);
                return;
            }

            Buffer1[Buffer1.Length - 1] = b.Text;
            textBox1.Text = "\t";
            foreach (var i in Buffer1)
            {
                textBox1.Text += " \t";
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text += button.Text;
            if (capc == true)
            {
                foreach (Button button1 in keyboard)
                {
                    if (button1 == button7 || button1 == button8 || button1 == button9)
                    {
                        button1.Text = Convert.ToChar(Convert.ToInt32(button.Text[0] + 32)).ToString();
                    }
                }
            }
            else
            {
                capc = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] words = word.Split();
            List<string> list_T9 = new List<string>() { };
            string[] buf = textBox1.Text.Split();
            foreach (var i in words)
            {
                if (i.Contains(buf[buf.Length - 1]) && i != buf[buf.Length - 1]) ;
                {
                    list_T9.Add(i);
                }
                button7.Text = ""; button8.Text = ""; button9.Text = "";

            }
            for (int j = 0; j <= list_T9.Count; j++)
            {
                t9[j].Text = list_T9[j];
            }
            if (button7.Text == " " && button8.Text == " " && button9.Text == "")
            {
                button8.Text = buf[buf.Length - 1];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
