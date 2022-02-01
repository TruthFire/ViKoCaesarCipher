using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaesarCipher
{
    public partial class Form1 : Form
    {
        char[] Letters =
        {
            'A','a','B','b','C','c','D','d','E','e','F','f','G','g','H','h','I','i','J','j','K','k',
            'L','l','M','m','N','n','O','o','P','p','Q','q','R','r','S','s','T','t','U','u','V','v',
            'W','w','X','x','Y','y','Z','z'
        };

        
        public Form1()
        {
            InitializeComponent();

            string input = "The quick brown fox jumps over the lazy dog";
            string output = "";
            int key = 3;
            
        }

        protected string EncryptArray(string input, int key)
        {
            string output = "";
            int letterIndex, EncryptedLetterIndex;
            foreach (char c in input)
            {
                letterIndex = Array.IndexOf(Letters, c); //Get index of required letter in Letters array
                if (letterIndex == -1)
                {
                    output += c;
                    continue;
                }
                else if (letterIndex <= Letters.Length - key * 2)
                {
                    output += Letters[letterIndex + key * 2].ToString();
                    continue;
                }
                else if (letterIndex >= Letters.Length - key * 2) //
                {
                    EncryptedLetterIndex = letterIndex - (Letters.Length - key * 2);
                    output += Letters[EncryptedLetterIndex].ToString();
                }
            }

            return output;
        }

        protected string DecryptArray(string input, int key)
        {
            string output = "";

            int letterIndex, EncryptedLetterIndex;
            foreach (char c in input)
            {
                letterIndex = Array.IndexOf(Letters, c); //Get index of required letter in Letters array
                if (letterIndex == -1)
                {
                    output += c;
                    continue;
                }
                else if (letterIndex - (key * 2) < 0)
                {
                    output += Letters[Letters.Length + (letterIndex-key*2)].ToString();
                    continue;
                }
                else if (letterIndex - key * 2 > 0) //
                {
                    EncryptedLetterIndex = letterIndex -  key * 2;
                    output += Letters[EncryptedLetterIndex].ToString();
                }
                else
                {
                    output += Letters[0];
                }
            }

            return output;

        }

        protected string EncryptASCII(string input, int key)
        {
            string output = "";

            foreach(char c in input)
            {
                if ((int)c >= 65 && (int)c <= 90 || (int)c >= 97 && (int)c <= 122)
                {
                    if((int)c+key > 90 && (int)c+ key < 97)
                    {
                        output += Convert.ToChar(64 + ((int)c + key - 90)); //NOT FIXED :(
                        continue;
                    }
                    else if ((int)c + key > 122)
                    {
                        output += Convert.ToChar(96 + ((int)c + key) - 122);
                    }
                    else
                    {
                        output += Convert.ToChar(((int)c + key));
                    }
                }
                else
                {
                    output += c;
                }
            }


            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = EncryptASCII(this.textBox1.Text, (int)this.numericUpDown1.Value);
            //this.textBox2.Text += EncryptArray(this.textBox1.Text, (int)this.numericUpDown1.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
          this.textBox1.Text = DecryptArray(this.textBox2.Text, (int)this.numericUpDown1.Value);
        }
    }
}
