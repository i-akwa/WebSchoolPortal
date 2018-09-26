using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Text;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class SubjectTeachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            
            HiddenSubject.Visible = false;
            if (!Page.IsPostBack)
            {
                BindControl.BindDefaultClassDropDown(clas);
                update.Visible = false;
                TeacherId.Items.Add(new ListItem("-Select Id", ""));
                TeacherId.AppendDataBoundItems = true;
                Master.HeaderLabel = "subject_teacher";
            }
        }

        private string getSchoolId()
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

        protected void TeacherId_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand comm = new SqlCommand("GetTeacherName", connection) { CommandType = CommandType.StoredProcedure };
                comm.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = TeacherId.SelectedItem.Text;
                connection.Open();
                SqlDataReader re = comm.ExecuteReader();
                if (re.Read())
                {
                    TeachersName.Text = re["Name"].ToString();
                }
                re.Close();
                connection.Close();

                
            }
        }

        protected void TeachersId_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand ins = new SqlCommand("InsertSubTeach", connection) { CommandType = CommandType.StoredProcedure };
                    ins.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = clas.SelectedValue.ToString();
                    ins.Parameters.AddWithValue("@SubjectID", SqlDbType.Int).Value = Convert.ToInt32(SubjectName.SelectedValue);
                    ins.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = TeacherId.SelectedItem.Text;
                    ins.Parameters.AddWithValue("@TeacherName", SqlDbType.NVarChar).Value = TeachersName.Text;
                    ins.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    

                    connection.Open();
                    ins.ExecuteNonQuery();
                    connection.Close();
                    BindGrid();
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

        void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cd = new SqlCommand("SelSubTeacher", connection) { CommandType = CommandType.StoredProcedure };
                    cd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                    connection.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(cd);
                    DataTable DT = new DataTable();
                    ad.Fill(DT);
                    SubTeach.DataSource = DT;
                    SubTeach.DataBind();
                    connection.Close();
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

        protected void SubTeach_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edt")
            {
                Insert.Visible = false;
                update.Visible = true;
                HiddenSubject.Text = e.CommandArgument.ToString();
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand updt = new SqlCommand("UpdateSubTeachers", connection) { CommandType = CommandType.StoredProcedure };
                    updt.Parameters.AddWithValue("@TeachID", SqlDbType.NVarChar).Value = TeacherId.SelectedItem.Text;
                    updt.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(HiddenSubject.Text);
                    updt.Parameters.AddWithValue("@TeacherName", SqlDbType.NVarChar).Value = TeachersName.Text;
                    updt.Parameters.AddWithValue("@SubjectID", SqlDbType.Int).Value = Convert.ToInt32(SubjectName.SelectedValue);
                    updt.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = clas.SelectedValue.ToString();
                    connection.Open();
                    updt.ExecuteNonQuery();
                    connection.Close();
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
                finally
                {
                    BindGrid();
                    update.Visible = false;
                    Insert.Visible = true;
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

                    clas.Items.Clear();
                    clas.DataSource = DT;
                    clas.DataValueField = "ClassId";
                    clas.DataTextField = "class";
                    clas.DataBind();

                }
            }

            else if (ClasCheck.Checked == false)
            {
                BindControl.BindDefaultClassDropDown(clas);

            }

        }

        protected void SubTeach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SubTeach.PageIndex = e.NewPageIndex;
            SubTeach.DataBind();
        }
    }
}