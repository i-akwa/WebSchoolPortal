using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.MasterPage
{
    public partial class AppMaster : System.Web.UI.MasterPage
    {
        public string HeaderLabel
        {
            get { return headingLabel.Text; }
            set { headingLabel.Text = value; }
        }



        protected void Page_Load(object sender, EventArgs e)
        {


            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    var id= new[]
                        {
                            new ID
                            {
                                SchoolId=Request.Cookies["SchoolId"].Value.ToString()
                            }
                        };
                    thumbpic.DataSource = id;
                    thumbpic.DataBind();
                    SqlCommand Sel = new SqlCommand("SelSchoolName", connection) { CommandType = CommandType.StoredProcedure };
                    Sel.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    connection.Open();
                    SqlDataReader re = Sel.ExecuteReader();
                    if (re.Read())
                    {
                        SchoolName.Text = re["SchoolName"].ToString();
                    }
                    else
                    {
                        SchoolName.Text = "";
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    
                }
            }
        }



    }
}