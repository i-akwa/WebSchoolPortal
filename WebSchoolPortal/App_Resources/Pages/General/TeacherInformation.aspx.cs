using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class TeacherInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HeaderLabel = "View Teacher Information";
        }

        void selectTeacher()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("TeacherInfo", connection) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@Namee",SqlDbType.NVarChar).Value=txt1.Text;
                    com.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    com.Parameters.AddWithValue("@RollID",SqlDbType.NVarChar).Value=txt1.Text;

                    connection.Open();
                    SqlDataAdapter Ad = new SqlDataAdapter(com);
                    DataTable tab = new DataTable();
                    Ad.Fill(tab);
                    TeacherGrid.DataSource = tab;
                    TeacherGrid.DataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            selectTeacher();
        }
    }
}