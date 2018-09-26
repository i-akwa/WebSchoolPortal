using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CodePortal.Project.School_Admin;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.Security;
using System.Data.SqlClient;
using CodePortal.Project.DbConnection;
using System.Data;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class SubjectManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();
                SchoolAdminControl.DisplaySubject(Request.Cookies["SchoolId"].Value.ToString(), SubjectGrid);
                Master.HeaderLabel = "Insert New Subject";
            }
        }

        

        protected void RegSubject_Click(object sender, EventArgs e)
        {
            
            int rows = SchoolAdminControl.RegSubject(SchoolId.Text, SubjectName.Text);
            if ( rows > 0)
            {
                string message = "New Subject Added Successfully";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                SubjectName.Text = "";
            }
            else if (rows < 1)
            {
                string message = "Subject already inserted: Contact admin if this persist";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
            SchoolAdminControl.DisplaySubject(SchoolId.Text, SubjectGrid);
        }

        protected void SubjectGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                int getId = Convert.ToInt32(e.CommandArgument);
                string comName = e.CommandName;

                if (comName.Equals("Del"))
                {
                    SqlCommand delete = new SqlCommand("delete subjectTable where SubjectID=@subjectId", connect);
                    delete.Parameters.AddWithValue("@subjectId", SqlDbType.Int).Value = getId;
                    try
                    {
                        connect.Open();
                        int i=delete.ExecuteNonQuery();
                        connect.Close();
                        if(i>0)
                        {
                            string message = "Subject Deleted.";
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                            SchoolAdminControl.DisplaySubject(Request.Cookies["SchoolId"].Value.ToString(), SubjectGrid);
                        }
                        
                    }
                    catch(SqlException SqlErrorCollection)
                    {
                        string message = "data must have been bound to this subject. Please Visit developer for possible alternative";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        SchoolAdminControl.DisplaySubject(Request.Cookies["SchoolId"].Value.ToString(), SubjectGrid);
                    }
                    catch (Exception ex)
                    {
                        string message = "Error Deleting.";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        SchoolAdminControl.DisplaySubject(Request.Cookies["SchoolId"].Value.ToString(), SubjectGrid);
                    }

                }

            }
        }
    }
}