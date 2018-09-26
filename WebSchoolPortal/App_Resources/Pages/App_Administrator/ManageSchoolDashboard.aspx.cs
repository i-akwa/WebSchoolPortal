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
using System.Web.Security;
using System.Collections;
using System.Text.RegularExpressions;
using CodePortal.Project.School_Admin;

namespace WebSchoolPortal.App_Resources.Pages.App_Administrator
{
    public partial class ManageSchoolDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindUsersToGrid();
            if (!IsPostBack)
            {
                Reapeater();
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand selcom = new SqlCommand("CountToDashBoard", connection) { CommandType = CommandType.StoredProcedure };
                    connection.Open();
                    SqlDataReader re = selcom.ExecuteReader();
                    while (re.Read())
                    {
                        TotalSchools.Text = re["RegisteredSchools"].ToString();
                        TotalStudents.Text = re["RegisteredStudents"].ToString();
                    }
                    connection.Close();
                }
                getStudent();
            }
        }

        private void getStudent()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand selcom = new SqlCommand("GetTop20Student", connection) { CommandType = CommandType.StoredProcedure };
                    connection.Open();
                    SqlDataReader read = selcom.ExecuteReader();
                    LatestStudent.DataSource=read;
                    LatestStudent.DataBind();
                    connection.Close();
                }
                catch( Exception ex)
                {
                    string messag = ex.Message;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(messag);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
            }
        }

        protected void activeSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (e.CommandName == "act")
                    {
                        foreach (GridViewRow gvr in activeSchool.Rows)
                        {
                            GridViewRow roll = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                            int rowIndex = roll.RowIndex;
                            string schoolName = activeSchool.Rows[rowIndex].Cells[0].Text;
                            string Pnumber = activeSchool.Rows[rowIndex].Cells[3].Text;
                            LinkButton aprv = (LinkButton)gvr.FindControl("isApproved");
                            string user = Membership.GetUserNameByEmail(e.CommandArgument.ToString());
                            MembershipUser validUser = Membership.GetUser(user);
                            if (validUser.IsApproved==true)
                            {
                                validUser.IsApproved = false;
                                Membership.UpdateUser(validUser);
                                string message = "Dear " + schoolName + ",your Automated-School account have been deactivated, please contact us: 08182477691,08163565026 ";
                                SendSMS SendExams = new SendSMS();
                                SendExams.PostRequestSMS(message, Pnumber, "A488-7-PRV");
                                string me = "Messages sent successfuly. to" + Pnumber;
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<script type = 'text/javascript'>");
                                sb.Append("window.onload=function(){");
                                sb.Append("alert('");
                                sb.Append(me);
                                sb.Append("')};");
                                sb.Append("</script>");
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                                break;
                            }
                             if (validUser.IsApproved ==false)
                            {
                                validUser.IsApproved = true;
                                Membership.UpdateUser(validUser);
                                string message = "Dear " + schoolName + ", your Automated-School account have been activated, you can now login and enjoy our services ";
                                SendSMS SendExams = new SendSMS();
                                SendExams.PostRequestSMS(message, Pnumber, "A488-7-PRV");
                                string me = "Messages sent successfuly.";
                                StringBuilder sb = new StringBuilder();
                                sb.Append("<script type = 'text/javascript'>");
                                sb.Append("window.onload=function(){");
                                sb.Append("alert('");
                                sb.Append(me);
                                sb.Append("')};");
                                sb.Append("</script>");
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                                break;
                            }
                        }
                    }
                    BindUsersToGrid();
                }
                catch (Exception ex)
                {
                    string me = ex.Message;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(me);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
            }
        }

        private void Reapeater()
        {
            string[] filterOptions = { "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            SortReapeater.DataSource = filterOptions;
            SortReapeater.DataBind();
        }

        private void BindUsersToGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectSchoolAdmins", connection) { CommandType = CommandType.StoredProcedure };
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable tab = new DataTable();
                    da.Fill(tab);
                    activeSchool.DataSource = tab;
                    activeSchool.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string messag = ex.Message;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(messag);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
            }

        }



    }
}