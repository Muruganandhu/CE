using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChitEngine.Models.Auth
{
    public class LoginModel
    {
        public string uname { get; set; }
        public string pword { get; set; }
        public bool isCustomer { get; set; }
    }
}