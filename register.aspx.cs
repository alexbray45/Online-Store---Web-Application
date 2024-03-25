using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace FASTLANEWebApplication
{
    public partial class register : System.Web.UI.Page
    {
        //server side
        //page events, control events and application events

        //instantiate class in global section here
        dataAccess daa = new dataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {  //very important to prevent controls reloading and resetting values already selected
                    DataSet ds = daa.GetData("SELECT * FROM USERGROUPS ORDER BY GROUPID ASC;");
                    //load dropdown
                    daa.LoadHtmlSelect(groupid, ds, "data", "GroupID", "GroupName");
                    dob.Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
                //set date formats for setting date values from code

                //here               dateregistered.Value = DateTime.Now.ToString("yyyy-MM-dd");
                //--
                password.Attributes["type"] = "password"; //set attribute password after showing - circumvent clearing when password already 
                //
            }
            catch (Exception ex)
            {
                daa.ShowMessage(ex.Message, "error");
            }
        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            try
            {
                //-----validation of data------
                String message = ValidateData();
                if (message != "")
                {
                    daa.ShowMessage(message, "warning");
                    return; 
                }

                users RegUser = new users(firstname.Value, surname.Value, gender.Value, address.Value, (email.Value).ToLower(), password.Value, cellno.Value, groupid.Value, DateTime.Parse(dob.Value));
                registration reg = new registration();
                reg.SaveToDatabase(RegUser);
            }
            catch (Exception ex)
            {
                daa.ShowMessage(ex.Message, "error");
            }
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                firstname.Value = "";
                surname.Value = "";
                gender.Value = "0";
                dob.Value = DateTime.Now.ToString("yyyy-MM-dd"); //maintain date formats
                email.Value = "";
                cellno.Value = "";
                address.Value = "";
                password.Value = "";
                groupid.Value = "0";
                lblerror.InnerText = "";
                email.Focus();

               
            }
            catch (Exception ex)
            {
                daa.ShowMessage(ex.Message, "error");
            }
        }

        private String ValidateData()
        {
            try
            {
                String message = "";
                message += (email.Value == "") ? "<br/>Please enter email address before proceeding !!" : "";
                message += (firstname.Value == "") ? "<br/>Please enter the firstname before proceeding !!" : "";
                message += (surname.Value == "") ? "<br/>Please enter the surname before proceeding !!" : "";
                message += (gender.Value == "0") ? "<br/>Please select the gender before proceeding !!" : "";
                message += (Convert.ToDateTime(dob.Value) == DateTime.Now) ? "<br/>Date of Birth cant be today !!" : "";
                message += (email.Value == "") ? "<br/>Please enter the Cell Number before proceeding !!" : "";
                message += (address.Value == "") ? "<br/>Please enter the address before proceeding !!" : "";
                message += (password.Value == "") ? "<br/>Please enter the password before proceeding !!" : "";
                message += (groupid.Value == "0") ? "<br/>Please select the user group before proceeding !!" : "";
                return message;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}