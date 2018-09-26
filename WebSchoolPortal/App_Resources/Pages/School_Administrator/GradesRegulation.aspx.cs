using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.Students;
using System.Text;
using System.Data.SqlClient;
using CodePortal.Project.DbConnection;
using System.Data;
using System.Web.Security;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class Grades_Regulation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Insert.Visible = true;
            Update.Visible = false;
            try
            {
                SchoolId.Text = Request.Cookies["SchoolId"].Value;
                BindGrid();
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

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                int x = 0;
                try
                {
                    SqlCommand insert = new SqlCommand("InsertGrades", con) { CommandType = CommandType.StoredProcedure };
                    insert.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                    insert.Parameters.AddWithValue("@UpperLimit", SqlDbType.Int).Value = UpperLimits.Text;
                    insert.Parameters.AddWithValue("@LowerLimit", SqlDbType.Int).Value = LowerLimits.Text;
                    insert.Parameters.AddWithValue("@Grades", SqlDbType.Char).Value = Grades.Text;
                    insert.Parameters.AddWithValue("@Remark", SqlDbType.NVarChar).Value = Remark.Text;
                    con.Open();
                     x = insert.ExecuteNonQuery();
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
                finally
                {
                    if (x > -1)
                    {
                        string message = x.ToString() + " Rows inserted";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    else if (x < 0)
                    {
                        string message = 0 + " Rows inserted";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    BindGrid();
                    ClearText();
                }
            }
        }

        void BindGrid()
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("Select * from GradesTable where SchoolId=@SchoolId", connect);
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    connect.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    ad.Fill(Dt);
                    viewGrades.DataSource = Dt;
                    viewGrades.DataBind();
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

        private void ClearText()
        {
            UpperLimits.Text = "";
            LowerLimits.Text = "";
            Grades.Text = "";
            Remark.Text = "";
            lblGradesId.Text = "";
        }

        protected void viewGrades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                Update.Visible = true;
                Insert.Visible = false;
                if (e.CommandName == "upd")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    UpperLimits.Text = viewGrades.Rows[index].Cells[2].Text;
                    LowerLimits.Text = viewGrades.Rows[index].Cells[3].Text;
                    Grades.Text = viewGrades.Rows[index].Cells[1].Text;
                    lblGradesId.Text = viewGrades.Rows[index].Cells[0].Text;
                    Remark.Text = viewGrades.Rows[index].Cells[4].Text;
                }
            }
        }

        protected void viewGrades_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        protected void Update_Click(object sender, System.EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("UpdateGrades", con) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@UpperLimit", SqlDbType.Int).Value =Convert.ToInt32(UpperLimits.Text);
                    com.Parameters.AddWithValue("@LowerLimit", SqlDbType.Int).Value =Convert.ToInt32(LowerLimits.Text);
                    com.Parameters.AddWithValue("@Grades", SqlDbType.Char).Value = Grades.Text;
                    com.Parameters.AddWithValue("@Remark", SqlDbType.NVarChar).Value = Remark.Text;
                    com.Parameters.AddWithValue("@GradeId", SqlDbType.Int).Value =Convert.ToInt32(lblGradesId.Text);
                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
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
                finally
                {
                    ClearText();
                    string message = "Update Successful";
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