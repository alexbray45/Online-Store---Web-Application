using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTLANEWebApplication
{
    public class loginClass
    {
        public loginClass(string username, string password, DateTime dateandtime)
        {
            Username = username;
            Password = password;
            DateandTime = dateandtime;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DateandTime { get; set; }

    }
}