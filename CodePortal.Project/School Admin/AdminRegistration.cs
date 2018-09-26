using CodePortal.Project.GenericList;
using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Security;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Net;

namespace CodePortal.Project.School_Admin
{
    public class AdminRegistration
    {
        public byte[] ProfilePicture { get; set; }
        public int id { get; set; }
        public string SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string AdminSurName { get; set; }
        public string AdminOtherNames{get; set;}
        public string StreetName { get; set; }
        public int LocalGovId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string SchoolEmail { get; set; }
        public string gender { get; set; }
        public DateTime LastEditedOn { get; set; }
        public string postalCode { get; set; }
        public string password { get; set; }
        public string LGA { get; set; }
    }


    public class SchoolAdminControl
    {
        public static int addNewSchoolAdmin(string SchoolId, Guid UserId, string SchoolName, string AdminSurName, string AdminOtherNames, string StreetName, int LocalGovId, DateTime RegistrationDate, string AdminPhoneNumber, string SchoolEmail, string gender, string postalCode)
        {
            int rolesAffected = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("RegisterNewSchoolAdmin", connect) { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
                command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                command.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = SchoolName;
                command.Parameters.AddWithValue("@AdminSurName", SqlDbType.NVarChar).Value = AdminSurName;
                command.Parameters.AddWithValue("@AdminOtherNames", SqlDbType.NVarChar).Value = AdminOtherNames;
                command.Parameters.AddWithValue("@StreetName", SqlDbType.NVarChar).Value = StreetName;
                command.Parameters.AddWithValue("@LgaId", SqlDbType.Int).Value = LocalGovId;
                command.Parameters.AddWithValue("@RegistrationDate", SqlDbType.DateTime).Value = RegistrationDate;
                command.Parameters.AddWithValue("@SchoolPhoneNumber", SqlDbType.NVarChar).Value = AdminPhoneNumber;
                command.Parameters.AddWithValue("@SchoolEmailAdress", SqlDbType.NVarChar).Value = SchoolEmail;
                command.Parameters.AddWithValue("@SchoolPostalCode", SqlDbType.NVarChar).Value = postalCode;
                command.Parameters.AddWithValue("@Gender", SqlDbType.NVarChar).Value = gender;

                try
                {
                    connect.Open();
                    rolesAffected = command.ExecuteNonQuery();
                    UploadDefaultThumbnail(SchoolId);
                    connect.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return rolesAffected;
        }

        static int UploadDefaultThumbnail(string SchoolId)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    connection.Open();

                    var files = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/App_Resources/images/DefaultProfilePic"));
                    foreach (var file in files)
                    {   
                        var data = File.ReadAllBytes(file);
                        var fileName = Path.GetFileName(file);
                        SqlCommand cmd = new SqlCommand("UploadDefaultThumbnail", connection) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.Add("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                        cmd.Parameters.Add("@ProfilePixs", SqlDbType.VarBinary).Value = data;

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
            }

            return rowsAffected;
        }

        public static AdminInfoData<AdminRegistration> GetSchoolAdmin(string SchoolId)
        {
            AdminInfoData<AdminRegistration> accessors = new AdminInfoData<AdminRegistration>();
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("GetSchoolAdminProfile", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AdminRegistration access = new AdminRegistration();
                        access.SchoolId =reader["SchoolId"].ToString();
                        access.AdminOtherNames = reader["AdminOtherNames"].ToString();
                        access.SchoolName = reader["SchoolName"].ToString();
                        access.SchoolEmail = reader["SchoolEmailAdress"].ToString();
                        access.RegistrationDate = (DateTime)reader["RegistrationDate"];
                        access.AdminSurName = reader["AdminSurName"].ToString();
                        access.AdminPhoneNumber = reader["SchoolPhoneNumber"].ToString();
                        access.StreetName = reader["StreetName"].ToString();
                        access.postalCode = reader["SchoolPostalCode"].ToString();
                        access.ProfilePicture = (byte[])reader["ProfilePixs"];
                        access.LGA = reader["LGA"].ToString();
                        accessors.Add(access);
                    }

                    reader.Close();
                }
                catch
                {
                    throw;
                }
            }
            return accessors;
        }

/**Updating Profile Picture**/
        public static int UpdateProfilePicture(string SchoolId, BinaryReader br, int inputStreamLength)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                using (br)
                {
                    SqlCommand command = new SqlCommand("UpdateProfilePicture", connection) { CommandType = CommandType.StoredProcedure };

                    command.Parameters.Add("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;

                    //create byte[] of length equal to the inputstream of the selected image
                    byte[] imageByte = br.ReadBytes(inputStreamLength);

                    command.Parameters.AddWithValue("@ProfilePixs", imageByte);
                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return rowsAffected;
        }

        public static int updateSchoolAdminProfile(string SchoolId, string SchoolName, string AdminSurName, string AdminOtherNames, string ContactAdress, string SchoolPhoneNumber, string SchoolPostalCode, string gender, int LgaId)
        {
            int rollAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("UpdateSchoolAdminProfile", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                command.Parameters.AddWithValue("@SchoolName", SqlDbType.NVarChar).Value = SchoolName;
                command.Parameters.AddWithValue("@AdminSurName", SqlDbType.NVarChar).Value = AdminSurName;
                command.Parameters.AddWithValue("@AdminOtherNames", SqlDbType.NVarChar).Value = AdminOtherNames;
                command.Parameters.AddWithValue("@StreetName", SqlDbType.NVarChar).Value = ContactAdress;
                command.Parameters.AddWithValue("@SchoolPhoneNumber", SqlDbType.NVarChar).Value = SchoolPhoneNumber;
                command.Parameters.AddWithValue("@LGID", SqlDbType.Int).Value = LgaId;
                command.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = gender;
                command.Parameters.AddWithValue("@PostCode", SqlDbType.NVarChar).Value = SchoolPostalCode;

                try
                {
                    connection.Open();
                    rollAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch
                {
                    throw;
                }
            }
            return rollAffected;
        }

        /**Registering New subjects:controling Subject Mangment Page **/

        public static int RegSubject(string SchoolId, string subjectName)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand regTeacher = new SqlCommand("RegSubject", connection) { CommandType = CommandType.StoredProcedure };
                regTeacher.Parameters.AddWithValue("@schoolId",SqlDbType.NVarChar).Value=SchoolId;
                regTeacher.Parameters.AddWithValue("@subjectName", SqlDbType.NVarChar).Value = subjectName;
                try
                {
                    connection.Open();
                    rowsAffected = regTeacher.ExecuteNonQuery();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
            return rowsAffected;
        }

        /***Display Subject in grid:: Part of subject Mangment Page***/
        public static int DisplaySubject(string schoolId, System.Web.UI.WebControls.GridView a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand getSubject = new SqlCommand("GetSubjects", connection) { CommandType = CommandType.StoredProcedure };
                    getSubject.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = schoolId;
                    connection.Open();
                    SqlDataReader read = getSubject.ExecuteReader();
                    a.DataSource = read;
                    a.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rowsAffected; 
        }

        public static int DisplaySubject(string schoolId, System.Web.UI.WebControls.DropDownList a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand getSubject = new SqlCommand("GetSubjects", connection) { CommandType = CommandType.StoredProcedure };
                    getSubject.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = schoolId;
                    connection.Open();
                    SqlDataReader read = getSubject.ExecuteReader();
                    a.DataSource = read;
                    a.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rowsAffected;
        }
    }


    public class SendSMS
    {
        private const string sms_username = "smartschool";
        private const string sms_password = "EmperorcodeX";

        public string responseFromServer;

        public string PostRequestSMS(string message, string mobileno, string SchoolId)
        {
            string sms_SenderName = GetSchoolName(SchoolId);
            try
            {
                string msg = "username=" + sms_username + "&password=" +
                sms_password + "&sender=" + sms_SenderName +
                "&recipient=" + mobileno + "&message=" + message;

                // Create a request using a URL that can receive a post. 

                WebRequest request = WebRequest.Create("http://api.smartsmssolutions.com/smsapi.php?" + sms_username + "&password=" + sms_password + "&sender=" + sms_SenderName + "&recipient=" + mobileno + "&message=" + message);
                // Set the Method property of the request to POST.
                request.Method = "POST";

                // Create POST data and convert it to a byte array.
                string postData = msg;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";

                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;

                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                dataStream = response.GetResponseStream();

                // Open the stream using a StreamReader for easy access.
                StreamReader readerst = new StreamReader(dataStream);

                // Read the content.
                responseFromServer = readerst.ReadToEnd();

                readerst.Close();
                // reader.Close();
                dataStream.Close();
                response.Close();

                return responseFromServer;
            }
            catch
            {
                throw;
            }
        }

        public string GetSchoolName( string Sid)
        {
            string sName = "";
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("GetSchoolName", connect) { CommandType = CommandType.StoredProcedure } ;
                com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Sid;

                connect.Open();
                SqlDataReader re = com.ExecuteReader();
                if (re.Read())
                {
                    sName = re["SchoolName"].ToString();
                }
                connect.Close();
                return sName;
            }
        }
    }

    public class ViewResult
    {
        public string StudentRollNumber { get; set; }
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public decimal CAT1 { get; set; }
        public decimal CAT2 { get; set; }
        public decimal CAT3 { get; set; }
        public decimal TestTotal { get; set; }
        public decimal ExamsScores { get; set; }
        public decimal Total { get; set; }
        public string Grades { get; set; }
        public string Remark { get; set; }
        public decimal TestT { get; set; }
        public decimal ExamsT { get; set; }
        public decimal TotalT { get; set; }

        public static List<ViewResult> ShowResult(string StudId, string date, string term)
        {
            List<ViewResult> Result = new List<ViewResult>();
            
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ViewResultDetails", connection) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@studentRollId", SqlDbType.NVarChar).Value = StudId;
                    cmd.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = date;
                    cmd.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term;

                    connection.Open();
                    SqlDataReader read = cmd.ExecuteReader();
                    
                    while (read.Read())
                    {
                        ViewResult Vr = new ViewResult();
                        Vr.StudentRollNumber = read["StudentRollNumber"].ToString();
                        Vr.StudentName = read["StudentName"].ToString();
                        Vr.SubjectName = read["SubjectName"].ToString();
                        Vr.CAT1 = Convert.ToDecimal(read["CAT1"]);
                        Vr.CAT2 = Convert.ToDecimal(read["CAT2"]);
                        Vr.CAT3 = Convert.ToDecimal(read["CAT3"]);
                        Vr.TestTotal = Convert.ToDecimal(read["TestTotal"]);
                        Vr.ExamsScores = Convert.ToDecimal(read["ExamsScores"]);
                        Vr.Total = Convert.ToDecimal(read["Total"]);
                        Vr.Grades = (read["Grades"]).ToString();
                        Vr.Remark = read["Remark"].ToString();
                        
                        Result.Add(Vr);
                    }
                    connection.Close();
                    return Result;
                }
                catch
                {
                    throw ;
                }
            }
        }
    }
}
