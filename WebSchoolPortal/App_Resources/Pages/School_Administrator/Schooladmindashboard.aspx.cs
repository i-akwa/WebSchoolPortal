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
    public partial class Schooladmindashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.HeaderLabel = "Dashboard";
                CountStudent();
                CountTeacher();
                CountMaleStudent();
                CountFemaleStudent();
                BindTeachers();
            }
        }
        void CountStudent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegStud", connection) { CommandType = CommandType.StoredProcedure };
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                connection.Open();
                SqlDataReader re = selcom.ExecuteReader();
                if (re.Read())
                {
                    regStud.Text = re["StudNum"].ToString();
                }
                connection.Close();
            }
        }
        void CountTeacher()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegTeacher", connection) { CommandType = CommandType.StoredProcedure };
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                connection.Open();
                SqlDataReader re = selcom.ExecuteReader();
                if (re.Read())
                {
                    NumTeach.Text = re["TeacherNum"].ToString();
                }
                connection.Close();
            }
        }
        void CountMaleStudent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegMale", connection) { CommandType = CommandType.StoredProcedure };
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                connection.Open();
                SqlDataReader re = selcom.ExecuteReader();
                if (re.Read())
                {
                    RegMale.Text = re["Gender"].ToString();
                }
                connection.Close();
            }
        }
        void CountFemaleStudent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegFemaleStudent", connection) { CommandType = CommandType.StoredProcedure };
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                connection.Open();
                SqlDataReader re = selcom.ExecuteReader();
                if (re.Read())
                {
                    RegFemale.Text = re["Gender"].ToString();
                }
                connection.Close();
            }
        }
        void BindTeachers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("GetTeachersForDashB", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                connection.Open();
                SqlDataAdapter Ad = new SqlDataAdapter(com);
                DataTable DT = new DataTable();
                Ad.Fill(DT);
                Teachers.DataSource = DT;
                Teachers.DataBind();
                connection.Close();
            }
        }

        protected void Teachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Teachers.PageIndex = e.NewPageIndex;
                Teachers.DataBind();

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
}