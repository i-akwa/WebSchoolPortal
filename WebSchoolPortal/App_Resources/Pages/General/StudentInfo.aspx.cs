using CodePortal.Project.BindControls;
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

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HeaderLabel = "Student Information";
            //if (Roles.IsUserInRole("Teacher"))
            //{
            //    LinkButton lnk = (LinkButton)StudentGrid.FindControl("viewStudent") as LinkButton;
            //    lnk.Visible = false;
            //}
            if(!Page.IsPostBack)
            BindControl.BindDefaultClassDropDown(ddlSearch);
           // searchStudent();
            
        }

        void searchStudent()
        {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectStudentInfo", connection) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    cmd.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = ddlSearch.SelectedValue.ToString();

                    connection.Open();
                    SqlDataAdapter Ad = new SqlDataAdapter(cmd);
                    DataTable tab = new DataTable();
                    Ad.Fill(tab);
                    StudentGrid.DataSource = tab;
                    StudentGrid.DataBind();
                    connection.Close();

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            searchStudent();
        }

        protected void StudentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "Sel")
                {
                    if (Roles.IsUserInRole("Teacher"))
                    {
                        string message = "This previllege is not allowed for this role";
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
                        LinkButton lb = (LinkButton)StudentGrid.FindControl("viewStudent");
                        Session["StudentRollNumber"] = e.CommandArgument.ToString();
                        using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                        {
                            SqlCommand ins = new SqlCommand("select EmailAdress from StudentRegTab where StudentRollNumber=@rol", connection);
                            ins.Parameters.AddWithValue("@rol", SqlDbType.NVarChar).Value = e.CommandArgument.ToString();
                            connection.Open();
                            SqlDataReader re = ins.ExecuteReader();
                            if (re.Read())
                            {
                                Session["email"] = re["EmailAdress"].ToString();
                            }
                            re.Close();
                            connection.Close();
                            Response.Redirect("~/App_Resources/Pages/Student/StudentViewProfile.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void StudentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                StudentGrid.PageIndex = e.NewPageIndex;
                StudentGrid.DataBind();

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

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
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
                        ddlSearch.Items.Clear();
                        ddlSearch.DataSource = Dt;
                        ddlSearch.DataValueField = "ClassId";
                        ddlSearch.DataTextField = "class";
                        ddlSearch.DataBind();
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
                ddlSearch.Items.Clear();
                BindControl.BindFeesClassDropDown(ddlSearch);
            }
        }
    }
}