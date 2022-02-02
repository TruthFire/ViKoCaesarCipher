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
        }; //Array of big and small letters

        
        public Form1()
        {
            InitializeComponent();
        }

        // Array

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
                if (letterIndex == -1) //If not letter
                {
                    output += c;
                    continue;
                }
                else if (letterIndex - (key * 2) < 0) //If letter is in range
                {
                    output += Letters[Letters.Length + (letterIndex-key*2)].ToString();
                    continue;
                }
                else if (letterIndex - key * 2 > 0) //If letter is out of range
                {
                    EncryptedLetterIndex = letterIndex -  key * 2;
                    output += Letters[EncryptedLetterIndex].ToString();
                    continue;
                }
                else 
                {
                    output += Letters[0];
                }
            }

            return output;

        }

        //ASCII

        protected static bool IsASCIILetter(char c)
        {
            return ((int)c >= 65 && (int)c <= 90 || (int)c >= 97 && (int)c <= 122); 
            //a - 65, z = 90, A = 97, Z = 122;
        }

        protected static string EncryptASCII_Letters(string input, int key)
        {
            string output = "";

            foreach(char c in input)
            {
                if (IsASCIILetter(c)) 
                {
                    if((int)c+key > 90 && (int)c+ key < 97) //If big letter out of range
                    {
                        output += Convert.ToChar(64 + ((int)c + key - 90));
                        continue;
                    }
                    else if ((int)c + key > 122) //If small letter out of range
                    {
                        output += Convert.ToChar(96 + ((int)c + key) - 122);
                        continue;
                    }
                    else //In range
                    {
                        output += Convert.ToChar(((int)c + key));
                    }
                }
                else //not a letter
                {
                    output += c;
                }
            }


            return output;
        }

        protected string DecryptASCII_Letters(string input, int key)
        {
            string output = "";

            foreach(char c in input)
            {
                if(IsASCIILetter(c))
                {
                    if ((int)c - key < 65) //If big letter out of range
                    {
                        output += Convert.ToChar((int)c-key+26);
                        continue;
                    }
                    else if ((int)c - key < 97 && (int)c - key > 90) //If small letter out of range
                    {
                        output += Convert.ToChar((int)c - key + 26);
                        continue;
                    }
                    else
                    {
                        output += Convert.ToChar((int)c - 3);
                    }
                    

                }
                else
                {
                    output += c;
                }
            }

            return output;
        }


        //EVENTS 

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = EncryptASCII_Letters(this.textBox1.Text, (int)this.numericUpDown1.Value);
            //this.textBox2.Text += EncryptArray(this.textBox1.Text, (int)this.numericUpDown1.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = DecryptArray(this.textBox2.Text, (int)this.numericUpDown1.Value);
            //EncryptArray(this.textBox2.Text, 26-(int)this.numericUpDown1.Value - works too
            this.textBox1.Text = DecryptASCII_Letters(this.textBox2.Text, (int)this.numericUpDown1.Value);
        }
    }
}
