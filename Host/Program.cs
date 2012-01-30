using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.ServiceModel;
using BL;
using BL.Service;
using BL.Service.Stammdaten.Product;
using BL.Service.Stammdaten.User;


namespace Host
{
    class Program
    {
        static void Main(string[] args) {

            Process.Start(@"C:\Projekte\ProjectMerp\Host\CertifikatDelete.bat");
            Process.Start(@"C:\Projekte\ProjectMerp\Host\CertifikatCreate.bat");


            ServiceHost MERPService = new ServiceHost(typeof(MerpService));
            
           /* MERPService.AddServiceEndpoint(&
                typeof(IMERPService),
                new NetTcpBinding(),
                "MERPService");
   */

            ServiceHost shUserService = new ServiceHost(typeof(UserService));
            ServiceHost shProductService = new ServiceHost(typeof(ProductService));


            Console.Write("MerpService wird gestartet...  :D :D :D\n");
            MERPService.Open();
            Console.Write("MerpService wurde gestartet buh buh buh\n");
            Console.Write("UserService wird gestartet\n");
            shUserService.Open();
            Console.Write("UserService wurde gestartet\n");
            Console.Write("ProductService wird gestartet\n");
            shProductService.Open();
            Console.Write("ProductService wurde gestartet\n");
            Console.Write("Drücken Sie eine Taste um zu beenden\n");
            Console.Read();
            MERPService.Close();
            shUserService.Close();
            shProductService.Close();
                       
        }
    }
}
