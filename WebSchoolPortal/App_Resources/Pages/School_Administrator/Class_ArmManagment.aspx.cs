using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.Students;
using CodePortal.Project.DbConnection;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Security;
using System.Web.Security;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class ClassA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.HeaderLabel = "CLASS ARM MANAGEMENT";
                Student_studentControl.DisplayArms(Request.Cookies["SchoolId"].Value.ToString(), grdArms);
                SCHIILID.Text = Request.Cookies["SchoolId"].Value.ToString();
                btnUpdate.Visible = false;
                if (grdArms.Rows.Count > 0)
                {
                    NoticeInfo.Visible = false;
                }
            }
        }

        protected void ADD_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    string arm = Arms.Text;
                    string[] arms = arm.Split(',');
                    for (int i = 0; i < arms.Length; i++)
                    {
                        SqlCommand selectCommand = new SqlCommand("insert into armsTable (Arm,SchoolId) values('" + arms[i] + "',@SchoolId)", connect);
                        selectCommand.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SCHIILID.Text;
                        connect.Open();
                        selectCommand.ExecuteNonQuery();
                        connect.Close();

                        string message = "Arm Inserted.";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);

                        Student_studentControl.DisplayArms(Request.Cookies["SchoolId"].Value.ToString(), grdArms);
                    }

                }
                catch (Exception ex)
                {
                    if (SCHIILID.Text != Session["SchoolId"].ToString())
                    {
                        string message = "Invalid School ID";
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
                finally
                {
                    Arms.Text = "";
                }

            }
        }

        protected void grdArms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                btnUpdate.Visible = true;
                ADD.Visible = false;
                int getId =Convert.ToInt32(e.CommandArgument);
                string comName = e.CommandName;

                if (comName.Equals("change"))
                {
                    SqlCommand select = new SqlCommand("select Arm, ArmsId from armsTable where ArmsId=@ArmsId", connect);
                    select.Parameters.AddWithValue("@ArmsId", SqlDbType.NVarChar).Value = getId;
                    connect.Open();
                    SqlDataReader reader = select.ExecuteReader();
                    if (reader.Read())
                    {
                        Arms.Text = reader["Arm"].ToString();
                        HiddenLabel.Text = reader["ArmsId"].ToString();
                    }
                    connect.Close();

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {

                    SqlCommand Update = new SqlCommand("Update armsTable set Arm=@Arm where ArmsId=@ArmsId", connect);
                    Update.Parameters.AddWithValue("@Arm", SqlDbType.NVarChar).Value = Arms.Text;
                    Update.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = HiddenLabel.Text;
                    connect.Open();
                    Update.ExecuteNonQuery();
                    connect.Close();
                    string message = "Arm Updated.";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    Student_studentControl.DisplayArms(Request.Cookies["SchoolId"].Value.ToString(), grdArms);
                }
                catch (Exception ex)
                {
                    string message = "Error While Updating";
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
                    Arms.Text = "";
                    btnUpdate.Visible = false;
                    ADD.Visible = true;
                }
            }
        }


    }
}