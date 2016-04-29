using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;

namespace SBOAddonProject1
{
    public class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    oApp = new Application(args[0]);
                }

                AppStart appStart = new AppStart();
                appStart.Start(oApp);

                oApp.Run();
            }
            catch (Exception ex)
            {


                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
