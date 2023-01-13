using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DiaryNotepad
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Process.GetProcesses().Where(x => Process.GetCurrentProcess().ProcessName.Equals(x.ProcessName)).Count() > 1)
            {
                MessageBox.Show("Already executed.");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
