using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel;
using BL;
using BL.Service;
using Views.Stammdaten.Product;
using Views.Stammdaten.Supplier;
using Views.Stammdaten.User;


namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Process.Start(@"C:\Projekte\ProjectMerp\Host\CertifikatDelete.bat");
            Process.Start(@"C:\Projekte\ProjectMerp\Host\CertifikatCreate.bat");
            */
            NetTcpBinding bindingConfiguration = new NetTcpBinding(SecurityMode.Message);
            bindingConfiguration.Security.Message.ClientCredentialType = MessageCredentialType.UserName;



            ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
            metadataBehavior.HttpGetEnabled = true;
            metadataBehavior.HttpGetUrl = new Uri("http://localhost:7778/httpGet/MerpService");

            ServiceDebugBehavior serviceDebug = new ServiceDebugBehavior();
            serviceDebug.IncludeExceptionDetailInFaults = true;

            using (ServiceHost MERPService = new ServiceHost(typeof(RootService)))
            {
                // MERPService.Description.Behaviors.Add(serviceDebug);
                MERPService.Description.Behaviors.Add(metadataBehavior);
                foreach (
                    ServiceDebugBehavior behavior in
                        MERPService.Description.Behaviors.Where(s => s.GetType() == typeof(ServiceDebugBehavior)).Cast
                            <ServiceDebugBehavior>())
                {
                    behavior.IncludeExceptionDetailInFaults = true;
                }


                MERPService.Credentials.UserNameAuthentication.UserNamePasswordValidationMode =
                    UserNamePasswordValidationMode.Custom;
                MERPService.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new PasswordValidator();

                MERPService.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.None;
                MERPService.Credentials.ServiceCertificate.Certificate = GetCertificate();


                /*MERPService.AddServiceEndpoint(typeof (IMERPService), bindingConfiguration,
                                               "net.tcp://localhost:2526/Service/MerpService");*/
                MERPService.AddServiceEndpoint(typeof (IUserService), bindingConfiguration,
                                               "net.tcp://localhost:2526/Service/UserService");
                MERPService.AddServiceEndpoint(typeof (IProductService), bindingConfiguration,
                                               "net.tcp://localhost:2526/Service/ProductService");
                MERPService.AddServiceEndpoint(typeof (ISupplierService), bindingConfiguration,
                                               "net.tcp://localhost:2526/Service/SupplierService");

                Console.Write("MerpService wird gestartet...  :D :D :D\n");
                Console.WriteLine("--------------------------------Endpoints--------------------------------\n\n");
                foreach (var s in MERPService.Description.Endpoints)
                {
                    Console.WriteLine(String.Format("Endpoint Name:  {0}", s.Name));
                    Console.WriteLine(String.Format("Addresse: {0}", s.Address ));
                }
                Console.WriteLine("------------------------------------------------------------------------- \n\n");
                

                MERPService.Open();
                Console.Write("MerpService wurde gestartet buh buh buh\n");
                Console.Write("Drücken Sie eine Taste um zu beenden\n");
                Console.Read();
                MERPService.Close();
            }
        }

        private static X509Certificate2 GetCertificate()
        {

            X509Store store = new X509Store("TrustedPeople", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certificate2Collection2 = store.Certificates;
            X509Certificate2Collection certificate2Collection = store.Certificates.Find(X509FindType.FindBySubjectName,
                                                                                        "SimiPro2", false);

            return certificate2Collection[0];

            /*
            ServiceCredentials certificate2 = new ServiceCredentials();

            X509Certificate2 certificate = new X509Certificate2();
           
            certificate.Import("SimiPro2");
            certificate.
             <serviceCertificate findValue="SimiPro2"
                                x509FindType="FindBySubjectName"
                                storeLocation="CurrentUser"
                                storeName="TrustedPeople"/>
             */
        }
    }
}
