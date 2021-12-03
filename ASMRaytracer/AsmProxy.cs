using System;
using System.Numerics;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    public unsafe class AsmProxy
    {
        
        [DllImport("..\\AsmLibrary.dll")]
        private static extern float dotProduct(Vector4 first, Vector4 second);


        public float executeDotProduct(Vector3 first, Vector3 second)
        {
            //Vector4 test1 = new Vector4(1.14214f, 2.0f, 43.0f, 0.0f);
            //Vector4 test2 = new Vector4(0.02221f, 2.0f, 3.0f, 0.0f);
            
            Vector4 firstt = new Vector4(first, 0.0f);
            Vector4 secondt = new Vector4(second, 0.0f);
            float calcDot = dotProduct(firstt, secondt);
            //float calcDotVector = Vector4.Dot(test1, test2);
            return calcDot;
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

                root = (-b - deltaSqrt) / a;
                if (root > timeMax || root < timeMin)
                {
                    root = (-b + deltaSqrt) / a;
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
