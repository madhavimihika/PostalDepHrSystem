using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PostalDepHrSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Prevent multiple instances
            string processName = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("Application is already running!\nPlease close the existing instance first.",
                              "Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}