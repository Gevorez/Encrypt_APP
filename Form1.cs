using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSK_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void szyfrXor()
        {
            string tekst = textBox2.Text;

            char[] msg = tekst.ToCharArray();

            char[] key = textBox1.Text.ToCharArray();

            int i = 0;

            string wynik = "";

            for (int j = 0; j < tekst.Length; j++)
            {
                char c = (char)((int)msg[j] ^ (int)key[i++ % key.Length] ^ (int)key[i++ % key.Length]);
                wynik = wynik + c;
            }

            textBox3.Text = wynik;
        }

        private void szyfrCezar()
        {
            string input = textBox2.Text;

            int shift = int.Parse(textBox4.Text);

            char[] alphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            string wynik2 = "";

            char[] input_array = input.ToCharArray();

            for (int j = 0; j < input_array.Length; j++)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (input_array[j] == alphabet[i])
                    {
                        input_array[j] = alphabet[(i + shift) % alphabet.Length];
                        break;
                    }
                }
            }

            wynik2 = new string(input_array);

            textBox3.Text = wynik2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton rb1 = radioButton1;
            RadioButton rb2 = radioButton2;

            if (rb1.Checked)
            {
                szyfrXor();
                rb2.Checked = false;
            }

            if (rb2.Checked)
            {
                szyfrCezar();
                rb1.Checked = false;
                textBox1.Text = String.Empty;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb2 = radioButton2;
            if (rb2.Checked)
            {
                textBox1.Text = String.Empty;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb1 = radioButton1;
            if (rb1.Checked)
            {
                textBox4.Text = String.Empty;
            }
        }
    }
}
