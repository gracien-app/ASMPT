using System;
using System.Numerics;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    //Proxy class used to import procedures writen in assembler.
    //Must be initialized before using.
    public unsafe class AsmProxy
    {

        [DllImport("..\\AsmLibrary.dll")]
        private static extern float asmSphereIntersect(Vector4 first, Vector4 second, 
                                                       Vector4 three, Vector4 radius, Vector4 timeMax);

        public bool executeAsmIntersect(Ray inRay, float timeMin, ref float timeMax, Vector4 center, float radius)
        {

            float root= asmSphereIntersect(inRay.origin, inRay.direct, 
                                             center, new Vector4(radius), new Vector4(timeMax));

            if(root >= 0.0)
            {
                 timeMax = root;
                 return true;
            }
            else
            {
                return false;
            }
        }
    }
}
