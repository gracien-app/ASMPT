using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AplClient
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///
        public static Renderer.Renderer renderer;
        public static ProgramWindow window;

        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Create renderer with bitmap 500x500
            renderer = new Renderer.Renderer(500, 500);

            //Create ProgramWindow
            window = new ProgramWindow();

            //Subscribe Program.Form_ButtonIsClicked to ButtonIsClicked event of window
            //After ButtonIsClicked metohds is invoked Form_ButtonIsClicked will be executed.
            window.ButtonIsClicked += Form_ButtonIsClicked;

            Application.Run(window);
        }

        public static void Form_ButtonIsClicked(object sender, AplClient.RendererArguments arg)
        {
            renderer.renderImage(arg.NumberOfSamples, arg.bitmap);
        }
    }
}
