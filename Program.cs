using System;
using System.Windows.Forms;

namespace HYS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the database connections

            Application.Run(new FormLoginRegister());
        }
    }
}
