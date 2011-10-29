using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using BL;
using BL.Service;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MERPService));
            Console.Write("Host wird gestartet...\n");   
            sh.Open();
            Console.Write("Host wurde gestartet\n");
            Console.Write("Drücken Sie eine Taste um zu beenden\n");
            Console.Read();
            sh.Close();
                       
        }
    }
}
