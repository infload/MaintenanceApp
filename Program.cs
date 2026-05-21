using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Forms;

namespace MaintenanceApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Database.Initialize();
            Application.Run(new MainForm());
        }
    }
}