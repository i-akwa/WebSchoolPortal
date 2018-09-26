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
    public partial class ReciptPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GetSchoolName();
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand sel = new SqlCommand("Select name, studentRollnum, paymentDate, studentClass, Fees, amountPaid, Term, Status from PaymentTable where paymentDate=@PaymentDate and studentRollnum=@studentRollnum ", connection);
                    sel.Parameters.AddWithValue("@PaymentDate", SqlDbType.DateTime).Value = Convert.ToDateTime(Session["PayDate"]);
                    sel.Parameters.AddWithValue("@studentRollnum", SqlDbType.NVarChar).Value = Session["Rol"].ToString();
                    connection.Open();
                    SqlDataReader re = sel.ExecuteReader();
                    if (re.Read())
                    {
                        Name.Text = re["name"].ToString();
                        Roll.Text = re["studentRollnum"].ToString();
                        PayDate.Text = Convert.ToDateTime(re["paymentDate"]).ToString();
                        Class.Text = re["studentClass"].ToString();
                        Fees.Text = re["Fees"].ToString();
                        AP.Text = re["amountPaid"].ToString();
                        Term.Text = re["Term"].ToString();
                        status.Text = re["Status"].ToString();
                    }
                    re.Close();
                    connection.Close();
                }
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

        void GetSchoolName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand cmd = new SqlCommand("Select SchoolName from SchoolAdminRegistration where SchoolId=@SchoolId", connection);
                cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                connection.Open();
                SqlDataReader re = cmd.ExecuteReader();
                if (re.Read())
                {
                    Title.Text = re["SchoolName"].ToString();
                }
                connection.Close();
            }
        }
    }
}