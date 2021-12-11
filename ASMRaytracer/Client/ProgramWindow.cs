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
    //Responsible for User Interface.
    public partial class ProgramWindow : Form
    {
        //EventHandler, only method subsribed to it is in Program.cs and is responsible for starting renderer process.
        //Handler is invoked when button is clicked.
        public event EventHandler<RendererArguments> ButtonIsClicked;

        //Bitmap belonging to asmPictureBox.
        //When renderer is called this object is given as rendering argument.
        public Bitmap asmBitmap { get; set; }

        //Bitmap belonging to csPictureBox.
        //When renderer is called this object is given as rendering argument.
        public Bitmap csBitmap { get; set; }

        //Number of samples for renderer
        //Value is sent to renderer via rendererArguments object when button is clicked.
        //Value is assigned based on user inputs from slider.value
        private int NumberOfSamples { get; set; }

        //Object responsible for measuring time of assembler renderer.
        private PerformanceProfailer profAsm { get; set; }

        //Object responsible for measuring time of C# renderer
        private PerformanceProfailer profCs { get; set; }

        public ProgramWindow()
        {
            InitializeComponent();
            profAsm = new PerformanceProfailer();
            profCs = new PerformanceProfailer();

            //Size of rendered images.
            //Value 500x500 is default as it results in nice output with not that long execution time
            //WARNING! This value is "hard-coded", but can be modified after changing it in renderer.
            //Renderer should be initialized with same arguments in program.cs
            asmBitmap = new Bitmap(500, 500);
            csBitmap = new Bitmap(500, 500);
        }

        //Method called when button is clicked. Starts rendering by sending proper arguments.
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Lock button, simple purely graphical feature.
            LockStartButton();
            //Checks what renderer or renderers should be run.
            if(this.CsCheckbox.Checked)
            {
                //Those comments apply for both if statments.
                //Starts time measurments.
                profCs.StartTimeMeasurment();
                //Creates new object RendererArguments and invokes EventHandler.
                //This even handler should be connected to method in program.cs that starts rendering with arguments sent.
                ButtonIsClicked?.Invoke(this, new RendererArguments { bitmap = csBitmap, NumberOfSamples = this.SamplesTrackBar.Value, isAssembly = false });
                //Stops time measurement.
                profCs.StopTimeMeasurement();
                //Displays time measured.
                this.CsTimeLabel.Text =  profCs.ReturnSeconds();
                //Displays genereted image
                CSImage.Image = (Image)csBitmap;
            }
            this.Update();
            if (this.AsmCheckbox.Checked)
            {
                profAsm.StartTimeMeasurment();
                ButtonIsClicked?.Invoke(this, new RendererArguments { bitmap = asmBitmap, NumberOfSamples = this.SamplesTrackBar.Value, isAssembly = true });
                profAsm.StopTimeMeasurement();
                this.AsmTimeLabel.Text = profAsm.ReturnSeconds();
                AsmImage.Image = (Image)asmBitmap;
            }
            UnlockStartButton();
        }

        //Changes buttons appearance to look like program is doing something.
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

        //Resize events to scale UI.
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

        //Displaying vlue chosen on trackbar.
        private void SampleTrackbar_Scroll(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.SamplesTrackBar, SamplesTrackBar.Value.ToString());
        }
    }
}
