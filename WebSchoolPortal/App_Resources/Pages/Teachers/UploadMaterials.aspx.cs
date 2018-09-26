using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.Pages.Teachers
{
    public partial class UploadMaterials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            clas.AppendDataBoundItems = true;
            BindSubject();
           // FileName.Text=clas.SelectedItem.Text +"-"+GetTeacherId()+"-"+Subject.SelectedItem.Text;
            BindGrid();
        }

        private String GetTeacherId()
        {
            string TeacherId = "";
            try
            {
                string userName = Session["UserName"].ToString();
                MembershipUser loggedInUser = Membership.GetUser(userName);
                string mail = loggedInUser.Email;
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand SelectCommand = new SqlCommand("Select TeacherRollId from TeacherTab Where EmailAdress=@TeacherEmailAdress", connection);
                    SelectCommand.Parameters.AddWithValue("@TeacherEmailAdress", SqlDbType.NVarChar).Value = mail;
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
            catch (NullReferenceException null_ex)
            {
                Response.Redirect("~/App_Resources/Pages/Anonymous/Login.aspx");
            }
            return TeacherId;
           
        }

        void BindSubject()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand sqlcom = new SqlCommand("GetTeacherSubject", connection) { CommandType = CommandType.StoredProcedure };
                sqlcom.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                sqlcom.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = GetTeacherId();
                connection.Open();
                SqlDataAdapter sqlAdapt = new SqlDataAdapter(sqlcom);
                DataTable DatTab = new DataTable();
                sqlAdapt.Fill(DatTab);
                Subject.DataSource = DatTab;
                Subject.DataTextField = "SubjectName";
                Subject.DataValueField = "SubjectID";
                Subject.DataBind();
                connection.Close();
            }
        }

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(Upload1.PostedFile.FileName);
            string contentType = Upload1.PostedFile.ContentType;
            using (Stream fs = Upload1.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes= br.ReadBytes((Int32)fs.Length);
                    using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                    {
                        SqlCommand cmd = new SqlCommand("UploadFile", connection) { CommandType = CommandType.StoredProcedure };
                        cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value;
                        cmd.Parameters.AddWithValue("@class",SqlDbType.NVarChar).Value= clas.SelectedItem.Text;
                        cmd.Parameters.AddWithValue("@Subject",SqlDbType.Int).Value= Subject.SelectedValue;
                        cmd.Parameters.AddWithValue("@UploadDate",SqlDbType.Date).Value= Convert.ToDateTime(System.DateTime.Now.Date);
                        cmd.Parameters.AddWithValue("@FileType",SqlDbType.NVarChar).Value= contentType;
                        cmd.Parameters.AddWithValue("@FileData", SqlDbType.VarBinary).Value = bytes;
                        cmd.Parameters.AddWithValue("@Filename", SqlDbType.NVarChar).Value = FileName.Text;
                        cmd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = Description.Text;
                        cmd.Parameters.AddWithValue("@OriginalName", SqlDbType.NVarChar).Value = fileName;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        BindGrid();
                    }
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("getUploadsToGrid", connection) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@TeacherId", SqlDbType.NVarChar).Value = GetTeacherId();
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    da.Fill(Dt);
                    MyUPloads.DataSource = Dt;
                    MyUPloads.DataBind();
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

        protected void clas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(clas.SelectedIndex!=0)
            FileName.Text = clas.SelectedItem.Text + "-" + GetTeacherId() + "-" + Subject.SelectedItem.Text;
        }

        protected void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileName.Text = clas.SelectedItem.Text + "-" + GetTeacherId() + "-" + Subject.SelectedItem.Text;
        }

        protected void MyUPloads_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "del")
            {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand com = new SqlCommand("Delete UploadTable where UploadId=@UploadId", connection);
                    com.Parameters.AddWithValue("@UploadId", SqlDbType.Int).Value = id;
                    connection.Open();
                    com.ExecuteNonQuery();
                    connection.Close();
                    BindGrid();
                }
            }
        }

    }
}