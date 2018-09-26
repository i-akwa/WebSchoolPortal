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
using CodePortal.Project.School_Admin;
using System.IO;
using System.Data;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class EmployeeProfile : System.Web.UI.Page
    {
        AdminInfoData<AdminRegistration> AdminInfo = new AdminInfoData<AdminRegistration>();
        static BinaryReader br;
        static int inputStreamLength;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {

                    GetSchoolAdmin();
                    Master.HeaderLabel = "School Profile";
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

        private void GetSchoolAdmin()
        {
            try
            {
                AdminInfo = SchoolAdminControl.GetSchoolAdmin(Request.Cookies["SchoolId"].Value.ToString());
                ProfilePixsFormView.DataSource = AdminInfo;
                ProfilePixsFormView.DataBind();

                frmSchoolAdminDetails.DataSource = AdminInfo;
                frmSchoolAdminDetails.DataBind();
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

        protected void btnPicturePreview_Click(object sender, EventArgs e)
        {//Picture Preview Button
            try
            {

                FileUpload fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");

                System.Web.UI.WebControls.Image ImagePreview = (System.Web.UI.WebControls.Image)ProfilePixsFormView.FindControl("ProfImage");

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
                    var fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");
                    if (Session["pass"] == null && fluImage.HasFile)
                    {
                        Session["pass"] = fluImage;
                    }
                    else if (Session["pass"] != null && (!fluImage.HasFile))
                    {
                        fluImage = (FileUpload)Session["pass"];
                    }
                    else if (fluImage.HasFile)
                    {
                        Session["pass"] = fluImage;
                    }

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
                GetSchoolAdmin();
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
                string schoolId = ((HiddenField)ProfilePixsFormView.FindControl("hfUserID")).Value;
                string SchoolId = schoolId;
                var fluImage = (FileUpload)ProfilePixsFormView.FindControl("fluImage");
                if (Session["BinaryReader"] != null || Session["InputStreamLength"] != null)
                {
                    SchoolAdminControl.UpdateProfilePicture(SchoolId, br, inputStreamLength);
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
                GetSchoolAdmin();
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

        protected void frmSchoolAdminDetails_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    frmSchoolAdminDetails.ChangeMode(FormViewMode.Edit);

                }
                else if (e.CommandName == "Cancel")
                {
                    frmSchoolAdminDetails.ChangeMode(FormViewMode.ReadOnly);
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

        protected void frmSchoolAdminDetails_ModeChanging(object sender, FormViewModeEventArgs e)
        {
            try
            {
                GetSchoolAdmin();
                using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand command = new SqlCommand("GetNation", connect) { CommandType = CommandType.StoredProcedure };
                    DropDownList Nation = (DropDownList)frmSchoolAdminDetails.FindControl("Nationality");

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

        protected void frmSchoolAdminDetails_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            try
            {
                frmSchoolAdminDetails.PageIndex = e.NewPageIndex;
                frmSchoolAdminDetails.PageIndex = e.NewPageIndex;
                GetSchoolAdmin();
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

        protected void frmSchoolAdminDetails_ItemUpdating(object sender, FormViewUpdateEventArgs e)
        {
            try
            {
                if (frmSchoolAdminDetails.CurrentMode == FormViewMode.Edit)
                {
                    string SchoolId = ((HiddenField)frmSchoolAdminDetails.FindControl("hfUserID")).Value;
                    TextBox SchoolName = (TextBox)frmSchoolAdminDetails.FindControl("SchoolName");
                    TextBox SurName = (TextBox)frmSchoolAdminDetails.FindControl("txtSurname");
                    TextBox OtherNames = (TextBox)frmSchoolAdminDetails.FindControl("txtOtherNames");
                    TextBox Adress = (TextBox)frmSchoolAdminDetails.FindControl("txtContactAddress");
                    TextBox PostalCode = (TextBox)frmSchoolAdminDetails.FindControl("postCode");
                    TextBox PhoneNumber = (TextBox)frmSchoolAdminDetails.FindControl("txtMobilePhoneNumber");
                    DropDownList Lga = (DropDownList)frmSchoolAdminDetails.FindControl("lga");
                    DropDownList gender = (DropDownList)frmSchoolAdminDetails.FindControl("ddlGender");
                    

                    SchoolAdminControl.updateSchoolAdminProfile(SchoolId, SchoolName.Text, SurName.Text, OtherNames.Text, Adress.Text, PhoneNumber.Text, PostalCode.Text, gender.SelectedItem.ToString(), Convert.ToInt32(Lga.SelectedValue)) ;

                    string message = "Update is successful";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);

                    frmSchoolAdminDetails.ChangeMode(FormViewMode.ReadOnly);
                    GetSchoolAdmin();

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
                DropDownList State = (DropDownList)frmSchoolAdminDetails.FindControl("State");
                DropDownList Nation = (DropDownList)frmSchoolAdminDetails.FindControl("Nationality");
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
                DropDownList State = (DropDownList)frmSchoolAdminDetails.FindControl("State");
                DropDownList LgaId = (DropDownList)frmSchoolAdminDetails.FindControl("lga");
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