using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace FASTLANEWebApplication
{
    public class registration
    {
        dataAccess daa = new dataAccess();

        public void SaveToDatabase(users RegUser)
        {
            try
            {
                //get users age based on the birth date they input

                DateTime nowdate = DateTime.Now;
                DateTime dateinput = RegUser.DateOfBirth;
                TimeSpan age = nowdate - dateinput;
                string diff2 = age.ToString("%d");//convert the time you found into a single digit by turning it into a string
                int intdiff = int.Parse(diff2);//convert number of days from string format to be able to do math on it
                int actualage = intdiff / 365;

                if (actualage >= 15)
                {
                    string sql = @"INSERT INTO Users (FIRSTNAME, SURNAME, GENDER, DateOfBirth, EMAIL,PASSWORD, PHONENUMBER, PHYSICALADDRESS,GROUPID, DATEREGISTERED,FLAG) VALUES (?,?,?,?,?,?,?,?,?,GetDate(),'Active')";
                    Object[] values = { RegUser.Firstname, RegUser.Surname, RegUser.Gender, (RegUser.DateOfBirth), RegUser.Email, RegUser.Password, RegUser.CellNumber, RegUser.Address, RegUser.GroupID };

                    int rows = daa.ExecuteCommand(sql, values);

                    //check success
                    if (rows > 0)
                    {
                        daa.ShowMessage("Account Has Been Created successful.", "info");
                    }
                    else
                    {
                        daa.ShowMessage("User registration Has Failed, Please Try Again !!", "warning");
                    }
                }
                else
                {
                    daa.ShowMessage(" Must be 15 years of age or above!", "error");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    daa.ShowMessage("Email Already in Use! Please try again", "error");

                }
                else if (ex.Number == 547)
                {
                    daa.ShowMessage("Invalid Phone Number, Please Try Again!", "error");
                }
                else
                {
                    daa.ShowMessage(ex.Number + " " + ex.Message, "error");
                }
            }

            catch (Exception exx)
            {
                daa.ShowMessage(exx.Message, "error");
            }
        }


        public void ValidateLogin(loginClass log)
        {
            try
            {

                DataSet dss = daa.GetData($"select * from Users where email ='{log.Username}' AND password ='{log.Password}'");

                DataSet dss2 = daa.GetData($"select * from Users where email ='{log.Username}' AND password ='{log.Password}' AND flag ='Deleted'");


                if (dss.Tables[0].Rows.Count > 0 && dss2.Tables[0].Rows.Count == 0)
                {
                    //determine user group
                    string usergroup = (((int)dss.Tables[0].Rows[0]["groupid"]) == 1) ? "admin" : "customer";
                    string firstname = dss.Tables[0].Rows[0]["firstname"].ToString();
                    string surname = dss.Tables[0].Rows[0]["surname"].ToString();
                    string title = (dss.Tables[0].Rows[0]["gender"].ToString().ToUpper() == "F") ? "Ms. " : "Mr. ";
                    string fullname = $"{title} {firstname} {surname} - {usergroup.ToUpper()}";
                    //then login valid so log them in and save log in history to text file
                    daa.ShowMessage("Login Successful!:)", "info");

                    //store current user and group in session  object
                    var page = HttpContext.Current.Handler as System.Web.UI.Page;

                    page.Session.Add("email", log.Username);//
                    page.Session.Add("usergroup", usergroup);//
                    page.Session.Add("fullname", fullname);//

                    page.Response.Redirect("index.aspx");
                }
                else
                {
                    daa.ShowMessage("Login has failed, Check your Username or Password!", "error");
                }
            }

            catch (Exception e)
            {
                daa.ShowMessage(e.Message, "error");
            }

        }
    }
}