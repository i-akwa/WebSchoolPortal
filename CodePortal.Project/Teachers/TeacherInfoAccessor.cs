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

namespace CodePortal.Project.Teachers
{
    public class TeacherInfoAccessor
    {
        public byte[] Passport { get; set; }
        public string SchoolId { get; set; }
        public string TeacherId { get; set; }
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ContactAdress { get; set; }
        public DateTime RegDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int subject { get; set; }
        public string LGA { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string IsClassteacher { get; set; }
    }

    public class TeacherInformationControl
    {
        public static int TeacherRegistration(Guid TeacherId, string TeacherRollId, string Fname, string Mname, string Lname, string IsclassTeacher, string PhoneNumber, string ContactAdress, DateTime DOB, int LGA,string Email,int SubjectId, string SchoolId, DateTime RegDate )
        {
            int rowsAffected = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand regteach = new SqlCommand("RegisterNewTeacher", connect) { CommandType = CommandType.StoredProcedure };

                regteach.Parameters.AddWithValue("@TeacherId",SqlDbType.UniqueIdentifier).Value=TeacherId;
                regteach.Parameters.AddWithValue("@TeacherRollId",SqlDbType.NVarChar).Value=TeacherRollId;
                regteach.Parameters.AddWithValue("@FirstName",SqlDbType.NVarChar).Value=Fname;
                regteach.Parameters.AddWithValue("@MiddleName",SqlDbType.NVarChar).Value=Mname;
                regteach.Parameters.AddWithValue("@LastName",SqlDbType.NVarChar).Value=Lname;
                regteach.Parameters.AddWithValue("@isClassTeacher",SqlDbType.NVarChar).Value=IsclassTeacher;
                regteach.Parameters.AddWithValue("@PhoneNumber",SqlDbType.NVarChar).Value=PhoneNumber;
                regteach.Parameters.AddWithValue("@ResidentialAdress",SqlDbType.NVarChar).Value=ContactAdress;
                regteach.Parameters.AddWithValue("@DOB",SqlDbType.DateTime).Value=DOB;
                regteach.Parameters.AddWithValue("@LocalGovernment",SqlDbType.Int).Value=LGA;
                regteach.Parameters.AddWithValue("@EmailAdress",SqlDbType.NVarChar).Value=Email;
                regteach.Parameters.AddWithValue("@SubjectId",SqlDbType.Int).Value=SubjectId;
                regteach.Parameters.AddWithValue("@SchoolId",SqlDbType.NVarChar).Value=SchoolId;
                regteach.Parameters.AddWithValue("@RegistrationDate", SqlDbType.DateTime).Value = RegDate;

                try
                {
                connect.Open();
                rowsAffected=regteach.ExecuteNonQuery();
                UploadDefaultThumbnail(TeacherRollId);
                connect.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return rowsAffected;
        }

        static int UploadDefaultThumbnail(string TeacherRoll)
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
                        SqlCommand cmd = new SqlCommand("UploadDefaultThumbnaill", connection) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.Add("@TeacherRollId", SqlDbType.NVarChar).Value = TeacherRoll;
                        cmd.Parameters.Add("@ProfilePixs", SqlDbType.VarBinary).Value = data;

                        rowsAffected = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch
                {
                    throw;
                }
            }

            return rowsAffected;
        }

        public static AdminInfoData<TeacherInfoAccessor> GetTeacher(string TeacherRollId)
        {
            AdminInfoData<TeacherInfoAccessor> accessors = new AdminInfoData<TeacherInfoAccessor>();
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("GetTeacher", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@TeacherRollId", SqlDbType.NVarChar).Value = TeacherRollId;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TeacherInfoAccessor access = new TeacherInfoAccessor();
                        access.SchoolId = reader["SchoolId"].ToString();
                        access.ContactAdress = reader["ResidentialAdress"].ToString();
                        access.Email = reader["EmailAdress"].ToString();
                        access.RegDate = (DateTime)reader["RegistrationDate"];
                        access.firstName = reader["FirstName"].ToString();
                        access.phoneNumber = reader["PhoneNumber"].ToString();
                        access.MiddleName = reader["MiddleName"].ToString();
                        access.LastName = reader["LastName"].ToString();
                        access.Passport = (byte[])reader["passport"];
                        access.LGA = reader["LGA"].ToString();
                        access.TeacherId = reader["TeacherRollId"].ToString();
                        accessors.Add(access);
                    }

                    reader.Close();
                    connection.Close();
                }
                catch
                {
                    throw;
                }
            }
            return accessors;
        }

        public static int UpdateProfilePicture(string TeacherRoll, BinaryReader br, int inputStreamLength)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                using (br)
                {
                    SqlCommand command = new SqlCommand("UpdateTeacherProfilePicture", connection) { CommandType = CommandType.StoredProcedure };

                    command.Parameters.Add("@TeacherRoll", SqlDbType.NVarChar).Value = TeacherRoll;

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

        public static int updateTeacherProfile(string SchoolId, string TeacherRollId, string FirstName, string MiddleName, string LastName, string PhoneNumber, string Gender, string ResidentialAdress, int LocalGovernment)
        {
            int rollAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("UpdateTeacherProfile", connection) { CommandType = CommandType.StoredProcedure };

                command.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                command.Parameters.AddWithValue("@TeacherRoll", SqlDbType.NVarChar).Value = TeacherRollId;
                command.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                command.Parameters.AddWithValue("@MiddleName", SqlDbType.NVarChar).Value = MiddleName;
                command.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                command.Parameters.AddWithValue("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber;
                command.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = Gender;
                command.Parameters.AddWithValue("@ResidentialAdress", SqlDbType.NVarChar).Value = ResidentialAdress;
                command.Parameters.AddWithValue("@LocalGovernment", SqlDbType.Int).Value = LocalGovernment;

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

    }
}
