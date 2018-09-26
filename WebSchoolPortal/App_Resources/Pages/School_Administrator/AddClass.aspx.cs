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
    public partial class AddClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SchoolID.Text = Request.Cookies["SchoolId"].Value;
            BindGrid();
            Update.Visible = false;
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect= new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertClasses", connect) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas.Text;
                    cmd.Parameters.AddWithValue("@schoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    BindGrid();
                    clas.Text = "";
                }
                catch(Exception ex)
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

        void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("SelectClass", con) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@schoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    con.Open();
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable DT = new DataTable();
                    Ad.Fill(DT);
                    classGrid.DataSource = DT;
                    classGrid.DataBind();
                    con.Close();
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

        protected void classGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Upd")
            {
                Update.Visible = true;
                submit.Visible = false;
                int index = Convert.ToInt32(e.CommandArgument);
                clas.Text = classGrid.Rows[index].Cells[1].Text;
                clasID.Text = classGrid.Rows[index].Cells[0].Text;
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("UpdateClass", con) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas.Text;
                com.Parameters.AddWithValue("@classId", SqlDbType.Int).Value = clasID.Text;
                com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolID.Text;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Update.Visible = false;
                submit.Visible = true;
                clas.Text = "";
                clasID.Text = "";
            }
        }

        protected void classGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            classGrid.PageIndex = e.NewPageIndex;
            classGrid.DataBind();
        }
    }
}