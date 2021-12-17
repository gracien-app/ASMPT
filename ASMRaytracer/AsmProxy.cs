using System;
using System.Numerics;

using System.Runtime.InteropServices;
using Renderer;

namespace AplClient
{
    public unsafe class AsmProxy
    {

        // Import DLL dynamically during runtime.
        [DllImport("..\\AsmLibrary.dll")]
        private static extern float asmSphereIntersect(Vector4 first, Vector4 second, 
                                                       Vector4 three, Vector4 radius, Vector4 timeMax);

        public bool executeAsmIntersect(Ray inRay, float timeMin, ref float timeMax, Vector4 center, float radius)
        {

            // Find root using ASM procedure, returns value >=0 if found.
            float root= asmSphereIntersect(inRay.origin, inRay.direct, 
                                             center, new Vector4(radius), new Vector4(timeMax));

            if(root >= 0.0)
            {
                // Associate time max with new smallest root. 
                // This association makes next intersection to have a reduced time range
                // We are looking only for closest possible future intersections. 
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
