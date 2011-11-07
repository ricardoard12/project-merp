using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.ServiceModel;
using BL;
using BL.Service;
using BL.Service.Stammdaten.User;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost shMerpService = new ServiceHost(typeof(MerpService), new Uri("net.tcp://localhost:2526/Service/"));
            ServiceHost shUserService = new ServiceHost(typeof (UserService),
                                                        new Uri("net.tcp://localhost:2527/Service/Stammdaten/User"));


            Console.Write("MerpService wird gestartet...  :D :D :D\n");
            shMerpService.Open();
            Console.Write("MerpService wurde gestartet buh buh buh\n");
            Console.Write("UserService wurde gestartet\n");
            shUserService.Open();
            Console.Write("UserService wurde gestartet\n");
            Console.Write("Drücken Sie eine Taste um zu beenden\n");
            Console.Read();
            shMerpService.Close();
            shUserService.Close();
                       
        }
    }
}
