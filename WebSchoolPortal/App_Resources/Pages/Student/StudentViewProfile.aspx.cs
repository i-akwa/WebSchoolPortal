using CodePortal.Project.BindControls;
using CodePortal.Project.DbConnection;
using CodePortal.Project.GenericList;
using CodePortal.Project.Students;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.Student
{
    public partial class StudentViewProfile : System.Web.UI.Page
    {

        AdminInfoData<Student_StudentInfo> StudebtInfo = new AdminInfoData<Student_StudentInfo>();
        static BinaryReader br;
        static int inputStreamLength;

        void getSName()
        {
            try
            {
                
                Label Schname = (Label)ProfilePixsFormView.FindControl("SSName");
                string SchoolId = "";
                if(User.IsInRole("Student"))
                {
                    SchoolId = Session["SchoolId"].ToString();
                }
                else if(User.IsInRole("SchoolAdmin"))
                {
                    SchoolId = Request.Cookies["SchoolId"].Value.ToString();
                }
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand Sel = new SqlCommand("SelSchoolName", connection) { CommandType = CommandType.StoredProcedure };
                    Sel.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                    connection.Open();
                    SqlDataReader re = Sel.ExecuteReader();
                    if (re.Read())
                    {
                            Schname.Text = re["SchoolName"].ToString();
                    }
                    else
                    {
                        Schname.Text = "";
                    }
                    connection.Close();
                }

            }
            catch (NullReferenceException e)
            {
                    string message = e+ "Session Expired- please REFRESH the page";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
            catch(Exception ex)
            {
                string message = "There was a problem with this student, You might need to contact technical Support. ";
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Master.HeaderLabel = "Profile";

                    GetStudentId();
                    GetStudent();
                    getSName();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message + " Please contact admin if error persist";
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

        private String GetStudentId()
        {
            string StudentId = "";
            string SchoolId = "";
            MembershipUser loggedInUser = Membership.GetUser();
            Guid id = (Guid)loggedInUser.ProviderUserKey;

            if (Roles.IsUserInRole("Student"))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber,SchoolId from StudentRegTab Where UserId=@id", connection);
                    SelectCommand.Parameters.AddWithValue("@id", SqlDbType.UniqueIdentifier).Value = id;
                    connection.Open();
                    SqlDataReader read = SelectCommand.ExecuteReader();
                    while (read.Read())
                    {
                        StudentId = read["StudentRollNumber"].ToString();
                        SchoolId = read["SchoolId"].ToString();
                    }
                    connection.Close();
                    Session["StudentRollNumber"] = StudentId;
                    Session["SchoolId"] = SchoolId;

                    return StudentId;
                }
            }
            if (Roles.IsUserInRole("SchoolAdmin"))
            {
                StudentId=Session["StudentRollNumber"].ToString();
            }
            return StudentId;
        }

        private void GetStudent()
        {
            StudebtInfo = Student_studentControl.GetStudentInformation(Session["StudentRollNumber"].ToString());
            ProfilePixsFormView.DataSource = StudebtInfo;
            ProfilePixsFormView.DataBind();

            frmTeacherDetails.DataSource = StudebtInfo;
            frmTeacherDetails.DataBind();
        }

        protected void btnPicturePreview_Click(object sender, EventArgs e)
        {
            try
            {
                FileUpload fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");
                System.Web.UI.WebControls.Image ImagePreview = (System.Web.UI.WebControls.Image)ProfilePixsFormView.FindControl("Image2");

                if (fluImage.HasFile == false)
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
                    Session["ProfilePictureImageBytes"] = fluImage.FileBytes;
                    ImagePreview.ImageUrl = "~/App_Resources/FileHandlers/PicturePreview.ashx";

                    br = new BinaryReader(fluImage.PostedFile.InputStream);
                    Session["BinaryReader"] = br;

                    inputStreamLength = (int)fluImage.PostedFile.InputStream.Length;
                    Session["InputStreamLength"] = inputStreamLength;
                }
            }
            catch (Exception ex)
            {
                string message = "Please contact admin if error persist";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                Response.Write(ex);
            }
        }

        protected void ProfilePixsFormView_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            try
            {
                if ((e.CommandName == "Edit"))
                {
                    ProfilePixsFormView.ChangeMode(FormViewMode.Edit);
                }
                else if ((e.CommandName == "Cancel"))
                {
                    ProfilePixsFormView.ChangeMode(FormViewMode.ReadOnly);
                }
            }
            catch (Exception exc)
            {
                string message = "Please contact admin if error persist";
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

        protected void ProfilePixsFormView_ItemUpdating1(object sender, FormViewUpdateEventArgs e)
        {
            try
            {
                string StudentId = ((HiddenField)ProfilePixsFormView.FindControl("hfUserID")).Value;
                string studentId = StudentId;
                var fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");
                if (Session["BinaryReader"] != null || Session["InputStreamLength"] != null)
                {
                    Student_studentControl.UpdateStudentProfilePicture(studentId, br, inputStreamLength);
                }
                else
                    e.Cancel = true;

                string message = "Update is successful";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);

                ProfilePixsFormView.ChangeMode(FormViewMode.ReadOnly);
                GetStudent();
            }
            catch (Exception ex)
            {
                string message = "Please contact admin if error persist";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                Response.Write(ex);
            }

        }

        protected void ProfilePixsFormView_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            try
            {
                GetStudent();              
            }
            catch (Exception exc)
            {
                string message = "Please contact system admin if error persist";
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


        protected void Nationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                DropDownList State = (DropDownList)frmTeacherDetails.FindControl("State");
                DropDownList Nation = (DropDownList)frmTeacherDetails.FindControl("Nationality");
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
                    string message = "Please contact admin if error persist";
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
                DropDownList State = (DropDownList)frmTeacherDetails.FindControl("State");
                DropDownList LgaId = (DropDownList)frmTeacherDetails.FindControl("lga");
                LgaId.Items.Add(new ListItem("-SELECT L.G.A-", ""));
                LgaId.AppendDataBoundItems = true;

                SqlCommand command = new SqlCommand("GetLGA", connect) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@stateID", SqlDbType.Int).Value = Convert.ToInt32(State.SelectedValue);
                try
                {
                    connect.Open();
                    SqlDataReader read = command.ExecuteReader();
                    LgaId.DataSource = read;
                    LgaId.DataTextField = "LGA";
                    LgaId.DataValueField = "LGAID";
                    LgaId.DataBind();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    string message = "Please contact admin if error persist";
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

        protected void frmTeacherDetails_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            try
            {
                GetStudent();
                using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand command = new SqlCommand("GetNation", connect) { CommandType = CommandType.StoredProcedure };
                    DropDownList Nation = (DropDownList)frmTeacherDetails.FindControl("Nationality");

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
            }
            catch (Exception ex)
            {
                string message = "Please contact admin if error persist";
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

        protected void frmTeacherDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    if (Roles.IsUserInRole("SchoolAdmin"))
                    {
                        frmTeacherDetails.ChangeMode(FormViewMode.Edit);
                    }
                    else
                    {
                        string message = "Sorry, Edit role is only for School administrator";
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
                else if (e.CommandName == "Cancel")
                {
                    frmTeacherDetails.ChangeMode(FormViewMode.ReadOnly);
                }
            }
            catch (Exception exc)
            {
                string message = "Please contact admin if error persist";
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

        protected void frmTeacherDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            try
            {
                frmTeacherDetails.PageIndex = e.NewPageIndex;
                frmTeacherDetails.PageIndex = e.NewPageIndex;
                GetStudent();
            }
            catch (Exception exc)
            {
                string message = "Please contact admin if error persist";
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

        protected void frmTeacherDetails_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            try
            {
                if (frmTeacherDetails.CurrentMode == FormViewMode.Edit)
                {
                    string StudRoll = ((HiddenField)frmTeacherDetails.FindControl("hfUserID")).Value;
                    TextBox SchoolId = (TextBox)frmTeacherDetails.FindControl("SchoolID");
                    TextBox FName = (TextBox)frmTeacherDetails.FindControl("FName");
                    TextBox MName = (TextBox)frmTeacherDetails.FindControl("MiddleName");
                    TextBox LName = (TextBox)frmTeacherDetails.FindControl("LName");
                    TextBox Adress = (TextBox)frmTeacherDetails.FindControl("txtContactAddress");
                    TextBox GPNum = (TextBox)frmTeacherDetails.FindControl("PNumber");
                    TextBox DOB = (TextBox)frmTeacherDetails.FindControl("DaOB");
                    TextBox Bor = (TextBox)frmTeacherDetails.FindControl("txtbor");
                    DropDownList sex = (DropDownList)frmTeacherDetails.FindControl("ddlGender");
                    DropDownList Lga = (DropDownList)frmTeacherDetails.FindControl("lga");
                    TextBox Smail = (TextBox)frmTeacherDetails.FindControl("Studmail");
                    TextBox SPNum = (TextBox)frmTeacherDetails.FindControl("StudentNum");
                    DropDownList claz = (DropDownList)frmTeacherDetails.FindControl("clas");


                    Student_studentControl.UpdateStudentRecord(SchoolId.Text, FName.Text, MName.Text, LName.Text, Adress.Text, StudRoll, SPNum.Text, sex.SelectedItem.Text, Smail.Text, GPNum.Text, Convert.ToDateTime(DOB.Text), Convert.ToInt32(Lga.SelectedValue), claz.SelectedValue.ToString());

                    string message = "Update is successful";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);

                    frmTeacherDetails.ChangeMode(FormViewMode.ReadOnly);
                    GetStudent();
                }
            }
            catch (Exception ex)
            {
                string message = "Please contact admin if error persist";
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

        protected void frmTeacherDetails_DataBound(object sender, EventArgs e)
        {
            if (frmTeacherDetails.CurrentMode == FormViewMode.Edit)
            {
                DropDownList claz = (DropDownList)frmTeacherDetails.FindControl("clas");
                BindControl.BindDefaultClassDropDown(claz);
            }
            
        }

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ClassCheck = (CheckBox)frmTeacherDetails.FindControl("ClassCheck");
            DropDownList claz = (DropDownList)frmTeacherDetails.FindControl("clas");
            if (ClassCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    if (Dt != null)
                    {
                        claz.Items.Clear();
                        claz.DataSource = Dt;
                        claz.DataValueField = "ClassId";
                        claz.DataTextField = "class";
                        claz.DataBind();
                    }
                    else if (Dt == null)
                    {
                        string message = "Please go to settings and input classes if you are a nusery/primary school.";
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
            else if (ClassCheck.Checked == false)
            {
                claz.Items.Clear();
                BindControl.BindFeesClassDropDown(claz);
            }
        }
    }
}