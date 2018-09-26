using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CodePortal.Project.School_Admin;
using System.Text;
using CodePortal.Project.DbConnection;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WebSchoolPortal.App_Resources.Pages.App_Administrator
{
    public partial class RegisterSchoolAdmin : System.Web.UI.Page
    {
        const string PQ = "What tribe are you from?";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Question.Text = PQ;
                GenId();
                using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand command = new SqlCommand("GetNation", connect) { CommandType = CommandType.StoredProcedure };
                    try
                    {
                        connect.Open();
                        Nationality.Items.Add(new ListItem("-Select Country", ""));
                        Nationality.AppendDataBoundItems = true;
                        SqlDataReader rd = command.ExecuteReader();
                        Nationality.DataSource = rd;
                        Nationality.DataTextField = "COUNTRYS";
                        Nationality.DataValueField = "CountryID";
                        Nationality.DataBind();
                        connect.Close();
                    }
                    catch (System.ComponentModel.Win32Exception x)
                    {
                        string message = "Please Reload Page or Support for help";
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
            
        }

        private string GenId()
        {
            string holdId = "";
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                
                    SqlCommand selectcom = new SqlCommand("FormSchoolId", connect) { CommandType = CommandType.StoredProcedure };
                    connect.Open();
                    int scId = 0;
                    SqlDataReader google = selectcom.ExecuteReader();
                    

                    if (google.Read())
                    {
                        scId = Convert.ToInt32(google["id"].ToString());
                        scId += 1;
                        if (isGovSch.Checked)
                        {
                            SchoolId.Text = "A488-" + scId.ToString() + "-GOV";
                            holdId = "A488-" + scId.ToString();
                            return holdId;
                        }
                        else if (isGovSch.Checked == false)
                        {
                            SchoolId.Text = "A488-" + scId.ToString() + "-PRV";
                            holdId = "A488-" + scId.ToString();
                            return holdId;
                        }
                    }
                    else if (!google.Read())
                    {
                        scId = Convert.ToInt32(google["id"].ToString());
                        scId += 1;
                        if (isGovSch.Checked)
                        {
                            SchoolId.Text = "A488-" + scId.ToString() + "-GOV";
                            holdId = "A488-" + scId.ToString();
                            return holdId;
                        }
                        else if (isGovSch.Checked == false)
                        {
                            SchoolId.Text = "A488-" + scId.ToString() + "-PRV";
                            holdId = "A488-" + scId.ToString();
                            return holdId;
                        }
                    }
                    return holdId;
                
            }
        }



        protected void Nationality_SelectedIndexChanged(object sender, EventArgs e)
        {

            using(SqlConnection connect= new SqlConnection(ConnectionClass.getConnection))
            {
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
                //DropDownList State = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("State");
                //DropDownList LgaId = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("lga");
                lga.Items.Clear();
                lga.Items.Add(new ListItem("-SELECT L.G.A-", ""));
                lga.AppendDataBoundItems = true;

                SqlCommand command = new SqlCommand("GetLGA", connect) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@stateID", SqlDbType.Int).Value = Convert.ToInt32(State.SelectedValue);
                try
                {
                    connect.Open();
                    SqlDataReader read = command.ExecuteReader();
                    lga.DataSource = read;
                    lga.DataTextField = "LGA";
                    lga.DataValueField = "LGAID";
                    lga.DataBind();
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

        protected void isGovSch_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox isGov = (CheckBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("isGovSch");
            //TextBox id = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("SchoolId");
            string holdId = GenId();
            if (isGovSch.Checked)
            {
                SchoolId.Text = holdId + "-GOV";
            }

            else 
            {
                SchoolId.Text = holdId + "-PRV";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            int a = 0;
            try
            {

                if (SchoolName.Text == "" || SurName.Text.Trim() == "" || OtherNames.Text == "" || StreetName.Text == "" || MobilePin.Text.Trim() == "" || Email.Text.Trim() == "" || lga.SelectedIndex == 0)
                {
                    string message = "Please Fill All The TextBoxes With The Correct Information";
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
                    string createStatus=CreateSchoolAdmin();

                    MembershipUser newUser = Membership.GetUser(UserName.Text);
                    Guid UserId = (Guid)newUser.ProviderUserKey;

                    if (createStatus == "Admins' account was successfully created!")
                    a = SchoolAdminControl.addNewSchoolAdmin(SchoolId.Text, UserId, SchoolName.Text, SurName.Text.Trim(), OtherNames.Text.Trim(), StreetName.Text, Convert.ToInt32(lga.SelectedValue), Convert.ToDateTime(RegistrationDate.Text), MobilePin.Text, Email.Text.Trim(), Gender.SelectedItem.ToString(), SchoolPostalCode.Text.Trim());
                    
                    if(a==0)
                    {
                        if(Membership.GetUser(UserName.Text)!=null)
                        Membership.DeleteUser(UserName.Text);
                        
                        string message = "User Account did not create, Please check for input error or contact Application Administrator";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    else if(a>=1)
                    {
                        string newRole = "SchoolAdmin";
                        if (!Roles.RoleExists(newRole))
                        {
                            Roles.CreateRole(newRole);
                            Roles.AddUserToRole(UserName.Text, newRole);

                        }
                        else
                        {
                            Roles.AddUserToRole(UserName.Text, newRole);
                        }
                        string Mess = createStatus+", Welcome " + SchoolName.Text + " to Automated Schools. Your School ID is " + SchoolId.Text + " Your School have been registered successfully.";
                        SendSMS SendDetails = new SendSMS();
                        SendDetails.PostRequestSMS(Mess, MobilePin.Text, SchoolId.Text);
                        ClearControls();
                        string message = "Your School have been registered successfully.";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        Response.Redirect("~/App_Resources/Pages/Anonymous/success.aspx");
                    }
                }
            }

            catch (Exception ex)
            {
                string message = ex.Message;
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

        protected void check1_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            e.IsValid = check1.Checked;
        }

        string CreateSchoolAdmin()
        {
            string createMessage = "";
            MembershipCreateStatus status;
            Membership.CreateUser(UserName.Text, Password.Text, Email.Text, Question.Text, Answer.Text, true, out status);
            switch(status)
            {
                case MembershipCreateStatus.Success:
                    createMessage = "Admins' account was successfully created!";
                    break;

                case MembershipCreateStatus.DuplicateUserName:
                    createMessage = "There already exists a user with this username.";
                    break;

                case MembershipCreateStatus.InvalidEmail:
                    createMessage = "The E-mail you provided is invalid";
                    break;

                case MembershipCreateStatus.InvalidAnswer:
                    createMessage = "The answer you gave was invalid";
                    break;

                case MembershipCreateStatus.InvalidPassword:
                    createMessage = "The password you provided is invalid. It must be seven characters long and have at least one non-alphanumeric character.";
                    break;

                default:
                    createMessage = "There was an unknown error; the user account was NOT created.";
                    break;
            }

            return createMessage;
        }

        private void ClearControls()
        {
            SchoolName.Text = "";
            Email.Text = "";
            SurName.Text = "";
            OtherNames.Text = "";
            StreetName.Text = "";
            RegistrationDate.Text = "";
            MobilePin.Text = "";
            SchoolPostalCode.Text = "";
        }

        
    }
}