using System;
using System.Windows.Forms;

namespace CaesarCipher
{
    public partial class Form1 : Form
    {
        //the quick brown fox jumps over the lazy dog
        //THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG
        public Form1()
        {
            InitializeComponent();
        }

        Caesar cc = new Caesar();

        //EVENTS 

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = cc.EncryptASCII(this.textBox1.Text, (int)this.numericUpDown1.Value);
            //this.textBox2.Text += EncryptArray(this.textBox1.Text, (int)this.numericUpDown1.Value);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = DecryptArray(this.textBox2.Text, (int)this.numericUpDown1.Value);
            //EncryptArray(this.textBox2.Text, 26-(int)this.numericUpDown1.Value - works too
            this.textBox1.Text = cc.DecryptASCII(this.textBox2.Text, (int)this.numericUpDown1.Value);
        }
    }
}
