using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Renderer;

namespace AplClient
{
     class Client
    {
        public Bitmap bitmap { get; set; }

        public int NumberOfSamples { get; set; }

        private global::Renderer.Renderer renderer;

        public void StartRendering() 
        {
            renderer = new global::Renderer.Renderer(bitmap.Width, bitmap.Height);

            renderer.renderImage(NumberOfSamples, bitmap);
        }
    }
}
