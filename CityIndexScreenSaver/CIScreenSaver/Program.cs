using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CIScreenSaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                if (args[0].ToLower().Trim().Substring(0, 2) == "/c")
                {
                    // TODO
                }
                else if (args[0].ToLower() == "/s")
                {
                    for (int activeScreen = Screen.AllScreens.GetLowerBound(0); activeScreen <= Screen.AllScreens.GetUpperBound(0); activeScreen++)
                    {
                        System.Windows.Forms.Application.Run(new FormScreenSaver(activeScreen));
                    }
                }
            }
            else
            {
                for (int activeScreen = Screen.AllScreens.GetLowerBound(0); activeScreen <= Screen.AllScreens.GetUpperBound(0); activeScreen++)
                {
                    System.Windows.Forms.Application.Run(new FormScreenSaver(activeScreen));
                }
            }
        }
    }
}
