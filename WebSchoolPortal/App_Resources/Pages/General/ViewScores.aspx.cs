using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using CodePortal.Project.DbConnection;
using System.Web.Services;
using System.Security;
using System.Web.Security;
using CodePortal.Project.Students;
using CodePortal.Project.School_Admin;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class ViewScores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindControl.BindDefaultClassDropDown(cls);
                    Master.HeaderLabel = "View Student Scores";
                    fillSubject();
                    FilYear();
                    pan1.Visible = false;
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                
                string message = "Network Error, please, check conection and try again";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);

            }
            catch (NullReferenceException ex)
            {
               
                string message = "Log out and in again if error persist";
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
                string message = "Contact admin if error persist";
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
        protected void submit_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    if (exams.Checked)
                    {
                        ExamsRecordforView();
                    }
                    if (Test.Checked)
                    {
                        TestRecordForView();
                    }
                }
                catch (Exception ex)
                {
                    string message = "Please Fill The NecessarTy TextBoxes";
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

        protected void ViewScore_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ViewScore.PageIndex = e.NewPageIndex;
            ViewScore.DataBind();
        }

        void fillSubject()
        {
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                if(Roles.IsUserInRole("Teacher"))
                {
                    SqlCommand cmd = new SqlCommand("GetTeacherSubject",con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    cmd.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = GetTeacherId();
                    con.Open();
                    SqlDataAdapter sqlAd = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    sqlAd.Fill(DT);
                    if (DT != null)
                    {
                        subject.DataSource = DT;
                        subject.DataTextField = "SubjectName";
                        subject.DataValueField = "SubjectID";
                        subject.DataBind();
                    }
                }
                else if(Roles.IsUserInRole("SchoolAdmin"))
                {
                    SchoolAdminControl.DisplaySubject(Request.Cookies["SchoolId"].Value, subject);
                }
            }
        }

        private String GetTeacherId()
        {
            string TeacherId = "";
            string userName = Session["UserName"].ToString();
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
                return TeacherId;
            }
        }
        protected void arm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ViewScore_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.Equals("Edt"))
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;

                int index = row.RowIndex;
                txtEditscores.Text = ViewScore.Rows[index].Cells[5].Text;
                hidRollnum.Value = e.CommandArgument.ToString();
                hidSubjectName.Value = ViewScore.Rows[index].Cells[2].Text;
                hidTerm.Value = term.Text;
                hidDate.Value = ddlYear.SelectedItem.Text;
                hidTestType.Value = cat.Text;
                lblNameofStud.Text= ViewScore.Rows[index].Cells[0].Text;
                pan1.Visible = true;
                TablePanel.Visible = false;
            }
        }

        void ExamsRecordforView()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("ViewExamsScores", connection) { CommandType = CommandType.StoredProcedure };//ViewExams
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                selcom.Parameters.AddWithValue("@subjectName", SqlDbType.NVarChar).Value = subject.SelectedItem.Text;
                selcom.Parameters.AddWithValue("@year", SqlDbType.NVarChar).Value = ddlYear.SelectedItem.Text;
                selcom.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term.Text;
                selcom.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = cls.SelectedValue.ToString();
                selcom.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(arm.SelectedItem.Value);
                connection.Open();
                SqlDataAdapter DA = new SqlDataAdapter(selcom);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                ViewScore.DataSource = DT;
                ViewScore.DataBind();
                type.Text = "Exams";
                connection.Close();
            }
            
        }
        void TestRecordForView()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selcom = new SqlCommand("ViewTest", connection) { CommandType = CommandType.StoredProcedure };//ViewTest
                selcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                selcom.Parameters.AddWithValue("@subjectName", SqlDbType.NVarChar).Value = subject.SelectedItem.Text;
                selcom.Parameters.AddWithValue("@year", SqlDbType.NVarChar).Value = ddlYear.SelectedItem.Text;
                selcom.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term.SelectedItem.Text;
                selcom.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = cls.SelectedValue.ToString();
                selcom.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(arm.SelectedItem.Value);
                selcom.Parameters.AddWithValue("@TestType", SqlDbType.NVarChar).Value = cat.SelectedItem.Text;
                connection.Open();
                SqlDataAdapter DA = new SqlDataAdapter(selcom);
                DataTable DT = new DataTable();
                DA.Fill(DT);
                ViewScore.DataSource = DT;
                ViewScore.DataBind();
                type.Text = "Cat" + cat.SelectedItem.Text;
                connection.Close();
            }
        }

        void FilYear()
        {
            int j = Convert.ToInt32(DateTime.Now.Year - 20);
            for(int i=Convert.ToInt32(DateTime.Now.Year); i>= j; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }
        }
        protected void btnEdit_Click1(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                if (Test.Checked)
                {
                    SqlCommand com = new SqlCommand("UPDATE testTable SET Scores=@scores WHERE StudentRollNum=@studentRollNum AND Term=@term AND Date like '%'+@date+'%' AND SublectName=@subject AND TestType=@testType", connection);
                    com.Parameters.AddWithValue("@scores", SqlDbType.Decimal).Value = Convert.ToDecimal(txtEditscores.Text);
                    com.Parameters.AddWithValue("@studentRollNum", SqlDbType.NVarChar).Value = hidRollnum.Value;
                    com.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = hidTerm.Value;
                    com.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = hidDate.Value;
                    com.Parameters.AddWithValue("@subject", SqlDbType.NVarChar).Value = hidSubjectName.Value;
                    com.Parameters.AddWithValue("@testType", SqlDbType.NVarChar).Value = hidTestType.Value;
                    connection.Open();
                    int rowsAffected = com.ExecuteNonQuery();
                    connection.Close();
                    TestRecordForView();
                    pan1.Visible = false;
                    TablePanel.Visible = true;
                }
                //UPDATE ExamsTable SET ExamsScores=64 WHERE StudentRollNumber='AUT519153' AND Term='1' AND Date like '%'+'2017'+'%' AND SubjectName='ENGLISH'
                else if (exams.Checked)
                {
                    SqlCommand com = new SqlCommand("UPDATE ExamsTable SET ExamsScores=@scores WHERE StudentRollNumber=@studentRollNum AND Term=@term AND Date like '%'+@date+'%' AND SubjectName=@subject", connection);
                    com.Parameters.AddWithValue("@scores", SqlDbType.Decimal).Value = Convert.ToDecimal(txtEditscores.Text);
                    com.Parameters.AddWithValue("@studentRollNum", SqlDbType.NVarChar).Value = hidRollnum.Value;
                    com.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = hidTerm.Value;
                    com.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = hidDate.Value;
                    com.Parameters.AddWithValue("@subject", SqlDbType.NVarChar).Value = hidSubjectName.Value;
                    connection.Open();
                    int rowsAffected = com.ExecuteNonQuery();
                    connection.Close();
                    ExamsRecordforView();
                    pan1.Visible = false;
                    TablePanel.Visible = true;
                }
            }
        }

        protected void cls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Test.Checked==true)
            {
                TestRecordForView();
            }
            if(exams.Checked==true)
            {
                ExamsRecordforView();
            }
        }

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    if (Dt != null)
                    {
                        cls.Items.Clear();
                        cls.DataSource = Dt;
                        cls.DataValueField = "ClassId";
                        cls.DataTextField = "class";
                        cls.DataBind();
                    }
                    else if (Dt == null)
                    {
                        string message = "Please go to settings and input classes if you are a nusery/primary school.";
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
            else if (ClassCheck.Checked == false)
            {
                cls.Items.Clear();
                BindControl.BindFeesClassDropDown(cls);
            }
        }
    }
}