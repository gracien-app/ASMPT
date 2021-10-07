using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplClient
{
     class Client
    {
        public Bitmap bitmap { get; set; }

        public int NumberOfSamples { get; set; }

        public void StartRendering() 
        {
            for(var x = 0; x < bitmap.Width; x++)
            {
                for(var y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x,y,Color.Indigo);
                }
            }

        }
    }
}
