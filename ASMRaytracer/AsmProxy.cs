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
        private static extern double asmDotProduct(Vector4 first, Vector4 second);


        public double executeAsmAddTwoDoubles(double a, double b)
        {
            return asmAddTwoDoublesTwo(a, b);
        }

        public float executeDotProduct(Vector3 first, Vector3 second)
        {
            Vector4 firstt = new Vector4(first, 0.0f);
            Vector4 secondt = new Vector4(second, 0.0f);
            return (float)asmDotProduct(firstt, secondt);
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
