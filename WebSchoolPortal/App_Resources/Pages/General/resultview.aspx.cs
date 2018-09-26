using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.School_Admin;
using System.Text;

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class resultview : System.Web.UI.Page
    {
        List<ViewResult> reInfo = new List<ViewResult>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    int numOfStud = Convert.ToInt32(Session["numOfsub"].ToString());
                    SqlCommand com = new SqlCommand("GetResultRecords", connection) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    com.Parameters.AddWithValue("@Arms", SqlDbType.Int).Value = Convert.ToInt32(Session["armId"].ToString());
                    com.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = Session["clsid"].ToString();
                    com.Parameters.AddWithValue("@StudRollNum", SqlDbType.NVarChar).Value = Session["Id"].ToString();
                    com.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = Session["Term"].ToString();
                    com.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = Session["date"].ToString();

                    connection.Open();
                    SqlDataReader re = com.ExecuteReader();
                    if (re.Read())
                    {
                        lblterm.Text = Session["Term"].ToString();
                        StudentName.Text = re["StudentNames"].ToString();
                        Clas.Text = Session["cls"].ToString();
                        NameOfSchool.Text = re["SchoolName"].ToString();
                        schoolsname2.Text = NameOfSchool.Text;
                        SchoolAddress.Text = re["StreetName"].ToString();
                        NumInClass.Text = re["CountStud"].ToString();
                        Sex.Text = re["Sex"].ToString();
                        Det.Text = System.DateTime.Now.ToShortDateString();
                    }
                    /*Binding To Grid*/
                    reInfo = ViewResult.ShowResult(Session["Id"].ToString(), Session["date"].ToString(), Session["Term"].ToString());
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

                        numPerClass = Convert.ToInt32(NumInClass.Text);
                        studentAverage = totaTotal / numOfStud;
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

        void getPosition()
        {
            List<IdScores> gtScores = (List<IdScores>)Session["ScoreList"];
            List<getResultFromList> positonArray = new List<getResultFromList>();
                int i = 0;
            int index = gtScores.FindIndex(a => a.Id == Session["Id"].ToString());
            lblposition.Text = (index+1).ToString();
            decimal ClassTotal = 0.0M;
            foreach (var result in gtScores)
            {
                ClassTotal += result.scores;
                
                foreach(var posAr in positonArray)
                {
                    posAr.Id = result.Id;
                    posAr.Scores = result.scores;
                    lblposition.Text=posAr.Position = (index + 1).ToString();
                   
                    //Response.Write(posAr.Position);                   
                }
            }
            int x = Convert.ToInt32(NumInClass.Text);
            //classAv.Text = Math.Round(ClassTotal / x, 2).ToString();

            foreach (var pos in positonArray)
            {
                if (pos.Id == Session["Id"].ToString())
                {
                    lblposition.Text = pos.Position;
                }
            }
        }

        void getSchoolPix()
        {
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("getStudSchoolId", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = Session["Id"].ToString();
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

        void keytoRating()
        {
            using (System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand c = new SqlCommand("getKeyToGrading", connection) { CommandType = CommandType.StoredProcedure };
                c.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                connection.Close();
                connection.Open();
                SqlDataAdapter Da = new SqlDataAdapter(c);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                keyToRating.DataSource=Dt;
                keyToRating.DataBind();
                connection.Close();
            }
        }

        protected void keyToRating_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LowLimit = (Label)e.Row.FindControl("Lower");
                LowLimit.Text = LowLimit.Text+" %";

                Label UpperLimit = (Label)e.Row.FindControl("Upper");
                UpperLimit.Text = UpperLimit.Text + " %";
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