using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WpfApplication1.Model.Stammdaten {
    public class CustomerModel : IDataErrorInfo {
        #region Creation 
        public static CustomerModel CreateNewCustomer() {
            return new CustomerModel();
        }

        public static CustomerModel CreateCustomer(
            double totalSales,
            string firstName,
            string lastName,
            bool isCompany,
            string email) {
            return new CustomerModel {
                TotalSales = totalSales,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };
        }

        protected CustomerModel() {
        }

        #endregion Creation
        #region properties

        public string Email { get; set; }
        public string FirstName { get; set; }
        public bool IsCompany { get; set; }
        public string LastName { get; set; }
        public double TotalSales { get; set; }

        #endregion properties

        string IDataErrorInfo.Error{get { return null; } }

        string IDataErrorInfo.this[string propertyName] {
            get { return this.GetValidationError(propertyName); }
        }

        #region Validation

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid {
            get {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "Email", 
            "FirstName", 
            "LastName",
        };

        string GetValidationError(string propertyName) {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName) {
                case "Email":
                    error = this.ValidateEmail();
                    break;

                case "FirstName":
                    error = this.ValidateFirstName();
                    break;

                case "LastName":
                    error = this.ValidateLastName();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Customer: " + propertyName);
                    break;
            }

            return error;
        }

        string ValidateEmail() {
            if (IsStringMissing(this.Email)) {
                return "Missing Email";
            } else if (!IsValidEmailAddress(this.Email)) {
                return"Invalid Email";
            }
            return null;
        }

        string ValidateFirstName() {
            if (IsStringMissing(this.FirstName)) {
                return "Missing Firstname";
            }
            return null;
        }

        string ValidateLastName() {
            if (this.IsCompany) {
                if (!IsStringMissing(this.LastName))
                    return "Company has no LastName";
            } else {
                if (IsStringMissing(this.LastName))
                    return "Person has LastName";
            }
            return null;
        }

        static bool IsStringMissing(string value) {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static bool IsValidEmailAddress(string email) {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        #endregion // Validation

    }
}
