using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PostalDepHrSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Kill any existing instance before starting new one
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length > 1)
            {
                // Kill the old instance
                foreach (Process p in processes)
                {
                    if (p.Id != Process.GetCurrentProcess().Id)
                    {
                        p.Kill();
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}