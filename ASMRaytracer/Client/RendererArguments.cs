using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplClient
{
    public class RendererArguments : EventArgs
    {
        public Bitmap bitmap { get; set; }
        public int NumberOfSamples { get; set; }
        public bool isAssembly { get; set; }
    }
}
