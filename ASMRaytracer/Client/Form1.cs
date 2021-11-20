using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AplClient
{
    public partial class ProgramWindow : Form
    {
        public ProgramWindow()
        {

            InitializeComponent();
            client = new Client
            {
                bitmap = new Bitmap(500, 500)
            };
            asmProxy = new AsmProxy();

            
        }

        private Client client;
        private AsmProxy asmProxy;

        private void StartButton_Click(object sender, EventArgs e)
        {
            client.NumberOfSamples = this.SamplesTrackBar.Value;
            client.StartRendering();

            if(this.AsmCheckbox.Checked)
            {
                AsmImage.Image = (Image)client.bitmap;
            }
            if(this.CsCheckbox.Checked)
            {
                CSImage.Image = (Image)client.bitmap;
            }
        }

        private void AsmTable_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            this.AsmImage.Size = new Size(control.Width, control.Height - this.AsmDescriptionTable.Size.Height);
        }

        private void CsTable_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            this.CSImage.Size = new Size(control.Width, control.Height - this.CsDescriptionTable.Size.Height);
        }

        private void SampleTrackbar_Scroll(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.SamplesTrackBar, SamplesTrackBar.Value.ToString());
        }

    }
}
