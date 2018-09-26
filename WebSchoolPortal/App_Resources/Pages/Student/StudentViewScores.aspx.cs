using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.Student
{
    public partial class StudentViewScores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand sel = new SqlCommand("ShowStudentResultRecord", connection) { CommandType = CommandType.StoredProcedure };
                sel.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = GetStudentId();
                sel.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["SchoolId"].ToString();
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sel);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grvStudentScored.DataSource = dt;
                grvStudentScored.DataBind();
                connection.Close();
            }
        }

        private string GetStudentId()
        {
            string StudentId = "";
            string schoolId = "";
            //  string userName = Session["UserName"].ToString();
            MembershipUser loggedInUser = Membership.GetUser();
            string Id = loggedInUser.ProviderUserKey.ToString();

            if (Roles.IsUserInRole("Student"))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber,SchoolId from StudentRegTab Where UserId=@Uid", connection);
                    SelectCommand.Parameters.AddWithValue("@Uid", SqlDbType.NVarChar).Value = Id;
                    connection.Open();
                    SqlDataReader read = SelectCommand.ExecuteReader();
                    while (read.Read())
                    {
                        StudentId = read["StudentRollNumber"].ToString();
                        schoolId = read["SchoolId"].ToString();
                    }
                    connection.Close();
                    Session["StudentRollNumber"] = StudentId;
                    Session["SchoolId"] = schoolId;
                    return StudentId;
                }
            }
            return StudentId;
        }

        protected void grvStudentScored_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("view"))
            {
                //Not Cleared
                int index = Convert.ToInt32(e.CommandArgument);
                string year = grvStudentScored.Rows[index].Cells[0].Text;
                string clas = grvStudentScored.Rows[index].Cells[1].Text;
                string term = grvStudentScored.Rows[index].Cells[2].Text;
                string numOfSub = grvStudentScored.Rows[index].Cells[4].Text;
               // string status = getStatus(clas, term, GetStudentId());
                getScoreList(clas, year, term);
                //string message = status;

                if (Membership.GetUser().IsApproved)
                {
                    Session["clsid"] = clas;
                    Session["year"] = year;
                    Session["term"] = term;
                    Session["numOfsub"] = numOfSub;
                    Response.Redirect("~/App_Resources/Pages/Student/studentresultview.aspx");

                }
            }
        }

        private string getStatus(string clas, string term, string studentRoll)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                string status = "";
                SqlCommand com = new SqlCommand("getFeesStatus", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = clas;
                com.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = studentRoll;
                com.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term;

                connection.Open();
                SqlDataReader re = com.ExecuteReader();
                if (re.Read())
                {
                    status = re["Status"].ToString();
                }
                connection.Close();
                return status;
            }
        }

        protected void grvStudentScored_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvStudentScored.PageIndex = e.NewPageIndex;
            grvStudentScored.DataBind();
        }

        public void getScoreList(string clas, string date, string term)
        {
            List<IdScores> getscores = new List<IdScores>();

            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("GetScoreAndIdList", con) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["SchoolId"].ToString();
                    com.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas;
                    com.Parameters.AddWithValue("@armsId", SqlDbType.Int).Value = GetArm();
                    com.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = date;
                    com.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term;
                    con.Open();
                    SqlDataReader re = com.ExecuteReader();

                    if (re.VisibleFieldCount>0)
                    {
                        while(re.Read())
                        {
                            IdScores idscores = new IdScores();
                            idscores.Id = re["RollId"].ToString();
                            idscores.scores = Convert.ToDecimal(re["total"].ToString());
                            getscores.Add(idscores);
                        }
                        Session["ScoreList"] = getscores.OrderByDescending(x => x.scores).ToList();
                    }
                    else
                    {
                        string message = "Error";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    string message =ex.Message+" Error";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                }

            }          
        }

        public int GetArm()
        {
            int arms = 0;
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {

                SqlCommand com = new SqlCommand("Select ArmsId From StudentRegTab Where StudentRollNumber=@StudentRollNumber", con);
                com.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = GetStudentId();
                con.Open();
                SqlDataReader read = com.ExecuteReader();
                if (read.Read())
                {
                    try
                    {
                        arms = Convert.ToInt32(read["ArmsId"].ToString());
                        return arms;
                    }
                    catch (InvalidCastException ex)
                    {
                        string message = "Object not properly casted";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    catch (Exception ex)
                    {
                        string message = "Please contact admin";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(message);
                        sb.Append("')};");
                        sb.Append("</script>");
                    }
                }
                return arms;
            }

        }
    }

    public class IdScores
    {
        public string Id { get; set; }
        public decimal scores { get; set; }
    }
}