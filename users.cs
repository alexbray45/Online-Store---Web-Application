using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTLANEWebApplication
{
    public class users:personalDetails
    {
        public users(string firstname, string lastname, string gender, string address, string email, string password, string cellno, string groupid, DateTime DateofBirth)
        {
            Firstname = firstname;
            Surname = lastname;
            Address = address;
            Email = email;
            Password = password;
            CellNumber = cellno;
            Gender = gender;
            DateOfBirth = DateofBirth;
            GroupID = groupid;

        }
        public string GroupID { get; set; }
    }
 
}