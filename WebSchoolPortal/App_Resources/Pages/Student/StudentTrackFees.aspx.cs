using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Text;

namespace WebSchoolPortal.App_Resources.Pages.Student
{
    public partial class StudentTrackFees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand newCom = new SqlCommand("GetPayment", connection) { CommandType = CommandType.StoredProcedure };
                    newCom.Parameters.AddWithValue("@studentRollnum", SqlDbType.NVarChar).Value = GetStudentId();
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(newCom);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    TrackFees.DataSource = dt;
                    TrackFees.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
            }
        }

        private String GetStudentId()
        {
            string StudentId = "";
            string userName = Session["UserName"].ToString();
            MembershipUser loggedInUser = Membership.GetUser(userName);
            string mail = loggedInUser.Email;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                    SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber from StudentRegTab Where EmailAdress=@EmailAdress", connection);
                    SelectCommand.Parameters.AddWithValue("@EmailAdress", SqlDbType.NVarChar).Value = mail;
                    connection.Open();
                    SqlDataReader read = SelectCommand.ExecuteReader();
                    while (read.Read())
                    {
                        StudentId = read["StudentRollNumber"].ToString();
                    }
                    connection.Close();
                    Session["StudentRollNumber"] = StudentId;
                    return StudentId;
            }
        }

        protected void TrackFees_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            TrackFees.PageIndex = e.NewPageIndex;
            TrackFees.DataBind();
        }
    }
}