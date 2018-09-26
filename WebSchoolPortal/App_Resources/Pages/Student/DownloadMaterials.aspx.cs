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
    public partial class DownloadMaterials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand sel = new SqlCommand("getDownloadsToGrid", connection) { CommandType = CommandType.StoredProcedure };
                sel.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = getSchoolId();
                sel.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = getClass();
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(sel);
                DataTable Dt = new DataTable();
                ad.Fill(Dt);
                DownloadGrid.DataSource = Dt;
                DownloadGrid.DataBind();
                connection.Close();
            }
        }

        private string getSchoolId()
        {
            string ID = "";
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("Select SchoolId from StudentRegTab where StudentRollNumber=@StudentRollNumber", connection);
                com.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = GetStudentId();

                connection.Open();
                SqlDataReader re = com.ExecuteReader();
                while (re.Read())
                {
                    ID = re["SchoolId"].ToString();
                }
                connection.Close();
                return ID;
            }
        }

        private string getClass()
        {
            string Klass = "";
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("Select PresentClass from StudentRegTab where StudentRollNumber=@StudentRollNumber", connection);
                com.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = GetStudentId();

                connection.Open();
                SqlDataReader re = com.ExecuteReader();
                while (re.Read())
                {
                    Klass = re["PresentClass"].ToString();
                }
                connection.Close();
                return Klass;
            }

        }

        private String GetStudentId()
        {
            string StudentId = "";
            string userName = Session["UserName"].ToString();
            MembershipUser loggedInUser = Membership.GetUser(userName);
            string mail = loggedInUser.Email;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand SelectCommand = new SqlCommand("Select StudentRollNumber from StudentRegTab Where EmailAdress=@EmailAdress", connection);
                SelectCommand.Parameters.AddWithValue("@EmailAdress", SqlDbType.NVarChar).Value = mail;
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

        protected void DownloadGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            if (e.CommandName == "dwn")
            {
                using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand com = new SqlCommand("Select OriginalName,FileData,FileType From UploadTable where UploadId=@UploadId", connection);
                    com.Parameters.AddWithValue("@UploadId", SqlDbType.Int).Value = id;
                    connection.Open();
                    using (SqlDataReader re = com.ExecuteReader())
                    {
                        re.Read();
                        bytes = (byte[])re["FileData"];
                        contentType = re["FileType"].ToString();
                        fileName = re["OriginalName"].ToString();
                    }
                    connection.Close();
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }

        }


        public void DeleteUsers()
        {
            //#region
            //List<string> names = new List<string>();
            //names.Add("HEZ4845481");
            //names.Add("HEZ5093486");
            //names.Add("HEZ8978419");
            //names.Add("HEZ7277482");
            //names.Add("HEZ4701483");
            //names.Add("HEZ1117428");
            //names.Add("HEZ8770442");
            //names.Add("HEZ8269438");
            //names.Add("HEZ7403444");
            //names.Add("HEZ6698213");
            //names.Add("HEZ5958424");
            //names.Add("HEZ6075421");
            //names.Add("HEZ3687429");
            //names.Add("HEZ1224474");
            //names.Add("HEZ1575473");
            //names.Add("HEZ2627476");
            //names.Add("HEZ7785469");
            //names.Add("HEZ7397458");
            //names.Add("HEZ2188450");
            //names.Add("HEZ5771459");
            //names.Add("HEZ6083448");
            //names.Add("HEZ1033449");
            //names.Add("HEZ9362300");
            //names.Add("HEZ3519297");
            //names.Add("HEZ1746245");
            //names.Add("HEZ185244");
            //names.Add("HEZ3413299");
            //names.Add("HEZ1037301");
            //names.Add("HEZ9707298");
            //names.Add("HEZ9800409");
            //names.Add("HEZ3797417");
            //names.Add("HEZ2656412");
            //names.Add("HEZ3041411");
            //names.Add("HEZ1583400");
            //names.Add("HEZ9664414");
            //names.Add("HEZ3330390");
            //names.Add("HEZ6550381");
            //names.Add("HEZ6750376");

            //#endregion
            //string[] nameList = names.ToArray();
            //List<string> newName = new List<string>();

            //#region
            //using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            //{
            //    for (int i = 0; i < nameList.Length; i++)
            //    {
            //        SqlCommand com = new SqlCommand("Select UserId From StudentRegTab where StudentRollNumber=@StudentRollNumber", con);
            //        SqlCommand cmd = new SqlCommand("Delete StudentRegTab where StudentRollNumber=@StudentRollNumber", con);
            //        SqlCommand cmp = new SqlCommand("Delete ExamsTable where StudentRollNumber=@StudentRollNumber", con);
            //        SqlCommand cmt = new SqlCommand("Delete testTable where StudentRollNum=@StudentRollNumber", con);


            //        cmd.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = nameList[i];
            //        cmp.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = nameList[i];
            //        cmt.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = nameList[i];
            //        com.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = nameList[i];
            //        con.Open();
            //        SqlDataReader re = com.ExecuteReader();
            //        if (re.Read())
            //        {
            //            newName.Add(re["UserId"].ToString());
            //        }
            //        con.Close();
                    
            //        con.Open();
            //        var resl = cmp.ExecuteNonQuery();
            //        con.Close();

            //        con.Open();
            //        var res = cmt.ExecuteNonQuery();
            //        con.Close();

            //        con.Open();
            //        var ra = cmd.ExecuteNonQuery();
            //        con.Close();

            //    }

            //    foreach (var name in newName)
            //    {
            //        var result=Membership.DeleteUser(name);
                    
            //    }
            //}
            //#endregion
        }

        //protected void DeleteThem_Click(object sender, EventArgs e)
        //{
        //    DeleteUsers();
        //}
    }
}