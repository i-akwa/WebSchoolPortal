using CodePortal.Project.DbConnection;
using CodePortal.Project.School_Admin;
using CodePortal.Project.Students;
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

namespace WebSchoolPortal.App_Resources.Pages.Teachers
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.HeaderLabel = "STUDENT ATTENDANCE";
                lblDateSticker.Text = Convert.ToString(DateTime.Now.ToShortDateString());

                btnSubmit.Visible = false;

                if (Roles.IsUserInRole("SchoolAdmin"))
                {
                    SchoolId.Text = Request.Cookies["TESchoolId"].Value;
                    using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                    {
                        try
                        {
                            SqlCommand SelectArms = new SqlCommand("select Arm, ArmsId from armsTable where SchoolId=@SchoolId", connection);
                            SelectArms.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["SchoolId"].ToString();
                            connection.Open();
                            SqlDataReader re = SelectArms.ExecuteReader();
                            ddlArm.DataSource = re;
                            ddlArm.DataTextField = "Arm";
                            ddlArm.DataValueField = "ArmsId";
                            ddlArm.DataBind();
                            connection.Close();
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
                else if (System.Web.Security.Roles.IsUserInRole("Teacher"))
                {
                    SchoolId.Text = Request.Cookies["TESchoolId"].Value;
                    using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                    {
                        try
                        {
                            SqlCommand SelectArms = new SqlCommand("select Arm, ArmsId from armsTable where SchoolId=@SchoolId", connection);
                            SelectArms.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["TESchoolId"].Value;
                            connection.Open();
                            SqlDataReader re = SelectArms.ExecuteReader();
                            ddlArm.DataSource = re;
                            ddlArm.DataValueField = "ArmsId";
                            ddlArm.DataTextField = "Arm";
                            ddlArm.DataBind();
                            connection.Close();
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
            }
        }

        protected void grvAtt_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grvAtt.PageIndex = e.NewPageIndex;
                grvAtt.PageIndex = e.NewPageIndex;
            }
            catch (Exception exc)
            {
                string message = exc.Message.ToString();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Student_studentControl.BindAttendance(grvAtt, SchoolId.Text, Convert.ToInt32(ddlArm.SelectedValue), ddlClass.SelectedItem.Text);
            if (grvAtt.Rows.Count == 0)
            {
                btnSubmit.Visible = false;
            }
            else
                btnSubmit.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    foreach (GridViewRow gr in grvAtt.Rows)
                    {
                        string stat;
                        string rolnum = gr.Cells[0].Text;
                        int status = Convert.ToInt32((gr.Cells[2].FindControl("chkStatus") as CheckBox).Checked);

                        if (status == 1)
                        {
                            stat = "Present";
                        }
                        else
                        {
                            stat = "Absent";
                        }

                        SqlCommand newcom = new SqlCommand("InsertStudentAttendance", connection) { CommandType = CommandType.StoredProcedure };
                        newcom.Parameters.AddWithValue("@DaysDate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString();
                        newcom.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = rolnum;
                        newcom.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = stat;
                        newcom.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = ddlClass.SelectedItem.Text;
                        newcom.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(ddlArm.SelectedValue);
                        newcom.Parameters.AddWithValue("@Day", SqlDbType.NVarChar).Value = System.DateTime.Now.DayOfWeek.ToString();
                        newcom.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = SchoolId.Text;

                        connection.Open();
                        newcom.ExecuteNonQuery();
                        connection.Close();
                    }

                        SqlCommand sel_com = new SqlCommand("select Attendance.StudentRollNumber, Attendance.Status, Attendance.DaysDate, StudentRegTab.GuidiancePhoneNo, StudentRegTab.FirstName from Attendance inner join StudentRegTab on Attendance.StudentRollNumber =  StudentRegTab.StudentRollNumber where CONVERT(Varchar(11),Attendance.DaysDate)=CONVERT(Varchar(11),@DaysDate) and Attendance.Class=@class and Attendance.ArmsId=@ArmsId", connection);
                        sel_com.Parameters.AddWithValue("@DaysDate", SqlDbType.DateTime).Value = Convert.ToDateTime(lblDateSticker.Text);
                        sel_com.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = ddlClass.SelectedItem.Text;
                        sel_com.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = Convert.ToInt32(ddlArm.SelectedValue);
                        connection.Open();
                        SqlDataReader re = sel_com.ExecuteReader();
                        while (re.Read())
                        {
                            string mobileNo = re["GuidiancePhoneNo"].ToString();
                            string sta = re["Status"].ToString();
                            string day = re["DaysDate"].ToString();
                            string Nme = re["FirstName"].ToString();
                            string rollno = re["StudentRollNumber"].ToString();
                            string message = "Day: " + day + "\n" + "Name: " + Nme + "\n" + "Roll Number: " + rollno + "\n" + "Attendance: " + sta + "\n" + "Powered by Auto-School";
                            SendSMS Send = new SendSMS();
                            Send.PostRequestSMS(message, mobileNo, Request.Cookies["SchoolId"].Value);
                        }
                        connection.Close();

                }
                catch (Exception exc)
                {
                    string message = exc.Message.ToString();
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
                    string message ="Records Inserted Successfuly";
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

                    ddlClass.Items.Clear();
                    ddlClass.DataSource = Dt;
                    ddlClass.DataValueField = "ClassId";
                    ddlClass.DataTextField = "class";
                    ddlClass.DataBind();
                }
            }
            else if (ClassCheck.Checked == false)
            {
                ddlClass.Items.Clear();
                ddlClass.Items.Add(new ListItem("JSS1"));
                ddlClass.Items.Add(new ListItem("JSS2"));
                ddlClass.Items.Add(new ListItem("JSS3"));
                ddlClass.Items.Add(new ListItem("SSS1"));
                ddlClass.Items.Add(new ListItem("SSS2"));
                ddlClass.Items.Add(new ListItem("SSS3"));
                ddlClass.AppendDataBoundItems = true;
            }
        }
    }
}