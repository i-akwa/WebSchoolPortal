using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.Students;
using CodePortal.Project.DbConnection;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Security;
using System.Web.Security;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class StudentArmPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl.BindDefaultClassDropDown(Class);
                SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();
                Master.HeaderLabel = "Edit Class And Arm";
                Insertall.Visible = false;
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
                SqlCommand SelectCommand = new SqlCommand("Select SchoolId from SchoolAdminRegistration Where SchoolEmailAdress=@SchoolEmailAdress", connection);
                SelectCommand.Parameters.AddWithValue("@SchoolEmailAdress", SqlDbType.NVarChar).Value = mail;
                connection.Open();
                SqlDataReader read = SelectCommand.ExecuteReader();
                while (read.Read())
                {
                    SchoolId = read["SchoolId"].ToString();
                }
                connection.Close();
                Session["SchoolId"] = SchoolId;
                return SchoolId;
            }
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (Class.Items.Count>0)
                {
                    Student_studentControl.ClassGrid(Request.Cookies["SchoolId"].Value, Class.SelectedValue.ToString(), GridView1);
                    
                    if (GridView1.Rows.Count > 1)
                    {

                        Insertall.Visible = true;
                    }
                    if (GridView1.Rows.Count == 1)
                    {
                        Insertall.Visible = false;
                    }
                }
                else
                {
                    string message = "Please Select Class";
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
            catch(NullReferenceException nulex)
            {
                string message = "Please filll in all textboxes";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
            catch(NoNullAllowedException nonullex)
            {
                string message = "Please filll in all textboxes";
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

        protected void Insertall_Click(object sender, System.EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    foreach (GridViewRow grv in GridView1.Rows)
                    {
                        string rollNum = grv.Cells[0].Text;
                        string presClass = grv.Cells[2].Text;
                        string newClas = (grv.Cells[3].FindControl("ddlClasses") as DropDownList).SelectedItem.Text;
                        int newArms = Convert.ToInt32((grv.Cells[4].FindControl("Arms") as DropDownList).SelectedValue);

                        SqlCommand command = new SqlCommand("UpdateClassArm", connection) { CommandType = CommandType.StoredProcedure };
                        command.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = newClas.ToString();
                        command.Parameters.AddWithValue("@Armid", SqlDbType.Int).Value = Convert.ToInt32(newArms);
                        command.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = rollNum;
                        command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Student_studentControl.ClassGrid(Request.Cookies["SchoolId"].Value, Class.SelectedItem.Text.ToString(), GridView1);
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

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                string comName = e.CommandName;
                string rollNumber = e.CommandArgument.ToString();

                if (comName.Equals("Ins"))
                {
                    //Getting the row index of a grid view where the clicked link is
                    GridViewRow linkRow = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                    int rowIndex = linkRow.RowIndex;
                    //Convert.ToInt32(GridView1.SelectedRow.DataItemIndex);
                    string rollNum = GridView1.Rows[rowIndex].Cells[0].Text;
                    string presClass = GridView1.Rows[rowIndex].Cells[2].Text;
                    string newClas = (GridView1.Rows[rowIndex].Cells[3].FindControl("ddlClasses") as DropDownList).SelectedValue.ToString();
                    string newArms = (GridView1.Rows[rowIndex].Cells[4].FindControl("Arms") as DropDownList).SelectedValue;

                    SqlCommand command = new SqlCommand("UpdateClassArm", connection) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = newClas.ToString();
                    command.Parameters.AddWithValue("@Armid", SqlDbType.Int).Value = Convert.ToInt32(newArms);
                    command.Parameters.AddWithValue("@StudentRollNum", SqlDbType.NVarChar).Value = rollNum;
                    command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Student_studentControl.ClassGrid(Request.Cookies["SchoolId"].Value, Class.SelectedItem.Text.ToString(), GridView1);
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
        }

        protected void ClasCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClasCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Adt = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    Adt.Fill(DT);
                    
                        Class.Items.Clear();
                        Class.DataSource = DT;
                        Class.DataValueField = "ClassId";
                        Class.DataTextField = "class";
                        Class.DataBind();
                   
                }
            }

            else if (ClasCheck.Checked == false)
            {
                BindControl.BindDefaultClassDropDown(Class);

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType==DataControlRowType.DataRow && ClasCheck.Checked==false)
            {
                DropDownList DDL = (DropDownList)e.Row.FindControl("ddlClasses");
                BindControl.BindDefaultClassDropDown(DDL);
                DDL.Items.FindByValue(Class.SelectedValue).Selected = true;
            }
            if (e.Row.RowType == DataControlRowType.DataRow && ClasCheck.Checked == true)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    DropDownList DDL = (DropDownList)e.Row.FindControl("ddlClasses");
                    con.Open();
                    SqlDataAdapter ADT = new SqlDataAdapter(cmd);
                    DataTable DT = new DataTable();
                    ADT.Fill(DT);
                    
                        DDL.Items.Clear();
                        DDL.DataSource = DT;
                        DDL.DataValueField = "ClassId";
                        DDL.DataTextField = "class";
                        DDL.DataBind();
                        DDL.Items.FindByValue(Class.SelectedValue).Selected = true;
                    
                }
            }

        }
        
    }
    
}