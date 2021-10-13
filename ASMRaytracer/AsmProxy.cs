using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace AplClient
{
    public unsafe class AsmProxy
    {

        [DllImport("..\\AsmLibrary.dll")]
        private static extern double asmAddTwoDoubles(double a, double b);

        public double executeAsmAddTwoDoubles(double a, double b)
        {
            return asmAddTwoDoubles(a, b);
        }
    }
}
