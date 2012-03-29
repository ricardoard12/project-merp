//HBS

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Views.Stammdaten.Customer
{
    [Serializable]
    class CustomerView : ICustomerView, IDataErrorInfo
    {
        public int CusId { get; set; }
        public int? CusNumber { get; set; }
        public string CusFirstname { get; set; }
        public string CusLastname { get; set; }
        public string Email { get; set; }
        public int? CusUsrId { get; set; }
        public bool? CusIsCompany { get; set; }

        public CustomerView()
        {

        }

        public CustomerView(int cusId, int? cusNumber, string cusFirstname, string cusLastname, string cusContactname,
                            int? cusUsrId, bool? cusIsCompany)
        {
            this.CusId = cusId;
            this.CusNumber = cusNumber;
            this.CusFirstname = cusFirstname;
            this.CusLastname = cusLastname;
            this.Email = cusContactname;
            this.CusUsrId = cusUsrId;
            this.CusIsCompany = cusIsCompany;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CusId", CusId);
            info.AddValue("CusNumber", CusNumber);
            info.AddValue("CusFirstname", CusFirstname);
            info.AddValue("CusLastname", CusLastname);
            info.AddValue("Email", Email);
            info.AddValue("CusUsrId", CusUsrId);
            info.AddValue("CusIsCompany", CusIsCompany);
        }

        protected CustomerView(SerializationInfo info,
                               StreamingContext context)
        {
            CusId = (int) info.GetValue("CusId", typeof (int));
            CusNumber = (int?) info.GetValue("CusNumber", typeof (int));
            CusFirstname = (string) info.GetValue("CusFirstname", typeof (string));
            CusLastname = (string) info.GetValue("CusLastname", typeof (string));
            Email = (string) info.GetValue("Email", typeof (string));
            CusUsrId = (int?) info.GetValue("CusUsrId", typeof (int));
            CusIsCompany = (bool?) info.GetValue("CusIsCompany", typeof (bool));
        }


        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        #region Validation

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        private static readonly string[] ValidatedProperties =
            {
                "Email",
                "FirstName",
                "LastName",
            };

        private string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
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

        private string ValidateEmail()
        {
            if (IsStringMissing(this.Email))
            {
                return "Missing Email";
            }
            else if (!IsValidEmailAddress(this.Email))
            {
                return "Invalid Email";
            }
            return null;
        }

        private string ValidateFirstName()
        {
            if (IsStringMissing(this.CusFirstname))
            {
                return "Missing Firstname";
            }
            return null;
        }

        private string ValidateLastName()
        {
            if (this.CusIsCompany == true)
            {
                if (!IsStringMissing(this.CusLastname))
                    return "Company has no LastName";
            }
            else
            {
                if (IsStringMissing(this.CusLastname))
                    return "Person has LastName";
            }
            return null;
        }

        private static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        private static bool IsValidEmailAddress(string email)
        {
            if (IsStringMissing(email))
                return false;

            // This regex pattern came from: http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
            string pattern =
                @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        #endregion // Validation



    }
}
