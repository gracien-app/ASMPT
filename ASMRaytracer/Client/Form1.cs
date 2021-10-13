using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            client = new Client

            {
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height)
            };
            asmProxy = new AsmProxy();

            pictureBox1.ClientSize = new Size(client.bitmap.Width, client.bitmap.Height);
            pictureBox1.Image = (Image)client.bitmap;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.StartRendering();
            pictureBox1.Refresh();

            textBox1.Text =  asmProxy.executeAsmAddTwoDoubles(2,3).ToString();
        }

        private Client client;
        private AsmProxy asmProxy;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            client.NumberOfSamples = (int) numericUpDown1.Value;
        }
    }
}
