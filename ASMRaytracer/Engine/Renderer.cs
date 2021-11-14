using System.Drawing;
using System.Numerics;

namespace Renderer
{
    class Renderer {

        public Renderer(int width, int height) {
            imageWidth = width;
            imageHeight = height;
            camera = new Camera(width, height);
        }

        public void renderImage(int sampleCount, Bitmap bmp) {

            objects = new Sphere[] {
                new Sphere(new Vector3(0.0f, 0.0f, -0.6f), 0.05f, Color.FromArgb(255, 0, 0, 255)),
                new Sphere(new Vector3(0.0f, 0.0f, -1.0f), 0.3f, Color.FromArgb(255, 0, 255, 0)), 
            };

            float timeMin = 0.0001f;
            float timeMax = 100000.0f;
            
            for (int y = 0; y < imageHeight; y++) {
                for (int x = 0; x < imageWidth; x++) {

                    float pixelW = x / (float)(imageWidth-1);
                    float pixelH = y / (float)(imageHeight-1);

                    var pixelRay = camera.makeRay(pixelW, pixelH);

                    int R = (int)(255.0f * pixelW);
                    int G = (int)(255.0f * pixelH);
                    int B = (int)(0.5f * 255.0f);

                    Color outColor = Color.FromArgb(R, G, B);

                    float closestTime = timeMax;

                    foreach (Sphere sph in objects) {
                        if (sph.Intersect(pixelRay, timeMin, ref closestTime)) {
                            outColor = sph.colour;
                        }  
                    }

                    bmp.SetPixel(x, y, outColor);

                }
            }

         }

        private Camera camera;
        private int imageWidth;
        private int imageHeight;
        private Sphere[] objects;
    }

}
