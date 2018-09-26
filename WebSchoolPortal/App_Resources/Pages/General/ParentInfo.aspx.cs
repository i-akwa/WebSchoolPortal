using CodePortal.Project.BindControls;
using CodePortal.Project.DbConnection;
using CodePortal.Project.School_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class ParentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindControl.BindDefaultClassDropDown(DDlSearch);
            }

        }

        void GetParent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("PerentInfo", connection) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    com.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = DDlSearch.SelectedValue.ToString();

                    connection.Open();
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable tab = new DataTable();
                    Ad.Fill(tab);
                    ParentGrid.DataSource = tab;
                    ParentGrid.DataBind();
                    connection.Close();
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

        protected void ParentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string rolNum = e.CommandArgument.ToString();
                if (e.CommandName == "Send")
                {
                    GridViewRow LinkRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = LinkRow.RowIndex;
                    TextBox Mes = ParentGrid.Rows[rowIndex].Cells[4].FindControl("Message") as TextBox;
                    string phoneNumber = ParentGrid.Rows[rowIndex].Cells[1].Text;
                    string Message = (ParentGrid.Rows[rowIndex].Cells[4].FindControl("Message") as TextBox).Text;
                    if (Mes.Text != "")
                    {
                        SendSMS SendExams = new SendSMS();
                        SendExams.PostRequestSMS(Message, phoneNumber, Request.Cookies["SchoolId"].Value);
                        string message = "Message Sent.";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                        Mes.Text = "";
                    }
                    else if (Mes.Text == "")
                    {
                        string message = "Please input the information to be sent.";
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
            catch (Exception ex)
            {
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetParent();
        }

        protected void ParentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ParentGrid.PageIndex = e.NewPageIndex;
            ParentGrid.DataBind();
        }
    }
}