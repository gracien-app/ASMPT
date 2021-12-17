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

        // Perform ray bounce, new ray is created from random values generated for each component.
        // Bounced ray origin is a hit position from which we are bouncing our ray.
        // If bounce direction is generated on wrong hemisphere (inside geometry) we negate it.
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

        // Method performing rendering of an image for N-samples.
        public void renderImage(int sampleCount, Bitmap bmp, bool isAssembly) {

            float Zedit = 0.4f;
            // Scene array containing procedural scene geometry.
            objects = new Sphere[] {
                new Sphere( new Vector4(0.0f, 0.15f-0.2f, -1.0f+Zedit, 0.0f), 0.15f, 
                            new Vector3(1.00f, 0.549f, 0.0f)),
                new Sphere( new Vector4(0.6f, 0.3f-0.2f, -1.5f+Zedit, 0.0f), 0.3f,
                            new Vector3(1.0f, 0.0f, 0.333f)),
                new Sphere( new Vector4(-0.6f, 0.3f-0.2f, -1.5f+Zedit, 0.0f), 0.3f,
                            new Vector3(0.251f, 0.878f, 0.816f)),
                new Sphere( new Vector4(0.0f, -1000.0f-0.2f, -1.0f, 0.0f), 1000.0f, 
                            new Vector3(0.455f, 0.463f, 0.471f)), 
            };

            float timeMin = 0.001f;
            float timeMax = 100000.0f;

            Vector3 skyColour = new Vector3(245.0f/255.0f, 245.0f/255.0f, 245.0f/255.0f);

            Random RNG = new Random();
            
            // Iterate through every pixel in the image
            for (int y = 0; y < imageHeight; y++) {
                for (int x = 0; x < imageWidth; x++) {

                    // Total colour accumulated for this pixel
                    Vector3 totalColour = new Vector3(0.0f);

                    // Performing actions for N-samples.
                    for (int i = 0; i < sampleCount; i++) {

                        // Offsets with random values to perform primitive antialiasing.
                        // We are randomly sampling neighbouring pixels in 3x3 grid. To smoothen the edges.
                        float offsetX = (float)((RNG.NextDouble()-0.5f)*2.0f);
                        float offsetY = (float)((RNG.NextDouble()-0.5f)*2.0f);

                        // Calculate pixel width and height ratio [0, 1].
                        // To find exact position we are using this data to offset camera starting position.
                        float pixelW = (x + offsetX) / (float)(imageWidth-1);
                        float pixelH = (y + offsetY) / (float)(imageHeight-1);
                        
                        int bounceLimit = 50;
                        
                        var pixelRay = camera.makeRay(pixelW, pixelH);
                        var tempColour = new Vector3(1.0f);

                        // Bounce ray unitil:
                        // 1) Limit is exceeded
                        // 2) Sky (no intersection) is reached
                        while(true) {

                            if(bounceLimit == 0) {
                                tempColour = new Vector3(0.0f);
                                break;
                            }

                            Sphere closestSphere = new Sphere();
                            float closestTime = timeMax;

                            // Iterate through all objects, find smallest intersection
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

                            // If any intersection was found, default sphere with 0 radius is overwritten.
                            if (closestSphere.radius != 0.0f) {
                                tempColour *= closestSphere.colour;
                                bounceLimit--;
                            } else {
                                tempColour *= skyColour;
                                break;
                            }

                            // Calculate bounced ray, set as our pixel ray for next iteration.
                            pixelRay = bounceRay(closestTime, closestSphere.radius, pixelRay, closestSphere.center, timeMin);
                        }

                        // Accumulate colour
                        totalColour += tempColour;
                    }

                    // Average colour
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
