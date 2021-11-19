using System;
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

        public Ray bounceRay(float time, float radius, Ray inRay, Vector3 center) {
            
            Vector3 hitPos = inRay.at(time);
            Vector3 hitNormal = (hitPos - center) / radius;

            Random RNG = new Random();

            float x = (float)RNG.NextDouble();
            float y = (float)RNG.NextDouble();
            float z = (float)RNG.NextDouble();

            Vector3 randomDir = new Vector3(x, y, z);

            randomDir = Vector3.Normalize(randomDir);

            randomDir = Vector3.Dot(randomDir, hitNormal) > 0.0f ? randomDir : -randomDir;

            return new Ray(hitPos, randomDir);
        }

        public void renderImage(int sampleCount, Bitmap bmp) {

            objects = new Sphere[] {
                // new Sphere(new Vector3(0.0f, 0.0f, -0.6f), 0.05f, new Vector3(1.0f, 0.0f, 0.0f)),
                new Sphere(new Vector3(0.0f, 0.5f, -1.0f), 0.3f, new Vector3(0.0f, 1.0f, 0.0f)), 
            };

            float timeMin = 0.0001f;
            float timeMax = 100000.0f;
            int bounceLimit = 10;
            int sampleLimit = 10;

            Vector3 skyColour = new Vector3(221.0f/255.0f, 251.0f/255.0f, 1.0f);
            
            for (int y = 0; y < imageHeight; y++) {
                for (int x = 0; x < imageWidth; x++) {

                    Vector3 totalColour = new Vector3(0.0f);

                    float pixelW = x / (float)(imageWidth-1);
                    float pixelH = y / (float)(imageHeight-1);

                    for (int i = 0; i < sampleLimit; i++) {
                        
                        var pixelRay = camera.makeRay(pixelW, pixelH);
                        var tempColour = new Vector3(1.0f);

                        // while (bounceLimit > 0) {

                            Sphere closestSphere = new Sphere();
                            float closestTime = timeMax;

                            foreach (Sphere sph in objects) {
                                if (sph.Intersect(pixelRay, timeMin, ref closestTime)) {
                                    closestSphere = sph;
                                }  
                            }

                            if (closestSphere.radius != 0.0f) {
                                tempColour *= closestSphere.colour;
                            } else {
                                tempColour *= skyColour;
                                // break; 
                            }

                            pixelRay = bounceRay(closestTime, closestSphere.radius, pixelRay, closestSphere.center);
                            bounceLimit--;
                        // }

                        totalColour += tempColour;
                    }

                    totalColour /= sampleLimit;

                    Color outColor = Color.FromArgb((int)(totalColour.X * 255.0f),
                                                    (int)(totalColour.Y * 255.0f),
                                                    (int)(totalColour.Z * 255.0f));
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
