﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Views.Stammdaten.Supplier
{
    [Serializable]
    class SupplierView : ISupplierView, IDataErrorInfo 
    {
        public int SupId { get; set; }
        public int? SupNumber { get; set; }
        public string SupFirstname { get; set; }
        public string SupLastname { get; set; }
        public string SupContactname { get; set; }
        public int? SupUsrId { get; set; }
        public bool? SupIsCompany { get; set; }

        
        public SupplierView() {

        }


        public SupplierView(int supId, int? supNumber, string supFirstname, string supLastname, string supContactname, int? supUsrId, bool? supIsCompany)
        {
            this.SupId = supId;
            this.SupNumber = supNumber;
            this.SupFirstname = supFirstname;
            this.SupLastname = supLastname;
            this.SupContactname = supContactname;
            this.SupUsrId = supUsrId;
            this.SupIsCompany = supIsCompany;
        }

        protected SupplierView(SerializationInfo info, StreamingContext context)
        {
            this.SupId = (int)info.GetValue("SupId", typeof(int));
            this.SupNumber = (int)info.GetValue("SupId", typeof(int));
            this.SupFirstname = (string)info.GetValue("SupId", typeof(string));
            this.SupLastname = (string)info.GetValue("SupId", typeof(string));
            this.SupContactname = (string)info.GetValue("SupId", typeof(string));
            this.SupUsrId = (int)info.GetValue("SupId", typeof(int));
            this.SupIsCompany = (bool)info.GetValue("SupId", typeof(bool));
        }

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "SupFirstname":
                    error = this.ValidateSupFirstname();
                    break;

                case "SupLastname":
                    error = this.ValidateSupLastname();
                    break;

                case "SupContactname":
                    error = this.ValidateSupContactname();
                    break;

                case "SupNumber":
                    error = this.ValidateSupNumber();
                    break;

                case "SupUsrId":
                    error = this.ValidateSupUsrId();
                    break;

                case "SupIsCompany":
                    error = this.ValidateSupIsCompany();
                    break;

                default:
                    Debug.Fail("Unexpected property being validated on Customer: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateSupIsCompany()
        {
            if (IsStringMissing(Convert.ToString(SupIsCompany)))
                return "Missing Supplier type";
        
            return null;
        }

        private string ValidateSupUsrId()
        {
            if (IsStringMissing(Convert.ToString(this.SupUsrId)))
                return "Missing Contact Name";
         
            return null;
        }

        private string ValidateSupNumber()
        {
            if (IsStringMissing(Convert.ToString(this.SupNumber)))
                return "Missing Supplier Number";
       

            return null;
        }

        private string ValidateSupContactname()
        {
            if (IsStringMissing(this.SupContactname))
                return "Missing Contact Name";


            return null;
        }

        private string ValidateSupLastname()
        {
            if (IsStringMissing(this.SupLastname))
                return "Missing Last Name";
         

            return null;
        }

        private string ValidateSupFirstname()
        {
            if (IsStringMissing(this.SupFirstname))
                return "Missing First Name";
         

            return null;
        }

        static bool IsStringMissing(string value)
        {
            return
                String.IsNullOrEmpty(value) ||
                value.Trim() == String.Empty;
        }

        static readonly string[] ValidatedProperties = 
        { 
            "SupFirstname", 
            "SupLastname", 
            "SupContactname",
            "SupNumber",
            "SupUsrId",
            "SupplierType"
        };

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SupId", SupId);
            info.AddValue("SupNumber" , SupNumber);
            info.AddValue("SupFirstname", SupFirstname);
            info.AddValue("SupLastname", SupLastname);
            info.AddValue("Supcontactname", SupContactname);
            info.AddValue("supUserId", SupUsrId);
            info.AddValue("SupIsCompany", SupIsCompany);

        }
    }
}