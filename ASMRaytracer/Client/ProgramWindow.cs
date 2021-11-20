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
using AplClient;

namespace AplClient
{
    public partial class ProgramWindow : Form
    {

        public event EventHandler<RendererArguments> ButtonIsClicked;

        public Bitmap asmBitmap { get; set; }
        public Bitmap csBitmap { get; set; }

        private int NumberOfSamples { get; set; }

        private PerformanceProfailer profAsm { get; set; }
        private PerformanceProfailer profCs { get; set; }

        public ProgramWindow()
        {
            InitializeComponent();
            profAsm = new PerformanceProfailer();
            profCs = new PerformanceProfailer();

            asmBitmap = new Bitmap(500, 500);
            csBitmap = new Bitmap(500, 500);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            LockStartButton();
            if (this.AsmCheckbox.Checked)
            {
                profAsm.StartTimeMeasurment();
                ButtonIsClicked?.Invoke(this, new RendererArguments { bitmap = asmBitmap, NumberOfSamples = this.SamplesTrackBar.Value });
                profAsm.StopTimeMeasurement();
                AsmImage.Image = (Image)asmBitmap;
                this.AsmTimeLabel.Text = profAsm.ReturnSeconds();
            }
            if(this.CsCheckbox.Checked)
            {
                
                profCs.StartTimeMeasurment();
                ButtonIsClicked?.Invoke(this, new RendererArguments { bitmap = csBitmap, NumberOfSamples = this.SamplesTrackBar.Value });
                profCs.StopTimeMeasurement();

                this.CsTimeLabel.Text =  profCs.ReturnSeconds();
                CSImage.Image = (Image)csBitmap;
            }
            UnlockStartButton();
        }

        private void LockStartButton()
        {
            this.StartButton.BackColor = Color.Red;
            this.StartButton.Text = "Rendering...";
            this.StartButton.Enabled = false;
            
        }

        private void UnlockStartButton()
        {
            this.StartButton.BackColor = SystemColors.Control;
            this.StartButton.Text = "Start";
            this.StartButton.Enabled = true;
            
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
