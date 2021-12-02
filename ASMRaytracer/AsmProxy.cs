using System;
using System.Numerics;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    public unsafe class AsmProxy
    {
        //Dll import pattern.
        [DllImport("..\\AsmLibrary.dll")]
        private static extern double asmAddTwoDoublesTwo(double a, double b);
        
        [DllImport("..\\AsmLibrary.dll")]
        private static extern double asmDotProduct(double x0, double y0, double z0,
                                                double x1, double y1, double z1 );


        public double executeAsmAddTwoDoubles(double a, double b)
        {
            return asmAddTwoDoublesTwo(a, b);
        }

        public float executeDotProduct(Vector3 first, Vector3 second)
        {
            return (float)asmDotProduct(first.X, first.Y, first.Z, second.X, second.Y, second.Z);
        }

        public bool executeAsmIntersect(Ray inRay, float timeMin, ref float timeMax, Vector3 center, float radius)
        {
            Vector3 originC = inRay.origin - center;
            float a = inRay.direct.LengthSquared();
            float b = executeDotProduct(inRay.direct, originC);
            float c = (originC).LengthSquared() - (radius * radius);

            float delta = b * b - a * c;

            float root = 0.0f;

            if (delta < 0.0) return false;
            else
            {
                float deltaSqrt = MathF.Sqrt(delta);

                //root = (-b - deltaSqrt) / a;
                if (root > timeMax || root < timeMin)
                {
                    //root = (-b + deltaSqrt) / a;
                    if (root > timeMax || root < timeMin)
                    {
                        return false;
                    }
                }
            }

            timeMax = root;

            return true;
        }
    }
}
