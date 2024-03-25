using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FASTLANEWebApplication
{
    public partial class login : System.Web.UI.Page
    {
        dataAccess da = new dataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string validatethis = Validate();
            if (validatethis == "")
            {
                //creating a logging object that will hold input email, password and the current time
                loginClass logthis = new loginClass ((email.Value).ToLower(), password.Value, DateTime.Now);

                //re object below used to accvess class Registration's info
                registration reg = new registration();//create an object of registration class and use it to access the ValidateLogin method
                reg.ValidateLogin(logthis);
            }
            else
            {
                da.ShowMessage(validatethis, "i");
            }

        }
        private String Validate()
        {
            string message = "";
            message += (email.Value == "") ? "<br/>Please enter email address before proceeding !!" : "";
            message += (password.Value == "") ? "<br/>Please enter the firstname before proceeding !!" : "";
            return message;
        }

        protected void createaccount_Click(object sender, EventArgs e)
        {

            Response.Redirect("register.aspx");
        }
    }
}