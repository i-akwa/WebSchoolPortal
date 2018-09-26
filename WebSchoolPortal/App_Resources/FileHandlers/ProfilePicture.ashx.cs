using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Configuration;
using CodePortal.Project.DbConnection;
using System.Data;

namespace WebSchoolPortal.App_Resources.FileHandlers
{
    /// <summary>
    /// Summary description for ProfilePicture
    /// </summary>
    public class ProfilePicture : IHttpHandler , System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            // Get the ID for this request.
            string SchoolId = context.Request.QueryString["SchoolId"].ToString();

            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                // Create a parameterized command for this record.
                string SQL = "SELECT ProfilePixs FROM dbo.SchoolAdminRegistration WHERE SchoolId = @SchoolId";
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@SchoolId", SchoolId);

                try
                {
                    con.Open();
                    SqlDataReader r = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                    if (r.Read())
                    {
                        int bufferSize = 100; // Size of the buffer.
                        byte[] bytes = new byte[bufferSize]; // The buffer.
                        long bytesRead; // The # of bytes read.
                        long readFrom = 0; // The starting index.

                        // Read the field 100 bytes at a time.
                        do
                        {
                            bytesRead = r.GetBytes(0, readFrom, bytes, 0, bufferSize);
                            context.Response.BinaryWrite(bytes);
                            readFrom += bufferSize;
                        } while (bytesRead == bufferSize);
                    }
                    r.Close();
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}