using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FASTLANEWebApplication
{
    public class personalDetails
    {
        public string Firstname
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string Password { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
