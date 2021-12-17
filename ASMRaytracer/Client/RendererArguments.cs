using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplClient
{
    //Object genereted after user click rendering button.
    //Stores all required input from UI and is send to renderer.
    public class RendererArguments : EventArgs
    {
        //Bitmap reference, renderer will set pixels of this object to proper values.
        public Bitmap bitmap { get; set; }

        //NumberOfSamples for renderer.
        public int NumberOfSamples { get; set; }

        //Boolean value describing if request concerns Assembly or C# renderer.
        //If True, render using assembly procedures.
        //If False, render using C#
        public bool isAssembly { get; set; }
    }
}
