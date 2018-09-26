using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CodePortal.Project.DbConnection;

namespace WebSchoolPortal.App_Resources.Pages.Teachers
{
    public partial class Teacherdashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CountTeacher();
            CountMaleTeachers();
            CountFemaleTeachers();

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
        void CountMaleTeachers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegMaleTeacher", connection) { CommandType = CommandType.StoredProcedure };
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
        void CountFemaleTeachers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("GetRegFemaleTeacher", connection) { CommandType = CommandType.StoredProcedure };
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
    }
}