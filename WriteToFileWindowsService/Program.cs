using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WriteToFileWindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            if (Environment.UserInteractive)
            {
                var windowsService = new FileWriteWindowsService();
                windowsService.Start();

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

                windowsService.Stop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new FileWriteWindowsService() 
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
