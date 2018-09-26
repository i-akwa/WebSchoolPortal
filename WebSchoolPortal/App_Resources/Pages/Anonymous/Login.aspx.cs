using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text;
using CodePortal.Project.DbConnection;
using System.Configuration;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace WebSchoolPortal.App_Resources.Pages.Anonymous
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Master.HeaderLabel = "PLEASE LOGIN YOUR CRIDENTIALS";
        }

        protected void Login1_LoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {
            try
            {
                if (Login1.UserName.Contains("@") && Membership.GetUser(Login1.UserName) == null)
                {
                    string Username = Membership.GetUserNameByEmail(Login1.UserName);
                    if (Username == null)
                        return;
                    if (Membership.ValidateUser(Username, Login1.Password) == true)
                    {
                        FormsAuthentication.SetAuthCookie(Username, false);
                      //  FormsAuthentication.RedirectFromLoginPage(Username, true);
                        e.Cancel = true;
                    }
                }
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

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {
            try
            {
                string TESchoolId = "";
                string userName = Login1.UserName;
                Session["UserName"] = userName;

                string SchoolId = "";
                MembershipUser loggedInUser = Membership.GetUser(userName);
                string _userId = loggedInUser.ProviderUserKey.ToString();
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select SchoolId from SchoolAdminRegistration Where UserId=@UserId", connection);
                    SelectCommand.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = _userId;
                    connection.Open();
                    SqlDataReader read = SelectCommand.ExecuteReader();
                    if (read.Read())
                    {
                        SchoolId = read["SchoolId"].ToString();
                    }
                    connection.Close();

                    if (Membership.ValidateUser(Login1.UserName, Login1.Password))
                    {
                        if (Roles.IsUserInRole(Login1.UserName, "SchoolAdmin"))
                        {
                            Session["SchoolId"] = SchoolId;
                            Response.Cookies["SchoolId"].Value = SchoolId;
                            Response.Redirect("~/App_Resources/Pages/School_Administrator/Schooladmindashboard.aspx");
                        }
                        else if (Roles.IsUserInRole(Login1.UserName, "admin"))
                        {
                            Response.Cookies["SchoolId"].Value = SchoolId;
                            Session["SchoolId"] = SchoolId;
                            Response.Redirect("~/App_Resources/Pages/App_Administrator/ManageSchoolDashboard.aspx");
                        }
                        else if (Roles.IsUserInRole(Login1.UserName, "Student"))
                        {
                            Response.Redirect("~/App_Resources/Pages/Student/studentdashboard.aspx");
                        }
                        else if (Roles.IsUserInRole(Login1.UserName, "Teacher"))
                        {
                            Session["TESchoolId"] = getSchoolId();
                            Response.Cookies["SchoolId"].Value = getSchoolId();
                            Response.Cookies["TESchoolId"].Value = getSchoolId();
                            Response.Redirect("~/App_Resources/Pages/Teachers/Teachersdashboard.aspx");
                        }
                    }
                }
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

        public string getSchoolId()
        {
            string TESchoolId = "";
            string username = Login1.UserName;
            string userName = Session["username"].ToString();
            
            MembershipUser loggedInUser = Membership.GetUser(username);
            string Userid = loggedInUser.ProviderUserKey.ToString();
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand SelectCommand = new SqlCommand("Select SchoolId from TeacherTab Where UserId=@Uid", connection);
                SelectCommand.Parameters.AddWithValue("@Uid", SqlDbType.NVarChar).Value = Userid;
                connection.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    TESchoolId = read["SchoolId"].ToString();
                    return TESchoolId;
                }
                connection.Close();

                return TESchoolId;
            }
        }

        protected void SignIn(object sender, EventArgs e)
        {
            try { }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function/(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            ErrorLabel.Text = "Username or Password incorect";
        }

    }
}
