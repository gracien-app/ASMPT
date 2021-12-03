using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AplClient
{
    public class PerformanceProfailer
    {
        public Stopwatch stopwatch { get; set; }

        public bool isRunning { get; set; }
        
        public String ReturnSeconds()
        {
            TimeSpan t = TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds);

            return string.Format("{0:D0}m:{1:D1}s:{2:D2}ms",
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
        }
        public void StartTimeMeasurment()
        {
            isRunning = true;
            stopwatch = Stopwatch.StartNew();
        }

        public void StopTimeMeasurement()
        {
            stopwatch.Stop();
            isRunning = false;
        }

    }
}
