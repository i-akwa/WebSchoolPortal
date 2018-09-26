using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using CodePortal.Project.DbConnection;
using System.IO;
using System.Web;
using CodePortal.Project.GenericList;

namespace CodePortal.Project.Students
{
    public  class Student_StudentInfo
    {
        public string SchoolId { get; set; }
        public string StudentRollNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string ResidentialAddress { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AdmissionClass { get; set; }
        public string GuidianceName { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LGA { get; set; }
        public string Disability { get; set; }
        public byte[] Passport { get; set; }
        public string GuidiancePhoneNo { get; set; }
        public string SchoolAttended { get; set; }
        public string ReasonForChange { get; set; }
        public string StudentEmail { get; set; }
        public string isborder { get; set; }
        public string PresentClass { get; set; }
        public string Spin { get; set; }
    }

    public class Student_studentControl
    {
        public static int AddNewStudent(string SchoolId, Guid UserId, string StudentRollNumber, string FirstName, string MiddleName, string LastName, string Sex,  DateTime AdmissionDate, string AdmissionClass,string ResidentialAddress, string GuidianceName, string EmailAdress,int LGA, string GuidiancePhoneNo, string sePin, int Armsid, DateTime DOB)
        {
            int rollAffected = 0;
            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand selectCommand = new SqlCommand("RegisterNewStudent", connect) { CommandType = CommandType.StoredProcedure };

                selectCommand.Parameters.AddWithValue("UserId", SqlDbType.UniqueIdentifier).Value = UserId;
                selectCommand.Parameters.AddWithValue("SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                selectCommand.Parameters.AddWithValue("StudentRollNumber", SqlDbType.NVarChar).Value = StudentRollNumber;
                selectCommand.Parameters.AddWithValue("FirstName", SqlDbType.NVarChar).Value = FirstName;
                selectCommand.Parameters.AddWithValue("MiddleName", SqlDbType.NVarChar).Value = MiddleName;
                selectCommand.Parameters.AddWithValue("LastName", SqlDbType.NVarChar).Value = LastName;
                selectCommand.Parameters.AddWithValue("Sex", SqlDbType.NVarChar).Value = Sex;
                selectCommand.Parameters.AddWithValue("AdmissionDate", SqlDbType.DateTime).Value = AdmissionDate;
                selectCommand.Parameters.AddWithValue("PresentClass", SqlDbType.NVarChar).Value = AdmissionClass;
                selectCommand.Parameters.AddWithValue("ResidentialAddress", SqlDbType.NVarChar).Value = ResidentialAddress;
                selectCommand.Parameters.AddWithValue("GuidianceName", SqlDbType.NVarChar).Value = GuidianceName;
                selectCommand.Parameters.AddWithValue("EmailAdress", SqlDbType.NVarChar).Value = EmailAdress;
                selectCommand.Parameters.AddWithValue("LGA", SqlDbType.Int).Value = LGA;
                selectCommand.Parameters.AddWithValue("GuidiancePhoneNo", SqlDbType.NVarChar).Value = GuidiancePhoneNo;

                selectCommand.Parameters.AddWithValue("@sPin", SqlDbType.NVarChar).Value = sePin;
                selectCommand.Parameters.AddWithValue("@Armsid", SqlDbType.Int).Value = Armsid;
                selectCommand.Parameters.AddWithValue("@DateOfBirth", SqlDbType.DateTime).Value = DOB;
                try
                {
                    connect.Open();
                    rollAffected = selectCommand.ExecuteNonQuery();
                    UploadStudentThumbnail(SchoolId, StudentRollNumber);
                    connect.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rollAffected;
        }

        public static int UpdateStudentRecord(string SchoolId, string FirstName, string MiddleName, string LastName, string ResidentialAddress,string studentRollNum, string StudentPhoneNumber, string Sex, string StudentEmail, string GuidiancePhoneNo, DateTime DateOfBirth, int LGA, string clas)
        {
            int rollAffected = 0;

            using (SqlConnection connect = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand update = new SqlCommand("UpdateStudentProfile", connect) { CommandType = CommandType.StoredProcedure };

                update.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                update.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = FirstName;
                update.Parameters.AddWithValue("@MiddleName", SqlDbType.NVarChar).Value = MiddleName;
                update.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = LastName;
                update.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = studentRollNum;
                update.Parameters.AddWithValue("@ResidentialAddress", SqlDbType.NVarChar).Value = ResidentialAddress;
                update.Parameters.AddWithValue("@StudentPhoneNumber", SqlDbType.NVarChar).Value = StudentPhoneNumber;
                update.Parameters.AddWithValue("@Sex", SqlDbType.NVarChar).Value = Sex;
                update.Parameters.AddWithValue("@StudentEmail", SqlDbType.NVarChar).Value = StudentEmail;
                update.Parameters.AddWithValue("@GuidiancePhoneNo", SqlDbType.NVarChar).Value = GuidiancePhoneNo;
                update.Parameters.AddWithValue("@DateOfBirth", SqlDbType.NVarChar).Value = DateOfBirth;
                update.Parameters.AddWithValue("@LGA", SqlDbType.Int).Value = LGA;
                update.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas;


                try
                {
                    connect.Open();
                    rollAffected = update.ExecuteNonQuery();
                    connect.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rollAffected;
        }

        public static int UploadStudentThumbnail(string SchoolId, string StudentRollNumber)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    connection.Open();
                    string imageName = SchoolId;
                    var files = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/App_Resources/images/"));
                    //string Path = files+SchoolId;
                    foreach (var file in files)
                    {
                        var fileName = Path.GetFileName(file);
                        if (fileName != SchoolId)
                            continue;

                        var data = File.ReadAllBytes(file);
                        SqlCommand cmd = new SqlCommand("UploadStudentpixs", connection) { CommandType = CommandType.StoredProcedure };

                        cmd.Parameters.Add("@studentRollnum", SqlDbType.NVarChar).Value = StudentRollNumber;
                        cmd.Parameters.Add("@Passport", SqlDbType.VarBinary).Value = data;

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return rowsAffected;
        }

        public static int DisplayArms(string schoolid, System.Web.UI.WebControls.GridView a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand selectCommand = new SqlCommand("GetArms", connection) { CommandType = CommandType.StoredProcedure };
                    selectCommand.Parameters.AddWithValue("@schoolId", SqlDbType.NVarChar).Value = schoolid;
                    connection.Open();
                    SqlDataReader read = selectCommand.ExecuteReader();
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

        public static int ClassGrid(string schoolId, string classes, System.Web.UI.WebControls.GridView a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                //try
                //{
                    SqlCommand selectCommand = new SqlCommand("FillGrid", connection) { CommandType = CommandType.StoredProcedure };
                    selectCommand.Parameters.AddWithValue("@schoolId", SqlDbType.NVarChar).Value = schoolId;
                    selectCommand.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = classes;
                    connection.Open();
                    //SqlDataReader read = selectCommand.ExecuteReader();
                    SqlDataAdapter DA = new SqlDataAdapter(selectCommand);
                    DataTable DT= new DataTable();
                    DA.Fill(DT);
                    a.DataSource = DT;
                    a.DataBind();
                    connection.Close();
                //}
                //catch (Exception ex)
                //{
                //    throw ex;
                //}
                return rowsAffected;
            }
        }

        public static int PaymentGrid(string SchoolId, string StudentId, string Year, string Term, System.Web.UI.WebControls.GridView a, System.Web.UI.WebControls.DropDownList clas, System.Web.UI.WebControls.TextBox name, System.Web.UI.WebControls.TextBox amountPaid, System.Web.UI.WebControls.TextBox actualFees, System.Web.UI.WebControls.TextBox status)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand selectCommand = new SqlCommand("SelectPaymentDetails", connection) { CommandType = CommandType.StoredProcedure };
                    selectCommand.Parameters.AddWithValue("@StudentId", SqlDbType.NVarChar).Value = StudentId;
                    selectCommand.Parameters.AddWithValue("@Year", SqlDbType.NVarChar).Value = Year;
                    selectCommand.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term;
                    selectCommand.Parameters.AddWithValue("@schoolID", SqlDbType.NVarChar).Value = SchoolId;

                    connection.Open();
                    SqlDataReader read = selectCommand.ExecuteReader();

                    if(read.Read())
                    {

                        //clas.Text = read["studentClass"].ToString();
                        name.Text = read["name"].ToString();
                        amountPaid.Text = read["amountPaid"].ToString();
                        actualFees.Text = read["Fees"].ToString();
                        status.Text = read["Status"].ToString();

                        //a.DataSource = read;
                        //a.DataBind();
                    }
                    read.Close();
                            SqlDataReader ree = selectCommand.ExecuteReader();
                            a.DataSource = ree;
                            a.DataBind();

                        connection.Close();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return rowsAffected;
            }

        }

        public static int PaymentGrid(string SchoolId, string StudentId, string Year, string Term, System.Web.UI.WebControls.GridView a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand selectCommand = new SqlCommand("SelectPaymentDetails", connection) { CommandType = CommandType.StoredProcedure };
                    selectCommand.Parameters.AddWithValue("@StudentId", SqlDbType.NVarChar).Value = StudentId;
                    selectCommand.Parameters.AddWithValue("@Year", SqlDbType.NVarChar).Value = Year;
                    selectCommand.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term;
                    selectCommand.Parameters.AddWithValue("@schoolID", SqlDbType.NVarChar).Value = SchoolId;

                    connection.Open();
                    SqlDataReader ree = selectCommand.ExecuteReader();
                    a.DataSource = ree;
                    a.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return rowsAffected;
            }
        }


        public static int PayFees(string SchoolId, string name, string StudentRollNum, DateTime Paymentdate, string StudentClass, decimal Fees, decimal AmountPaid, string Term, string status)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand payFees = new SqlCommand("PayFees", connection) { CommandType = CommandType.StoredProcedure };
                payFees.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                payFees.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = name;
                payFees.Parameters.AddWithValue("@studentRollnum", SqlDbType.NVarChar).Value = StudentRollNum;
                payFees.Parameters.AddWithValue("@paymentDate", SqlDbType.NVarChar).Value = Paymentdate;
                payFees.Parameters.AddWithValue("@studentClass", SqlDbType.NVarChar).Value = StudentClass;
                payFees.Parameters.AddWithValue("@Fees", SqlDbType.NVarChar).Value = Fees;
                payFees.Parameters.AddWithValue("@amountPaid", SqlDbType.NVarChar).Value = AmountPaid;
                payFees.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term;
                payFees.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = status;

                try
                {
                    connection.Open();
                    rowsAffected = payFees.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rowsAffected;
        }

        public static int UpdateFees(decimal amountPaid, string status, string schoolId, string year, string studentID, string Term)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand UpdateFees = new SqlCommand("UpdateStudentFees", connection) { CommandType = CommandType.StoredProcedure };
                UpdateFees.Parameters.AddWithValue("@amountPaid", SqlDbType.Decimal).Value = amountPaid;
                UpdateFees.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = status;
                UpdateFees.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = schoolId;
                UpdateFees.Parameters.AddWithValue("@year", SqlDbType.NVarChar).Value = year;
                UpdateFees.Parameters.AddWithValue("@StudentId", SqlDbType.NVarChar).Value = studentID;
                UpdateFees.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term;

                try
                {
                    connection.Open();
                    rowsAffected = UpdateFees.ExecuteNonQuery();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return rowsAffected;
        }
        //binding to a gridview:::: selecting students payment information by their individual classes 
        public static int SelectPaymentByClass(string SchoolId, string clas, string Year, string Term, System.Web.UI.WebControls.GridView a)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand selectCommand = new SqlCommand("SelectPaymentDetailsByClass", connection) { CommandType = CommandType.StoredProcedure };
                    selectCommand.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas;
                    selectCommand.Parameters.AddWithValue("@Year", SqlDbType.NVarChar).Value = Year;
                    selectCommand.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term;
                    selectCommand.Parameters.AddWithValue("@schoolID", SqlDbType.NVarChar).Value = SchoolId;

                    connection.Open();
                    SqlDataReader ree = selectCommand.ExecuteReader();
                    a.DataSource = ree;
                    a.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return rowsAffected;
            }
        }
        //Binding to a gridview:::: selecting student result
        public static int ViewResult(System.Web.UI.WebControls.GridView g, string SchoolId, string Year, string term, string clas, int armId )
        {
             int rowsAffected = 0;
             using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
             {
                 try
                 {
                     SqlCommand data = new SqlCommand("ViewResult", connection) { CommandType = CommandType.StoredProcedure };
                     data.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                     data.Parameters.AddWithValue("@term", SqlDbType.NVarChar).Value = term;
                     data.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas;
                     data.Parameters.AddWithValue("@date", SqlDbType.NVarChar).Value = Year;
                     data.Parameters.AddWithValue("@armsId", SqlDbType.Int).Value = armId;
                     connection.Open();
                     SqlDataAdapter re = new SqlDataAdapter(data);
                     DataTable dt = new DataTable();
                     re.Fill(dt);
                     g.DataSource = dt;
                     g.DataBind();
                     connection.Close();
                 }
                 catch (Exception ex)
                 {
                     throw ex;
                 }
                 return rowsAffected;
             }
        }

        //Binding to agrid view, sorting student attendance
        public static int BindAttendance(System.Web.UI.WebControls.GridView g, string SchoolId, int armId, string clas)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand data = new SqlCommand("Select FirstName +' '+LastName  as Name, StudentRollNumber from StudentRegTab where StudentRollNumber=Any(Select StudentRollNumber from StudentRegTab where Armsid = @Armsid and PresentClass=@PresentClass and SchoolId=@SchoolId)", connection);
                    data.Parameters.AddWithValue("@Armsid", SqlDbType.Int).Value = armId;
                    data.Parameters.AddWithValue("@PresentClass", SqlDbType.NVarChar).Value = clas;
                    data.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId;
                    connection.Open();
                    SqlDataAdapter re = new SqlDataAdapter(data);
                    DataTable dt = new DataTable();
                    re.Fill(dt);
                    g.DataSource = dt;
                    g.DataBind();
                    connection.Close();
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return rowsAffected;
            }
        }


        public static int UpdateStudentProfilePicture(string StudentRoll, BinaryReader br, int inputStreamLength)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                using (br)
                {
                    SqlCommand command = new SqlCommand("UpdateStudentProfilePicture", connection) { CommandType = CommandType.StoredProcedure };

                    command.Parameters.Add("@StudentRoll", SqlDbType.NVarChar).Value = StudentRoll;

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

        public static AdminInfoData<Student_StudentInfo> GetStudentInformation(string StudentRollNumber)
        {
            AdminInfoData<Student_StudentInfo> accessors = new AdminInfoData<Student_StudentInfo>();
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand command = new SqlCommand("GetStudentProfile", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@StudentRollNumber", SqlDbType.NVarChar).Value = StudentRollNumber;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Student_StudentInfo access = new Student_StudentInfo();
                        access.SchoolId = reader["SchoolId"].ToString();
                        access.ResidentialAddress = reader["ResidentialAddress"].ToString();
                        access.StudentEmail = reader["StudentEmail"].ToString();
                        access.AdmissionDate = (DateTime)reader["AdmissionDate"];
                        access.FirstName = reader["FirstName"].ToString();
                        access.MiddleName = reader["MiddleName"].ToString();
                        access.LastName = reader["LastName"].ToString();
                        access.GuidiancePhoneNo = reader["GuidiancePhoneNo"].ToString();
                        access.Passport = (byte[])reader["passport"];
                        access.LGA = reader["LGA"].ToString();
                        access.StudentRollNumber = reader["StudentRollNumber"].ToString();
                        access.StudentPhoneNumber = reader["StudentPhoneNumber"].ToString();
                        access.Sex = reader["Sex"].ToString();
                        access.PresentClass = reader["class"].ToString();
                        access.isborder = reader["isborder"].ToString();
                        access.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
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
    }
}
