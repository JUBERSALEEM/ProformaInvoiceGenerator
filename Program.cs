using System;
using System.Windows.Forms;

namespace ProGlassAutomation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // MainForm को स्टार्टअप फॉर्म के रूप में सेट किया गया है
            Application.Run(new MainForm());
        }
    }
}
