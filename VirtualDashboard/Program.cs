using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualDashboard
{
    static class Program
    {
        public static DashDisplay DashBoardDisplay;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DashBoardDisplay = new DashDisplay();
            Application.Run(DashBoardDisplay);
        }
    }
}
