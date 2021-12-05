using System;
using System.Drawing;
using System.Numerics;
using AplClient;

namespace Renderer
{

    class Renderer {

        public Renderer(int width, int height) {
            imageWidth = width;
            imageHeight = height;
            camera = new Camera(width, height);
            proxy = new AsmProxy();
        }

        public Ray bounceRay(float time, float radius, Ray inRay, Vector4 center, float timeMin) {
            
            Vector4 hitPos = inRay.at(time);
            Vector4 hitNormal = (hitPos - center) / radius;

            Random RNG = new Random();

            float x = (float)((RNG.NextDouble()-0.5f)*2.0f);
            float y = (float)((RNG.NextDouble()-0.5f)*2.0f);
            float z = (float)((RNG.NextDouble()-0.5f)*2.0f);

            Vector4 randomDir = new Vector4(x, y, z, 0.0f);

            randomDir = Vector4.Normalize(randomDir);

            randomDir = Vector4.Dot(randomDir, hitNormal) > 0.0f ? randomDir : -randomDir;

            return new Ray((hitPos + hitNormal * timeMin), randomDir);
        }

        public void renderImage(int sampleCount, Bitmap bmp, bool isAssembly) {

            if (sampleCount <= 0) sampleCount = 1;

            objects = new Sphere[] {
                new Sphere( new Vector4(0.0f, 0.3f-0.2f, -1.0f, 0.0f), 0.3f, 
                            new Vector3(0.41f, 0.41f, 0.41f)), 
                new Sphere( new Vector4(0.0f, -1000.0f-0.2f, -1.0f, 0.0f), 1000.0f, 
                            new Vector3(0.41f, 0.41f, 0.41f)), 
            };

            float timeMin = 0.001f;
            float timeMax = 100000.0f;

            Vector3 skyColour = new Vector3(221.0f/255.0f, 251.0f/255.0f, 1.0f);

            Random RNG = new Random();
            
            for (int y = 0; y < imageHeight; y++) {
                for (int x = 0; x < imageWidth; x++) {

                    Vector3 totalColour = new Vector3(0.0f);

                    for (int i = 0; i < sampleCount; i++) {

                        float offsetX = (float)((RNG.NextDouble()-0.5f)*2.0f);
                        float offsetY = (float)((RNG.NextDouble()-0.5f)*2.0f);

                        float pixelW = (x + offsetX) / (float)(imageWidth-1);
                        float pixelH = (y + offsetY) / (float)(imageHeight-1);
                        
                        int bounceLimit = 50;
                        
                        var pixelRay = camera.makeRay(pixelW, pixelH);
                        var tempColour = new Vector3(1.0f);

                        while(true) {

                            if(bounceLimit == 0) {
                                tempColour = new Vector3(0.0f);
                                break;
                            }

                            Sphere closestSphere = new Sphere();
                            float closestTime = timeMax;

                            foreach (Sphere sph in objects) {

                                if (isAssembly) {
                                    if (proxy.executeAsmIntersect(pixelRay, timeMin, ref closestTime, sph.center, sph.radius)) {
                                        closestSphere = sph;
                                    }
                                }

                                else if (sph.IntersectNoAcceleration(pixelRay, timeMin, ref closestTime)) {
                                    closestSphere = sph;
                                }  
                            }

                            if (closestSphere.radius != 0.0f) {
                                tempColour *= closestSphere.colour;
                                bounceLimit--;
                            } else {
                                tempColour *= skyColour;
                                break;
                            }

                            pixelRay = bounceRay(closestTime, closestSphere.radius, pixelRay, closestSphere.center, timeMin);
                        }

                        totalColour += tempColour;
                    }

                    totalColour /= sampleCount;

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
        private AsmProxy proxy;
        
    }

}
