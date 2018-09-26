using CodePortal.Project.DbConnection;
using CodePortal.Project.School_Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebSchoolPortal.App_Resources.Pages.Student
{
    public partial class studentresultview : System.Web.UI.Page
    {
        List<ViewResult> reInfo = new List<ViewResult>();
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentViewScores svc = new StudentViewScores();
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    int numOfSub = Convert.ToInt32(Session["numOfsub"].ToString());
                    SqlCommand com = new SqlCommand("GetResultRecords", connection) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["SchoolId"].ToString();
                    com.Parameters.AddWithValue("@Arms", SqlDbType.Int).Value = GetArm();
                    com.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = Session["clsid"].ToString();
                    com.Parameters.AddWithValue("@StudRollNum", SqlDbType.NVarChar).Value = GetStudentId();
                    connection.Open();
                    SqlDataReader re = com.ExecuteReader();
                    if (re.Read())
                    {
                        lblterm.Text = Session["term"].ToString();
                        StudentName.Text = re["StudentNames"].ToString();
                        Clas.Text = Session["clsid"].ToString();
                        NameOfSchool.Text = re["SchoolName"].ToString();
                        schoolName2.Text = NameOfSchool.Text;
                        SchoolAddress.Text = re["StreetName"].ToString();
                        NumInClass.Text = re["CountStud"].ToString();
                        Sex.Text = re["Sex"].ToString();
                        Det.Text = System.DateTime.Now.ToShortDateString();
                    }
                    /*Binding To Grid*/
                    reInfo = ViewResult.ShowResult(GetStudentId(), Session["year"].ToString(), Session["term"].ToString());
                    GridViewResult.DataSource = reInfo;
                    GridViewResult.DataBind();
                    connection.Close();

                    getSchoolPix();

                    keytoRating();

                    decimal testTotal = 0;
                    decimal examsTotal = 0;
                    decimal totaTotal = 0;
                    decimal studentAverage = 0.0m;
                    int numPerClass = 0;

                    foreach (var val in reInfo)
                    {
                        testTotal += val.TestTotal;
                        TestTotal.Text = testTotal.ToString();

                        examsTotal += val.ExamsScores;
                        ExamasTotal.Text = examsTotal.ToString();

                        totaTotal += val.Total;
                        TotalTotal.Text = totaTotal.ToString();

                        studentAverage = totaTotal / numOfSub;
                        decimal a = Math.Round(studentAverage, 2);
                        studAv.Text = a.ToString();
                    }

                    getPosition();
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

        void keytoRating()
        {
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand c = new SqlCommand("getKeyToGrading", connection) { CommandType = CommandType.StoredProcedure };
                c.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["SchoolId"].ToString();
                connection.Close();
                connection.Open();
                SqlDataAdapter Da = new SqlDataAdapter(c);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                keyToRating.DataSource = Dt;
                keyToRating.DataBind();
                connection.Close();
            }
        }

        void getSchoolPix()
        {
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("getStudSchoolId", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = GetStudentId();
                connection.Open();
                SqlDataAdapter Da = new SqlDataAdapter(com);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);

                pixs2.DataSource = Dt;
                pixs2.DataBind();
                SchoolImage.DataSource = Dt;
                SchoolImage.DataBind();

                connection.Close();
            }
        }

        protected void keyToRating_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LowLimit = (Label)e.Row.FindControl("Lower");
                LowLimit.Text = LowLimit.Text + " %";

                Label UpperLimit = (Label)e.Row.FindControl("Upper");
                UpperLimit.Text = UpperLimit.Text + " %";
            }
        }

        

        void getPosition()
        {
            List<IdScores> gtScores = (List<IdScores>)Session["ScoreList"];
            List<getResultFromList> positonArray = new List<getResultFromList>();
            int i = 0;
            int index = gtScores.FindIndex(a => a.Id == GetStudentId());
            lblposition.Text = (index + 1).ToString();
            decimal ClassTotal = 0.0M;
            foreach (var result in gtScores)
            {
                ClassTotal += result.scores;
                foreach (var posAr in positonArray)
                {
                    posAr.Id = result.Id;
                    posAr.Scores = result.scores;
                    lblposition.Text = posAr.Position = (index + 1).ToString();

                                       
                }
            }
            int x = Convert.ToInt32(NumInClass.Text);
            //classAv.Text = Math.Round(ClassTotal / x, 2).ToString();

            //foreach (var pos in positonArray)
            //{
            //    if (pos.Id == GetStudentId())
            //    {
            //        lblposition.Text = pos.Position;
            //    }
            //}
        }

        private String GetStudentId()
        {
            string StudentId = "";
           // string userName = Session["UserName"].ToString();
            MembershipUser loggedInUser = Membership.GetUser();
            string uId = loggedInUser.ProviderUserKey.ToString();

            if (Roles.IsUserInRole("Student"))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber from StudentRegTab Where UserId=@uId", connection);
                    SelectCommand.Parameters.AddWithValue("@uId", SqlDbType.NVarChar).Value = uId;
                    connection.Open();
                    SqlDataReader read = SelectCommand.ExecuteReader();
                    while (read.Read())
                    {
                        StudentId = read["StudentRollNumber"].ToString();
                    }
                    connection.Close();
                    Session["StudentRollNumber"] = StudentId;
                    return StudentId;
                }
            }
            return StudentId;
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

    public class getResultFromList
    {
        public string Id { get; set; }
        public decimal Scores { get; set; }
        public string Position { get; set; }
    }
}