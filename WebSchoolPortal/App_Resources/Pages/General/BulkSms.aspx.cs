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
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class BulkSms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Viewparent.Rows.Count < 1)
                {
                    Send.Visible = false ;
                }
                else if (Viewparent.Rows.Count > 0)
                {
                    Send.Visible = true;
                }
                Send.Enabled = false;
            if(!Page.IsPostBack)
            {
                BindControl.BindFeesClassDropDown(Classes);
            }
        }

        void bindGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("GetParents", connection) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = Classes.SelectedItem.Text;
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    connection.Open();
                    SqlDataAdapter Ad = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    Ad.Fill(DT);
                    Viewparent.DataSource = DT;
                    Viewparent.DataBind();
                    connection.Close();
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

        protected void search_Click(object sender, EventArgs e)
        {
            bindGrid();
            if (Viewparent.Rows.Count < 1)
            {
                Send.Visible = false;
            }
            else if (Viewparent.Rows.Count > 0)
            {
                Send.Visible = true;
            }
        }

        protected void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                Send.Enabled = true;
            }
            else if (txtMessage.Text == "")
            {
                Send.Enabled = false;
            }
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in Viewparent.Rows)
            {
                try
                {
                    string PName = gr.Cells[0].Text;
                    string PhoneNum = gr.Cells[1].Text;
                    string StudNam = gr.Cells[2].Text;

                    string message = txtMessage.Text + "\n" + "Thanks for using Auto-School";
                    SendSMS SendExams = new SendSMS();
                    SendExams.PostRequestSMS(message, PhoneNum, Request.Cookies["SchoolId"].Value);
                    string me = "Messages sent successfuly.";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(me);
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

        protected void ClasCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClasCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    Classes.Items.Clear();
                    Classes.DataSource = Dt;
                    Classes.DataValueField = "ClassId";
                    Classes.DataTextField = "class";
                    Classes.DataBind();

                    con.Close();
                }
            }

            else if (ClasCheck.Checked == false)
            {
                BindControl.BindFeesClassDropDown(Classes);

            }
        }
        }

}