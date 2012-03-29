using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Resources;
using System.Xml;
using System.Xml.Linq;
using FrontEnd.Model.Stammdaten;

namespace FrontEnd.DataAccess.Stammdaten.Customer {
    public class CustomerRepositoryOld {
        #region Fields

        readonly List<CustomerModel> _customers;

        #endregion

        #region Constructor

        public CustomerRepositoryOld(string customerDataFile) {
            _customers = LoadCustomers(customerDataFile);
        }

        #endregion constructors

        #region Public Interface
        //tritt auf wenn ein Customer in der Repo hinzugefügt wird
        public event EventHandler<CustomerAddedEventArgs> CustomerAdded;

        public void AddCustomer(CustomerModel customerModel) {
            if (customerModel == null)
                throw new ArgumentNullException("customerModel");
            if (!_customers.Contains(customerModel)) {
                _customers.Add(customerModel);

                if (this.CustomerAdded != null)
                    this.CustomerAdded(this, new CustomerAddedEventArgs(customerModel));
            }
        }

        public bool ContainsCustomer(CustomerModel customerModel) {
            if (customerModel == null)
                throw new ArgumentNullException("customerModel");
            return _customers.Contains(customerModel);
        }

        public List<CustomerModel> GetCustomers() {
            return new List<CustomerModel>(_customers);
        }

        static List<CustomerModel> LoadCustomers(string customerDataFile) {
            // In a real application, the data would come from an external source,
            // but for this demo let's keep things simple and use a resource file.
            using (Stream stream = GetResourceStream(customerDataFile))
            using (XmlReader xmlRdr = new XmlTextReader(stream))
                return
                    (from customerElem in XDocument.Load(xmlRdr).Element("customers").Elements("customer")
                     select CustomerModel.CreateCustomer(
                        (double)customerElem.Attribute("totalSales"),
                        (string)customerElem.Attribute("firstName"),
                        (string)customerElem.Attribute("lastName"),
                        (bool)customerElem.Attribute("isCompany"),
                        (string)customerElem.Attribute("email")
                         )).ToList();
        }

        static Stream GetResourceStream(string resourceFile) {
            Uri uri = new Uri(resourceFile, UriKind.RelativeOrAbsolute);

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null || info.Stream == null)
                throw new ApplicationException("Missing resource file: " + resourceFile);

            return info.Stream;
        }

        #endregion // Private Helpers
    }


}
