using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.Student
{
    public partial class studentdashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand cmd = new SqlCommand("Select TeacherName, subjectTable.SubjectName from Subjectteacher join subjectTable on subjectTable.SubjectID=Subjectteacher.SubjectID where Class=(Select PresentClass from StudentRegTab  where StudentRollNumber=@StudentRollNumber )", connection);

                cmd.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = GetStudentId();
                connection.Open();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                Da.Fill(DT);
                SSCT.DataSource = DT;
                SSCT.DataBind();
            }
        }

        private String GetStudentId()
        {
                string StudentId = "";
               /// string userName = Session["UserName"].ToString();
                MembershipUser loggedInUser = Membership.GetUser();
                string uId = loggedInUser.ProviderUserKey.ToString();
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {

                    SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber from StudentRegTab Where UserId=@uId", connection);
                    SelectCommand.Parameters.AddWithValue("@uId", SqlDbType.NVarChar).Value = uId;
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

        protected void SSCT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SSCT.PageIndex = e.NewPageIndex;
            SSCT.DataBind();
        }

    }
}