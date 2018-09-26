using CodePortal.Project.BindControls;
using CodePortal.Project.DbConnection;
using CodePortal.Project.School_Admin;
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

namespace WebSchoolPortal.App_Resources.Pages.General
{
    //Testing Git
    public partial class AccessmentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.HeaderLabel = "Fill Scores";
                BindSubject();
                BindControl.BindDefaultClassDropDown(Classselect);
                SchoolId.Text = Request.Cookies["TESchoolId"].Value;
                FillersID.Text = GetTeacherId();
               // Date.Text = System.DateTime.Now.ToShortDateString();
                Insert.Visible = false;
            }
        }

        void BindSubject()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand sqlcom = new SqlCommand("GetTeacherSubject", connection) { CommandType = CommandType.StoredProcedure };
                sqlcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                sqlcom.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = GetTeacherId();
                connection.Open();
                SqlDataAdapter sqlAd = new SqlDataAdapter(sqlcom);
                DataTable DT = new DataTable();
                sqlAd.Fill(DT);
                if(DT!=null)
                {
                    Subject.DataSource = DT;
                    Subject.DataTextField = "SubjectName";
                    Subject.DataValueField = "SubjectID";
                    Subject.DataBind();
                }
               
            }
        }

        private String getSchoolId()
        {
            string SchoolId = "";
            string userName = Session["UserName"].ToString();
            MembershipUser loggedInUser = Membership.GetUser(userName);
            string mail = loggedInUser.Email;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand SelectCommand = new SqlCommand("Select SchoolId from TeacherTab Where EmailAdress=@SchoolEmailAdress", connection);
                SelectCommand.Parameters.AddWithValue("@SchoolEmailAdress", SqlDbType.NVarChar).Value = mail;
                connection.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    SchoolId = read["SchoolId"].ToString();
                }
                connection.Close();
                return SchoolId;
            }
        }

        private String GetTeacherId()
        {
            string TeacherId = "";
            string userName = Membership.GetUser().UserName;
            MembershipUser loggedInUser = Membership.GetUser(userName);
            Guid id = (Guid)loggedInUser.ProviderUserKey;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                
                SqlCommand SelectCommand = new SqlCommand("Select TeacherRollId from TeacherTab Where UserId=@UserId", connection);
                SelectCommand.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = id;
                connection.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    TeacherId = read["TeacherRollId"].ToString();
                }
                connection.Close();
                Session["TeacherRollId"] = TeacherId;
                return TeacherId;
            }
        }

        protected void StudentSearch_Click(object sender, EventArgs e)
        {
            StudentSearch_Search();
            if (FillScores.Rows.Count > 0)
            {
                Insert.Visible = true;
            }
            if (FillScores.Rows.Count < 0)
            {
                Insert.Visible = false;
            }
        }

        protected void ClassSearch_Search()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selectComand = new SqlCommand("select FirstName,LastName,StudentRollNumber,PresentClass From StudentRegTab where PresentClass=@PresentClass and Armsid=@ArmsId and SchoolId=@SchoolId order by FirstName asc", connection);
                selectComand.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = Classselect.SelectedValue.ToString();
                selectComand.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = arms.SelectedItem.Value;
                selectComand.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                connection.Open();
                SqlDataReader reader = selectComand.ExecuteReader();
                FillScores.DataSource = reader;
                FillScores.DataBind();
                connection.Close();
            }
        }


        protected void StudentSearch_Search()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selectComand = new SqlCommand("select FirstName,LastName,StudentRollNumber,PresentClass From StudentRegTab where StudentRollNumber=@StudentRollNumber and SchoolId=@SchoolId ", connection);
                selectComand.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = StudentId.Text;
                selectComand.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                connection.Open();
                SqlDataReader reader = selectComand.ExecuteReader();
                FillScores.DataSource = reader;
                FillScores.DataBind();
                connection.Close();

            }
        }

        protected void ClassSearch_Click(object sender, EventArgs e)
        {
            ClassSearch_Search();

            if (FillScores.Rows.Count > 1)
            {
                Insert.Visible = true;
            }
            if (FillScores.Rows.Count == 1)
            {
                Insert.Visible = false;
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    #region
                    if (Entry.SelectedItem.Text == "Test" && Date.Text != "" )
                    {
                        foreach (GridViewRow gvr in FillScores.Rows)
                        {
                            int numbersOfStudent = FillScores.Rows.Count;
                            string RollNum = gvr.Cells[0].Text;
                            string FName = gvr.Cells[1].Text;
                            string LName = gvr.Cells[2].Text;
                            decimal Scores = Convert.ToDecimal((gvr.Cells[3].FindControl("Scores") as TextBox).Text);
                            TextBox TxtScores = gvr.Cells[3].FindControl("Scores") as TextBox;

                            SqlCommand selcom = new SqlCommand("InsertTestScores", connection) { CommandType = CommandType.StoredProcedure };
                            selcom.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = SchoolId.Text;
                            selcom.Parameters.AddWithValue("@FillersID", SqlDbType.NVarChar).Value = FillersID.Text;
                            selcom.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = Convert.ToDateTime(Date.Text);
                            selcom.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FName;
                            selcom.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LName;
                            selcom.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = RollNum;
                            selcom.Parameters.AddWithValue("@SublectName", SqlDbType.NVarChar).Value = Subject.SelectedItem.Text;
                            selcom.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term.SelectedItem.Text;
                            selcom.Parameters.AddWithValue("@TestType", SqlDbType.NVarChar).Value = TestType.Text;
                            selcom.Parameters.AddWithValue("@Scores", SqlDbType.Decimal).Value = Scores;
                            selcom.Parameters.AddWithValue("@ClassId", SqlDbType.Int).Value = Convert.ToInt32(Classselect.SelectedItem.Value);
                            selcom.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(arms.SelectedItem.Value);

                            connection.Open();
                            selcom.ExecuteNonQuery();
                            connection.Close();

                            string mess = "Record Inserted successfully";
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");
                            sb.Append("alert('");
                            sb.Append(mess);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                            TxtScores.Text = "";
                        }

                        #region
                        //if (Entry.SelectedIndex != 0)
                        //{
                        //    SqlCommand SmsTest = new SqlCommand("Select testTable.StudentRollNum, testTable.Date, testTable.SublectName, testTable.Scores, testTable.FirstName, testTable.TestType, StudentRegTab.GuidiancePhoneNo, StudentRegTab.PresentClass, StudentRegTab.Armsid from testTable Left Outer join StudentRegTab on testTable.StudentRollNum=StudentRegTab.StudentRollNumber where testTable.Date = CONVERT(Varchar(11),@date) and StudentRegTab.PresentClass=@class and StudentRegTab.Armsid=@arms", connection);
                        //    SmsTest.Parameters.AddWithValue("@date", SqlDbType.Date).Value = Convert.ToDateTime(Date.Text);
                        //    SmsTest.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = Classselect.Text;
                        //    SmsTest.Parameters.AddWithValue("@arms", SqlDbType.Int).Value = arms.SelectedItem.Value;
                        //    connection.Open();
                        //    int i = 0;
                        //    SqlDataReader reader = SmsTest.ExecuteReader();
                        //    while (reader.Read())
                        //    {
                        //        string testtype = reader["TestType"].ToString();
                        //        string MobineNo = reader["GuidiancePhoneNo"].ToString();
                        //        string Cls = reader["PresentClass"].ToString();
                        //        string dte = reader["Date"].ToString();
                        //        string scor = reader["Scores"].ToString();
                        //        string roln = reader["StudentRollNum"].ToString();
                        //        string subname = reader["SublectName"].ToString();
                        //        string Name = reader["FirstName"].ToString();
                        //        string message = "Test Record for " + Cls + "\n" + "Test Type: " + testtype + "\n" + "Date: " + dte + "\n" + "Name: " + Name + "\n" + "Roll Number: " + roln + "\n" + "Subject: " + subname + "\n" + "Scores: " + scor + "\n" + "Powered by AutoSchool"; ;
                        //        SendSMS SendExams = new SendSMS();
                        //        SendExams.PostRequestSMS(message, MobineNo, Request.Cookies["SchoolId"].Value);
                        //        Response.Write(i);
                        //        i++;
                        //    }
                        //}
                        #endregion
                    }
                    #endregion
                    #region
                    if (Entry.SelectedItem.Text == "Examination" && Date.Text != "")
                            {
                                foreach (GridViewRow gvr in FillScores.Rows)
                                {
                                    string RollNum = gvr.Cells[0].Text;
                                    string FName = gvr.Cells[1].Text;
                                    string LName = gvr.Cells[2].Text;
                                    decimal Scores = Convert.ToDecimal((gvr.Cells[3].FindControl("Scores") as TextBox).Text);
                                    TextBox TxtScores = gvr.Cells[3].FindControl("Scores") as TextBox;
                                    SqlCommand insertCommand = new SqlCommand("InsertExamScores", connection) { CommandType = CommandType.StoredProcedure };
                                    insertCommand.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = SchoolId.Text;
                                    insertCommand.Parameters.AddWithValue("@FillersID", SqlDbType.NVarChar).Value = FillersID.Text;
                                    insertCommand.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = Convert.ToDateTime(Date.Text);
                                    insertCommand.Parameters.AddWithValue("@StudentName", SqlDbType.NVarChar).Value = FName + " " + LName;
                                    insertCommand.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = RollNum;
                                    insertCommand.Parameters.AddWithValue("@SubjectName", SqlDbType.NVarChar).Value = Subject.SelectedItem.Text;
                                    insertCommand.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term.SelectedItem.Text;
                                    insertCommand.Parameters.AddWithValue("@ExamsScores", SqlDbType.NVarChar).Value = Scores;
                                    insertCommand.Parameters.AddWithValue("@ClassId", SqlDbType.Int).Value = Convert.ToInt32(Classselect.SelectedItem.Value);
                                    insertCommand.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(arms.SelectedItem.Value);

                                    connection.Open();
                                    insertCommand.ExecuteNonQuery();
                                    connection.Close();
                                    TxtScores.Text = "";
                                }
                                string messag = "Record Inserted successfully";
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<script type = 'text/javascript'>");
                                sb.Append("window.onload=function(){");
                                sb.Append("alert('");
                                sb.Append(messag);
                                sb.Append("')};");
                                sb.Append("</script>");
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                                

                                //if (Entry.Text != " ")
                                //{
                                //    SqlCommand cmd = new SqlCommand("Select ExamsTable.StudentRollNumber, ExamsTable.Date, ExamsTable.SubjectName, ExamsTable.ExamsScores, ExamsTable.StudentName, StudentRegTab.GuidiancePhoneNo, StudentRegTab.PresentClass, StudentRegTab.Armsid from ExamsTable inner join StudentRegTab on ExamsTable.StudentRollNumber=StudentRegTab.StudentRollNumber where ExamsTable.Date = CONVERT(Varchar(11),@date) and StudentRegTab.PresentClass=@class and StudentRegTab.Armsid=@arms and ExamsTable.SubjectName=@subject ", connection);
                                //    cmd.Parameters.AddWithValue("@date", SqlDbType.Date).Value = Convert.ToDateTime(Date.Text);
                                //    cmd.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = Classselect.Text;
                                //    cmd.Parameters.AddWithValue("@arms", SqlDbType.Int).Value = arms.SelectedItem.Value;
                                //    cmd.Parameters.AddWithValue("@subject", SqlDbType.NVarChar).Value = Subject.SelectedItem.Text;
                                //    connection.Open();
                                //    SqlDataReader reader = cmd.ExecuteReader();

                                //    while (reader.Read())
                                //    {
                                //        string MobineNo = reader["GuidiancePhoneNo"].ToString();
                                //        string Cls = reader["PresentClass"].ToString();
                                //        string dte = reader["Date"].ToString();
                                //        string scor = reader["ExamsScores"].ToString();
                                //        string roln = reader["StudentRollNumber"].ToString();
                                //        string subname = reader["SubjectName"].ToString();
                                //        string Name = reader["StudentName"].ToString();
                                //        string message = "Examination Record for " + Cls + "\n" + "Date: " + dte + "\n" + "Name: " + Name + "\n" + "Roll Number: " + roln + "\n" + "Subject: " + subname + "\n" + "Scores: " + scor + "\n" + "Powered By Auto-School ";
                                //        SendSMS SendExams = new SendSMS();
                                //        SendExams.PostRequestSMS(message, MobineNo, Request.Cookies["SchoolId"].Value);
                                //    }
                                //}
                            }

                    else
                    {
                        string messag = "Please check the date textbox and make sure ";
                        StringBuilder sb = new StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append(messag);
                        sb.Append("')};");
                        sb.Append("</script>");
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                    }
                    #endregion

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < 2)
            {
                Response.Write(i);
                i++;
            }
        }

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    Classselect.Items.Clear();
                    Classselect.DataSource = Dt;
                    Classselect.DataValueField = "ClassId";
                    Classselect.DataTextField = "class";
                    Classselect.DataBind();
                }
            }
            else if (ClassCheck.Checked == false)
            {
                BindControl.BindDefaultClassDropDown(Classselect);
            }
        }

    }
}