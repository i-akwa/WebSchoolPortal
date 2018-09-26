using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class BulkRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void lnkdownload_Click1(object sender, EventArgs e)
        {
            string fileName = "dload.zip";// Replace Your Filename with your required filename

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.TransmitFile(Server.MapPath("~/App_Resources/Download/" + fileName));//Place "YourFolder" your server folder Here

            Response.End();
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            ImportDataFromExcel(UploadXcel.PostedFile.FileName);
        }

        public void ImportDataFromExcel(string excelFilePath)
        {
            //using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            //{
                //declare variables - edit these based on your particular situation 
                string ssqltable = "TryExcell";
                // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different 
                string myexceldataquery = "select *from [Boo$]";
                try
                {
                    //create our connection strings 
                    string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;data source=" + excelFilePath +
                    ";extended properties=" + "\"Excel 12.0; HDR=Yes; IMEX=1 \"";
                    string constr = @"Data Source=AKWA_OYO-PC;Initial Catalog=SchoolPortal;Integrated Security=True; ";
                    SqlConnection connection = new SqlConnection(constr);
                    //execute a query to erase any previous data from our destination table 
                    string sclearsql = "delete from " + ssqltable;

                    SqlCommand sqlcmd = new SqlCommand(sclearsql, connection);
                    connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    connection.Close();
                    //series of commands to bulk copy data from the excel file into our sql table 
                    OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                    OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                    oledbconn.Open();
                    OleDbDataReader dr = oledbcmd.ExecuteReader();
                    SqlBulkCopy bulkcopy = new SqlBulkCopy(constr);
                    bulkcopy.DestinationTableName = ssqltable;
                    while (dr.Read())
                    {
                        bulkcopy.WriteToServer(dr);
                    }
                    dr.Close();
                    oledbconn.Close();

                    string message ="Data Inserted";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            //}
        }




    }
}