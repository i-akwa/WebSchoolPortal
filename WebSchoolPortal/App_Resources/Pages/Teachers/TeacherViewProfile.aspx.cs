using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using CodePortal.Project.DbConnection;
using CodePortal.Project.GenericList;
using CodePortal.Project.Teachers;
using System.IO;
using System.Data;

namespace WebSchoolPortal.App_Resources.Pages.Teachers
{
    public partial class TeacherViewProfile : System.Web.UI.Page
    {
        AdminInfoData<TeacherInfoAccessor> TeacherInfo = new AdminInfoData<TeacherInfoAccessor>();
        static BinaryReader br;
        static int inputStreamLength;

        void getSName()
        {
            try
            {
                Label Schoolname = (Label)ProfilePixsFormView.FindControl("SName");
                //Label Schname = (Label)ProfilePixsFormView.FindControl("SSName");

                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand Sel = new SqlCommand("SelSchoolName", connection) { CommandType = CommandType.StoredProcedure };
                    Sel.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["TESchoolId"].Value.ToString();
                    connection.Open();
                    SqlDataReader re = Sel.ExecuteReader();
                    if (re.Read())
                    {
                        var x = re["SchoolName"].ToString();
                        if (Schoolname.Text == "")
                        {
                            Schoolname.Text = x.ToString();
                        }

                    }
                    else
                    {
                        Schoolname.Text = "";
                    }
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
                string message = ex.Message.ToString() + "Me";
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
                    GetTeac();
                    getSName();
                    Master.HeaderLabel = "Teacher Profile";
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
                Response.Write(ex);
            }
        }

        private String GetTeacherId()
        {
            string TeacherId = "";
            string userName = Membership.GetUser().UserName;
            MembershipUser loggedInUser = Membership.GetUser(userName);
            string mail = loggedInUser.Email;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand SelectCommand = new SqlCommand("Select TeacherRollId from TeacherTab Where EmailAdress=@TeacherEmailAdress", connection);
                SelectCommand.Parameters.AddWithValue("@TeacherEmailAdress", SqlDbType.NVarChar).Value = mail;
                connection.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    TeacherId = read["TeacherRollId"].ToString();
                }
                connection.Close();
                Session["TeacherRollId"] = TeacherId;
                return TeacherId;
            }
        }

        private void GetTeac()
        {
            TeacherInfo = TeacherInformationControl.GetTeacher(GetTeacherId());
            ProfilePixsFormView.DataSource = TeacherInfo;
            ProfilePixsFormView.DataBind();

            frmTeacherDetails.DataSource = TeacherInfo;
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
                string message = ex.Message.ToString();
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
                string message = exc.Message.ToString();
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

        protected void ProfilePixsFormView_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            try
            {
                GetTeac();
            }
            catch (Exception exc)
            {
                string message = exc.Message.ToString();
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
                string TeacherId = ((HiddenField)ProfilePixsFormView.FindControl("hfUserID")).Value;
                string TeacherID = TeacherId;
                var fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");
                if (Session["BinaryReader"] != null || Session["InputStreamLength"] != null)
                {
                    TeacherInformationControl.UpdateProfilePicture(TeacherID, br, inputStreamLength);
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
                GetTeac();
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
                Response.Write(ex);
            }

        }

        protected void frmTeacherDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    frmTeacherDetails.ChangeMode(FormViewMode.Edit);

                }
                else if (e.CommandName == "Cancel")
                {
                    frmTeacherDetails.ChangeMode(FormViewMode.ReadOnly);
                }
            }
            catch (Exception exc)
            {
                string message = exc.Message.ToString();
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

        protected void frmTeacherDetails_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            try
            {
                GetTeac();
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

        protected void frmTeacherDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            try
            {
                frmTeacherDetails.PageIndex = e.NewPageIndex;
                frmTeacherDetails.PageIndex = e.NewPageIndex;
                GetTeac();
            }
            catch (Exception exc)
            {
                string message = exc.Message.ToString();
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
                    string TeacherId = ((HiddenField)frmTeacherDetails.FindControl("hfUserID")).Value;
                    TextBox SchoolID = (TextBox)frmTeacherDetails.FindControl("SchoolID");
                    TextBox FName = (TextBox)frmTeacherDetails.FindControl("FirstName");
                    TextBox MName = (TextBox)frmTeacherDetails.FindControl("MiddleName");
                    TextBox LName = (TextBox)frmTeacherDetails.FindControl("LastName");
                    TextBox Adress = (TextBox)frmTeacherDetails.FindControl("ContactAdress");
                    TextBox PhoneNumber = (TextBox)frmTeacherDetails.FindControl("txtMobilePhoneNumber");
                    DropDownList Lga = (DropDownList)frmTeacherDetails.FindControl("lga");
                    DropDownList gender = (DropDownList)frmTeacherDetails.FindControl("ddlGender");

                    TeacherInformationControl.updateTeacherProfile(SchoolID.Text,TeacherId,FName.Text,MName.Text,LName.Text,PhoneNumber.Text,gender.Text,Adress.Text,Convert.ToInt32(Lga.SelectedValue));

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
                    GetTeac();

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
}