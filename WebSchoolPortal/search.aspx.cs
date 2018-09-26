using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["SPin"] = SearchBox.Text;
            Response.Redirect("~/App_Resources/Pages/AllGeneral/searchresult.aspx");
        }

        protected void createNew_Click(object sender, EventArgs e)
        {
            int x = 2;

            for (int i = 1; i <= x; i++)
            {
                string adminName = "HezdikeTeacher" + i;
                string adminPass = "EbukaAdolfOEA_" + i;
                //string x=ConfigurationManager.
                Response.Write("Createing" + i + "\n");

                MembershipCreateStatus status;
                Membership.CreateUser(adminName, adminPass, "akwamailing@gmail.com", "are you Really human", "Why you ask", true, out status);
                if (!Roles.RoleExists("Teacher"))
                {
                    Roles.CreateRole("Teacher");
                }

                Roles.AddUserToRole(adminName, "Teacher");
            }
        }

        static List<UserNameRoles> Names()
        {
            int counter = 0;
            List<string> names = new List<string>();
            List<UserNameRoles> sameNames = new List<UserNameRoles>();
            List<UserNameRoles> UserRoles = new List<UserNameRoles>();

            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("Select StudentRegTab.FirstName+StudentRegTab.LastName as Names, StudentRegTab.StudentRollNumber From StudentRegTab", con);
                con.Open();
                SqlDataReader re = com.ExecuteReader();
                while (re.Read())
                {
                    Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                    string str = rgx.Replace(re["Names"].ToString(), "");

                    //;kejdnawoejd[q0wiod
                    UserNameRoles UR = new UserNameRoles();
                    UR.RollNum = re["StudentRollNumber"].ToString();
                    UR.UserName = str;
                    names.Add(re["Names"].ToString());

                    UserRoles.Add(UR);
                }

                var newNames = UserRoles.ToArray();
                for (int i = 0; i <= newNames.Length - 1; i++)
                {
                    for (int j = i + 1; j <= newNames.Length - 1; j++)
                    {
                        if (newNames[i].UserName == newNames[j].UserName)
                        {
                            Console.WriteLine("Names at index " + i + " Is same with name at index " + j);
                            Console.WriteLine("New name at index " + j + " is " + newNames[j].UserName + j);
                            newNames[j].UserName = newNames[j].UserName + j;
                            Console.WriteLine("New Id at index " + j + " is " + newNames[j].RollNum);
                            Console.WriteLine(" ");
                            Console.WriteLine(" ");
                            sameNames.Add(newNames[j]);
                            counter++;
                        }
                    }
                }
                Console.WriteLine(newNames.Count() + " Users Available");
                Console.WriteLine(counter + " Clashes available");

                return newNames.ToList();
            }

            // return names;
        }

        static int countUsers()
        {
            int num = 0;
            using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
            {
                Console.WriteLine("Please wait, counting users.......");

                SqlCommand com = new SqlCommand("Select Count(StudentRollNumber) as numStud from StudentRegTab", con);
                con.Open();
                SqlDataReader re = com.ExecuteReader();
                if (re.Read())
                {
                    num = Convert.ToInt32(re["numStud"].ToString());
                    Console.WriteLine("# Of Users " + num);
                }
                con.Close();
                return num;
            }
        }
    }

    public class UserNameRoles
    {
        public string UserName { get; set; }
        public string RollNum { get; set; }
    }
}