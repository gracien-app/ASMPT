using System;
using System.Numerics;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    public unsafe class AsmProxy
    {

        [DllImport("..\\AsmLibrary.dll")]
        private static extern float asmSphereIntersect(Vector4 first, Vector4 second, 
                                                       Vector4 three, Vector4 radius);

        public bool executeAsmIntersect(Ray inRay, float timeMin, ref float timeMax, Vector4 center, float radius)
        {
            //Vector4 origin = new Vector4(0.0f, 1.0f, 1.0f, 0.0f);
            //Vector4 direction = new Vector4(0.5f, 0.5f, 0.5f, 0.0f);
            //Vector4 fcenter = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
            //Vector4 fradius = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);


            //Vector4 originC = origin - fcenter;
            //float a = direction.LengthSquared();
            //float b = Vector4.Dot(direction, originC);
            //////float b = executeDotProduct(inRay.direct, originC);
            //float c = originC.LengthSquared() - (fradius.X * fradius.X);

            Vector4 originC = inRay.origin - center;
            float a = inRay.direct.LengthSquared();
            float b = Vector4.Dot(inRay.direct, originC);
            // float c = originC.LengthSquared() - (radius * radius);

            float delta = asmSphereIntersect(inRay.origin, inRay.direct, 
                                             center, new Vector4(radius));

            //float delta = asmSphereIntersect(origin, direction, fcenter, fradius);

            //float delta = (b * b) - (4 * a * c);
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
