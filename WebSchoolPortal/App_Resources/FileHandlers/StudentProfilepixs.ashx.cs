using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebSchoolPortal.App_Resources.FileHandlers
{
    /// <summary>
    /// Summary description for StudentProfilepixs
    /// </summary>
    public class StudentProfilepixs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            // Get the ID for this request.
            string StudentId = context.Request.QueryString["StudentRollNumber"].ToString();

            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                // Create a parameterized command for this record.
                string SQL = "SELECT Passport FROM dbo.StudentRegTab WHERE StudentRollNumber = @StudentRollNumber";
                SqlCommand cmd = new SqlCommand(SQL, con);
                cmd.Parameters.AddWithValue("@StudentRollNumber", StudentId);

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