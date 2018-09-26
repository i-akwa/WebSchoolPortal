using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.Teachers;
using System.Text;
using System.Data.SqlClient;
using CodePortal.Project.DbConnection;
using System.Data;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class TeachersRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GenTeacherId();
                if (!IsPostBack)
                {

                    Master.HeaderLabel = "Register Teacher";
                    SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();

                    using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
                    {
                        SqlCommand command = new SqlCommand("GetNation", connect) { CommandType = CommandType.StoredProcedure };
                        SqlCommand Getsub = new SqlCommand("GetSubjects", connect) { CommandType = CommandType.StoredProcedure };

                        Getsub.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();

                        connect.Open();
                        /**Binding To Subject DropDown List**/
                        Subject.Items.Add(new ListItem("-Select Subject", ""));
                        Subject.AppendDataBoundItems = true;
                        SqlDataReader read = Getsub.ExecuteReader();
                        Subject.DataSource = read;
                        Subject.DataTextField = "SubjectName";
                        Subject.DataValueField = "SubjectID";
                        Subject.DataBind();
                        read.Close();


                        /**Binding to Nation DropDown List**/
                        Nationality.Items.Add(new ListItem("-Select Country", ""));
                        Nationality.AppendDataBoundItems = true;
                        SqlDataReader rd = command.ExecuteReader();
                        Nationality.DataSource = rd;
                        Nationality.DataTextField = "COUNTRYS";
                        Nationality.DataValueField = "CountryID";
                        Nationality.DataBind();
                        connect.Close();

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

        private string GenTeacherId()
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {

                SqlCommand selectcom = new SqlCommand("FormTeacherId", connect) { CommandType = CommandType.StoredProcedure };
                connect.Open();
                int tcId = 0;
                SqlDataReader google = selectcom.ExecuteReader();
                string holdId = "";


                if (google.Read())
                {
                    tcId = Convert.ToInt32(google["RollId"].ToString());
                    tcId += 1;

                    TeacherId.Text = "A488-" + tcId.ToString() + "-TEC";
                    holdId = "A488-" + tcId.ToString();
                    return holdId;

                }
                else if (!google.Read())
                {
                    tcId = 0;
                    tcId += 1;

                    TeacherId.Text = "A488-" + tcId.ToString() + "-TEC";
                    holdId = "A488-" + tcId.ToString();
                    return holdId;

                }
                return holdId;
            }
        }

        protected void Nationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                State.Items.Clear();
                State.Items.Add(new ListItem("-SELECT State-", ""));
                State.AppendDataBoundItems = true;

                SqlCommand command = new SqlCommand("GetState", connect) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = Convert.ToInt32(Nationality.SelectedValue);
                try
                {
                    connect.Open();
                    SqlDataReader read = command.ExecuteReader();
                    State.DataSource = read;
                    State.DataTextField = "state";
                    State.DataValueField = "stateID";
                    State.DataBind();
                    connect.Close();
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

        protected void State_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                LGA.Items.Clear();
                LGA.Items.Add(new ListItem("-SELECT L.G.A-", ""));
                LGA.AppendDataBoundItems = true;

                SqlCommand command = new SqlCommand("GetLGA", connect) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@stateID", SqlDbType.Int).Value = Convert.ToInt32(State.SelectedValue);
                try
                {
                    connect.Open();
                    SqlDataReader read = command.ExecuteReader();
                    LGA.DataSource = read;
                    LGA.DataTextField = "LGA";
                    LGA.DataValueField = "LGAID";
                    LGA.DataBind();
                    connect.Close();
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

        protected void CreateStudent_Click(object sender, EventArgs e)
        {
            try
            {
                string cTeacher=CreateTeacher();
                MembershipUser newUser = Membership.GetUser(UserName.Text);
                Guid UserId = (Guid)newUser.ProviderUserKey;
                int created = 0;
                if(cTeacher== "Teachers' account was successfully created!")
                {
                    created = TeacherInformationControl.TeacherRegistration(UserId, TeacherId.Text, FName.Text, MName.Text, LName.Text, classTeacher.Text, MobilePIN.Text, Address.Text, Convert.ToDateTime(DOB.Text), Convert.ToInt32(LGA.SelectedValue), Email.Text, Convert.ToInt32(Subject.SelectedValue), SchoolId.Text, Convert.ToDateTime(RegDate.Text));

                    if (created >0)
                    {
                        string newRole = "Teacher";
                        if(!Roles.RoleExists(newRole))
                        {
                            Roles.CreateRole(newRole);
                            Roles.AddUserToRole(UserName.Text, newRole);
                            string message = cTeacher + " First If";
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        }
                        else
                        {
                            Roles.AddUserToRole(UserName.Text, newRole);
                            string message = cTeacher + " First If";
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
                    else if(created == 0)
                    {
                        if (Membership.GetUser(UserName.Text)!=null)
                        {
                            Membership.DeleteUser(UserName.Text);
                            string message =  "There was a problem while creating User" + " inner if";
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
                else
                {
                    string message = cTeacher;
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
            catch (Exception ex)
            {
                //Response.Write(ex.Message.ToString());
                string message = "Error during registration. Please retry";
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

        public string CreateTeacher()
        {
            MembershipCreateStatus createStatus;
            MembershipUser createNewUser = Membership.CreateUser(UserName.Text, Password.Text, Email.Text, Question.Text, Answer.Text, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    CreateAccountResults.Text = "Teachers' account was successfully created!";
                    break;

                case MembershipCreateStatus.DuplicateUserName:
                    CreateAccountResults.Text = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.InvalidEmail:
                    CreateAccountResults.Text = "The E-mail you provided is invalid";
                    break;

                case MembershipCreateStatus.InvalidAnswer:
                    CreateAccountResults.Text = "The answer you gave was invslid";
                    break;

                case MembershipCreateStatus.InvalidPassword:
                    CreateAccountResults.Text = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
                    break;

                default:
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }

            return CreateAccountResults.Text;
        }

    }
}