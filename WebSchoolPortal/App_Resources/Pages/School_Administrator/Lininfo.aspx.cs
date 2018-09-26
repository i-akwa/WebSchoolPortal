using CodePortal.Project.BindControls;
using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class Lininfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                BindControl.BindDefaultClassDropDown(classes);
        }

        protected void grdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdView.PageIndex = e.NewPageIndex;
                grdView.DataBind();
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

        void BindGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand com = new SqlCommand(@"Select aspnet_Membership.UserId,aspnet_Users.UserName, aspnet_Membership.Password,aspnet_Membership.IsApproved, aspnet_Roles.RoleName, StudentRegTab.FirstName+' '+StudentRegTab.MiddleName+' '+StudentRegTab.LastName as name, classesTable.class From StudentRegTab
Left Outer Join aspnet_Users on aspnet_Users.UserId = StudentRegTab.UserId Left Outer join aspnet_Membership on aspnet_Membership.UserId = StudentRegTab.UserId
Left outer join aspnet_UsersInRoles on aspnet_UsersInRoles.UserId = StudentRegTab.UserId Left outer join aspnet_Roles
on aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId Left outer join classesTable on classesTable.ClassId = StudentRegTab.PresentClass
where StudentRegTab.SchoolId = @SchoolId and StudentRegTab.PresentClass=@class order by classesTable.class desc", con);
                    com.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = classes.SelectedValue.ToString();
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();

                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    ad.Fill(Dt);
                    con.Open();
                    grdView.DataSource = Dt;
                    grdView.DataBind();
                }
            }
            catch(Exception ex)
            {

            }
        }
        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "updateActive")
            {
                GridViewRow linkRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int rowIndex = linkRow.RowIndex;
                string approved = grdView.Rows[rowIndex].Cells[3].Text;
                int x = 0;
                if(approved=="False")
                {
                    x = 1;
                }
                else if(approved == "True")
                {
                    x = 0;
                }
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand com = new SqlCommand("Update aspnet_Membership SET aspnet_Membership.IsApproved = @approved where aspnet_Membership.UserId =@id ", con);
                    com.Parameters.AddWithValue("@approved", SqlDbType.Int).Value = x;
                    com.Parameters.AddWithValue("@id", SqlDbType.UniqueIdentifier).Value = e.CommandArgument.ToString();

                    con.Open();
                    int ra=com.ExecuteNonQuery();
                    con.Close();
                    if(ra>0)
                    {                        
                        string message = "Update made";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        BindGrid();
                    }
                }
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            BindGrid();
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
                        classes.Items.Clear();
                        classes.DataSource = Dt;
                        classes.DataValueField = "ClassId";
                        classes.DataTextField = "class";
                        classes.DataBind();
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
                classes.Items.Clear();
                BindControl.BindFeesClassDropDown(classes);
            }

        }

    }
}