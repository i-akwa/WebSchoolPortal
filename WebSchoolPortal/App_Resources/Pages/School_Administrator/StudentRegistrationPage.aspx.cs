using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using CodePortal.Project.DbConnection;
using System.Web.Services;
using System.Security;
using System.Web.Security;
using CodePortal.Project.Students;
using CodePortal.Project.School_Admin;
using System.Threading;
using System.Threading.Tasks;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class StudentRegistrationPage : System.Web.UI.Page
    {
        static BinaryReader br;
        const string passwordQuest = "What is your native Language ?";
        static int inputStreamLength;
        static Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int rann = random.Next(1, 9999);
            RollNum.Text = "HEZ" + rann.ToString() + IdAdd();
            if (Session["pass"] == null && Passport.HasFile)
            {
                Session["pass"] = Passport;
            }
            else if (Session["pass"] != null && (!Passport.HasFile))
            {
                Passport = (FileUpload)Session["pass"];
            }
            else if (Passport.HasFile)
            {
                Session["pass"] = Passport;
            }

            if (!this.IsPostBack)
            {

                if (Request.InputStream.Length > 0)
                {

                    using (StreamReader reader = new StreamReader(Request.InputStream))
                    {
                        try
                        {
                            string imageName = Request.Cookies["SchoolId"].Value.ToString();
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
            if (!IsPostBack)
            {
                Email.Text = "";
                BindControl.BindDefaultClassDropDown(AdmissionClass);
                Question.Text = passwordQuest;
                RollNum.ReadOnly = true;
                getArms();
                Master.HeaderLabel = "Student Registration Point";
                schoolid.Text = Request.Cookies["SchoolId"].Value.ToString();
                using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand command = new SqlCommand("GetNation", connect) { CommandType = CommandType.StoredProcedure };
                    try
                    {
                        connect.Open();
                        Nation.Items.Add(new ListItem("-Select Country", ""));
                        Nation.AppendDataBoundItems = true;
                        SqlDataReader rd = command.ExecuteReader();
                        Nation.DataSource = rd;
                        Nation.DataTextField = "COUNTRYS";
                        Nation.DataValueField = "CountryID";
                        Nation.DataBind();
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

        }

        protected void Nation_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {

                //DropDownList State = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("State");
                //DropDownList Nation = (DropDownList)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("Nation");
                State.Items.Clear();
                State.Items.Add(new ListItem("-SELECT State-", ""));
                State.AppendDataBoundItems = true;

                SqlCommand command = new SqlCommand("GetState", connect) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@CountryID", SqlDbType.Int).Value = Convert.ToInt32(Nation.SelectedValue);
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

        protected void btnpass_Click(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.Image ImagePreview = Picture;

                if (Passport.HasFile == false)
                {
                    string message = "select a file to preview first";
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
                    Session["ProfilePictureImageBytes"] = Passport.FileBytes;
                    ImagePreview.ImageUrl = "~/App_Resources/FileHandlers/PicturePreview.ashx";

                    br = new BinaryReader(Passport.PostedFile.InputStream);
                    Session["BinaryReader"] = br;

                    inputStreamLength = (int)Passport.PostedFile.InputStream.Length;
                    Session["InputStreamLength"] = inputStreamLength;
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

        protected void sav_Click(object sender, EventArgs e)
        {
            try
            {
                string imageName = Request.Cookies["SchoolId"].Value.ToString();
                if (Passport.FileName.Trim() != "")
                {
                    string extension = Path.GetExtension(Passport.PostedFile.FileName);
                    if (((extension == ".jpg")) || ((extension == ".gif")) || ((extension == ".PNG")) || ((extension == ".GIF")) || ((extension == ".png")) || ((extension == ".JPG")))
                    {
                        string filePath = "~/App_Resources/images/" + imageName;
                        Passport.SaveAs(MapPath(filePath));
                    }
                }
                else
                {
                    string message = "There was a problem uploading your Image.\n Try Again.";
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
                string message = ex.Message + "\n There was a problem uploading your Image.\n Try Again.";
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


        protected void CreateUserWizard1_ActiveStepChanged(object sender, EventArgs e)
        {

        }

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    AdmissionClass.Items.Clear();
                    AdmissionClass.DataSource = Dt;
                    AdmissionClass.DataValueField = "ClassId";
                    AdmissionClass.DataTextField = "class";
                    AdmissionClass.DataBind();
                }
            }
            else if (ClassCheck.Checked == false)
            {
                AdmissionClass.Items.Clear();
                BindControl.BindDefaultClassDropDown(AdmissionClass);
            }
        }

        void getArms()
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetArns", connect) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    connect.Open();

                    SqlDataAdapter Ad = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Ad.Fill(Dt);
                    if (Dt!=null)
                    {
                        ArmsId.DataSource = Dt;
                        ArmsId.DataTextField = "Arm";
                        ArmsId.DataValueField = "ArmsId";
                        ArmsId.DataBind();
                    }
                    else if (Dt == null)
                    {

                        string message = "Please go to settings and input Arms";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("Comfirm('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);


                        Response.Redirect("~/App_Resources/Pages/School_Administrator/Class_ArmManagment.aspx");
                    }
                    connect.Close();
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
        }

        int IdAdd()
        {
            int identity = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand cmd = new SqlCommand("CallId", connect) { CommandType = CommandType.StoredProcedure };
                connect.Open();
                SqlDataReader re = cmd.ExecuteReader();
                if (re.Read())
                {
                    identity = Convert.ToInt32(re["StudentIdS"].ToString());
                }
                connect.Close();
            }
            return identity;
        }

        protected void BtnCreateUser_Click(object sender, EventArgs e)
        {
            int rann = random.Next(1, 9999);
            Random ran = new Random();
            int newRan = ran.Next(1, 99999);
            string rannum = "AUT" + newRan.ToString() + rann;
            string isCreated="";
            int isCreate = 0;
            try
            {
                //Calling Create Method To create User
                isCreated=Create();
                MembershipUser newUser = Membership.GetUser(UserName.Text);
                Guid UserId = (Guid)newUser.ProviderUserKey;

                if (isCreated == "Stdents' account was successfully created!")
                {
                    isCreate = Student_studentControl.AddNewStudent(schoolid.Text, UserId, RollNum.Text, FName.Text, MName.Text, LName.Text, Gender.SelectedItem.ToString(), Convert.ToDateTime(AdminDate.Text), AdmissionClass.SelectedValue.ToString(), Address1.Text, GuidiantName.Text, Email.Text, Convert.ToInt32(lga.SelectedValue), GMobNum.Text, rannum.ToString(), Convert.ToInt32(ArmsId.SelectedValue), Convert.ToDateTime(DateOfBirth.Text));
                }
                if (isCreate==0)
                {
                    if (Membership.GetUser(UserName.Text) != null)
                    {
                        Membership.DeleteUser(UserName.Text);
                        string message = "There was A problem during registration, Please try again";
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
                else if (isCreate >= 1)
                {
                    string newRole = "Student";
                    if (!Roles.RoleExists(newRole))
                    {
                        Roles.CreateRole(newRole);
                        Roles.AddUserToRole(UserName.Text, newRole);

                        string message = "Student Created";
                            StringBuilder sb = new StringBuilder();
                        refresh();
                        sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "myFunction", "myFunction()", true);
                            
                    }
                    else
                    {
                        
                        for(int i=0; i<=2; i++)
                        {
                            if(i==0)
                            {
                                Roles.AddUserToRole(UserName.Text, newRole);
                                Response.Write("0");
                            }
                            if(i==1)
                            {
                                refresh();
                            }
                            if(i==2)
                            {
                                string message = "Student Created";
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

            }
            catch (Exception ex)
            {
                string message =ex.Message+"There was A problem during on-going registration, Please try again";
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
        void refresh()
        {
            
            FName.Text = "";
            LName.Text = "";
            MName.Text = "";
            GuidiantName.Text = "";
            GMobNum.Text = "";
            Email.Text = "";
            Address1.Text = "";
            UserName.Text = "";
            Password.Text = "";
            Answer.Text = "";
            int rann = random.Next(1, 9999);
            RollNum.Text = "HEZ" + rann.ToString() + IdAdd();
        }

        private string Create()
        {
            MembershipCreateStatus createStatus;
            MembershipUser createNewUser = Membership.CreateUser(UserName.Text, Password.Text, Email.Text, Question.Text, Answer.Text, true, out createStatus);
            switch (createStatus)
            {
                case MembershipCreateStatus.Success:
                    CreateAccountResults.Text = "Stdents' account was successfully created!";
                    break;

                case MembershipCreateStatus.DuplicateUserName:
                    CreateAccountResults.Text = "There already exists a user with this UserName.";
                    break;

                case MembershipCreateStatus.InvalidEmail:
                    CreateAccountResults.Text = "The E-mail you provided is invalid";
                    break;

                case MembershipCreateStatus.InvalidAnswer:
                    CreateAccountResults.Text = "The answer you gave was invalid";
                    break;

                case MembershipCreateStatus.InvalidPassword:
                    CreateAccountResults.Text = "The password you provided is invalid.It must be seven characters long and have at least one non-alphanumeric character.";
                    break;

                default:
                    CreateAccountResults.Text = "There was an unknown error; the user account was NOT created.";
                    break;
            }

            return CreateAccountResults.Text;
        }

    }
}