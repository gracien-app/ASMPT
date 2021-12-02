using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    public unsafe class AsmProxy
    {
        //Dll import pattern.
        [DllImport("..\\AsmLibrary.dll")]
        private static extern double asmAddTwoDoubles(double a, double b);


        public double executeAsmAddTwoDoubles(double a, double b)
        {
            return asmAddTwoDoubles(a, b);
        }

        //Should be translated into asm.
        public bool executeAsmIntersect(Ray inRay, float timeMin, ref float timeMax)
        {
            Vector3 originC = inRay.origin - this.center;
            float a = inRay.direct.LengthSquared();
            float b = Vector3.Dot(inRay.direct, originC);
            float c = (originC).LengthSquared() - (this.radius * this.radius);

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
