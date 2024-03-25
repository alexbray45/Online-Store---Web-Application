using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FASTLANEWebApplication
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut(); //signout of UserSessionCookie
            Session.Clear(); //Clear all session values | force logout
            Response.Redirect("index.aspx");
        }
    }
}