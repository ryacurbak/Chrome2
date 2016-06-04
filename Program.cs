using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chrome2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread run1 = new Thread(new ThreadStart(Run));
            Thread run2 = new Thread(new ThreadStart(Run));

            run1.Start();
            run2.Start();
        }
        static void Run()
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = @"c:\Program Files (x86)\Google\Chrome\Application\run.bat";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = psi;
            p.EnableRaisingEvents = true;
            p.Start();

            while (!p.HasExited)
            {
                Thread.Sleep(100);
            }

            if (p.ExitCode != 0)
            {
                //some error occurred
            }
        }
    }
}