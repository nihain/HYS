using System;
using System.Windows.Forms;
using HYS.Forms;

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
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FormAppointment());
            Application.Run(new FormLoginRegister());
        }
    }
}
