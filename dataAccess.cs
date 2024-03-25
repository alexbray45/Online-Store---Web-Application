using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FASTLANEWebApplication
{
    public class dataAccess
    {
        //this will establish connection to the database
        private SqlConnection GetConnection()
        {
            String constring = System.Configuration.ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            return new SqlConnection(constring);
        }

        //Method to get data
        public DataSet GetData(String sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "data");
                    return ds;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //method for saving, updating and deleting
        public int ExecuteCommand(String sql)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    //execute sql to insert, update or delete
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteCommand(String sql, Object[] arrparams)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                //create command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //add parameters
                if (arrparams != null)
                {
                    for (int k = 0; k < arrparams.Length; k++)
                    {
                        String param = String.Format("@{0}", k);                   //new param char setting
                        var reg = new System.Text.RegularExpressions.Regex(@"\?"); //param char specification
                        sql = reg.Replace(sql, param, 1);                          //replace param character, 1 char per round
                        cmd.Parameters.AddWithValue(param, arrparams[k]);          //add param and value
                    }
                    //assign updated command text
                    cmd.CommandText = sql;
                }
                //execute
                int rows = cmd.ExecuteNonQuery();
                return rows; //return
            }
        }

        //method to load htmlselect from database
        public void LoadHtmlSelect(System.Web.UI.HtmlControls.HtmlSelect ctlselect, DataSet ds, String strTableName = "", String ValueColumnName = "")
        {
            try
            {
                strTableName = (strTableName == "") ? ds.Tables[0].TableName : strTableName;
                ValueColumnName = (ValueColumnName == "") ? ds.Tables[strTableName].Columns[1].ColumnName : ValueColumnName;
                DataTable dt = ds.Tables[0].Copy();
                dt.Rows.Add(0, "Select...");
                dt = dt.AsEnumerable().OrderBy(r => r[0]).ThenBy(x => x[1]).CopyToDataTable(); //orders by first and second column
                //dt.DefaultView.Sort= dt.Columns[0].ColumnName + " ASC"; //order by first column
                ctlselect.DataSource = dt;
                //          ctlselect.DataValueField = dt.Columns[KeyColumnName].ColumnName;
                ctlselect.DataTextField = dt.Columns[ValueColumnName].ColumnName;
                ctlselect.DataBind();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void LoadHtmlSelect(System.Web.UI.HtmlControls.HtmlSelect ctlselect, DataSet ds, String strTableName = "", String KeyColumnName = "", String ValueColumnName = "")
        {
            try
            {
                strTableName = (strTableName == "") ? ds.Tables[0].TableName : strTableName;
                KeyColumnName = (KeyColumnName == "") ? ds.Tables[strTableName].Columns[0].ColumnName : KeyColumnName;
                ValueColumnName = (ValueColumnName == "") ? ds.Tables[strTableName].Columns[1].ColumnName : ValueColumnName;
                DataTable dt = ds.Tables[0].Copy();
                dt.Rows.Add(0, "Select...");
                dt = dt.AsEnumerable().OrderBy(r => r[0]).ThenBy(x => x[1]).CopyToDataTable(); //orders by first and second column
                //dt.DefaultView.Sort= dt.Columns[0].ColumnName + " ASC"; //order by first column
                ctlselect.DataSource = dt;
                ctlselect.DataValueField = dt.Columns[KeyColumnName].ColumnName;
                ctlselect.DataTextField = dt.Columns[ValueColumnName].ColumnName;
                ctlselect.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //create a label called lblerror to display error messages on each page
        public void ShowMessage(String message, String InfoErrorWarningCode = "")
        {
            try
            {
                String code = InfoErrorWarningCode.Trim().ToLower().Substring(0, 1); //take first 1 letter only
                var DictErrorCodes = new Dictionary<String, String>
                {
                    ["i"] = "info",
                    ["e"] = "error",
                    ["w"] = "warning"
                };
                String classcode = DictErrorCodes[code] ?? "warning"; //search from dictionary, if not found assign WARNING CLASS
                var page = HttpContext.Current.Handler as System.Web.UI.Page;
                var lblerror = page.FindControl("lblerror") as System.Web.UI.HtmlControls.HtmlGenericControl;
                lblerror = (lblerror) ?? page.Master.FindControl("ContentPlaceHolder1").FindControl("lblerror") as System.Web.UI.HtmlControls.HtmlGenericControl; //if not found check in master page
                lblerror.Attributes["class"] = classcode;
                lblerror.InnerHtml = message;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}