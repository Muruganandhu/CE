using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChitEngine.Models.Shared
{
    public class CustomerModel
    {
        public string CustomerName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string _firstName;
        public string FullName
        {
            get
            {
                return string.Format("{0}{1}", FirstName, LastName);
            }
            set
            {
                this._firstName = string.Format("{0}{1}", FirstName, LastName);
            }
            
        }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string SecondaryEmail { get; set; }
        public string ConsumerType { get; set; }
        public string AlternatePhNo { get; set; }
        public String Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Pincode { get; set; }
        public String PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentCountry { get; set; }
        public decimal PermanentPincode { get; set; }
        public Status UserStatus { get; set; }
        public bool IsAdmin { get; set; }
        public String Password { get; set; }
    }
}