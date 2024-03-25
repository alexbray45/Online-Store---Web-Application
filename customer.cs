using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTLANEWebApplication
{
    public class customer:personalDetails
    {
        public customer(string firstname, string lastname, DateTime DateofBirth, string gender, string address)
        {
            Firstname = firstname;
            Surname = lastname;
            DateOfBirth = DateofBirth;
            Gender = gender;
            Address = address;
        }
    }
}