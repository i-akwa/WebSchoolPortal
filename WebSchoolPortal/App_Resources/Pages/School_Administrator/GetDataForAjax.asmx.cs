using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    /// <summary>
    /// Summary description for GetDataForAjax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GetDataForAjax : System.Web.Services.WebService
    {

        [WebMethod]
        public TtableConfig[] MakeTimeTable()
        {
            List<TtableConfig> ttconfig = new List<TtableConfig>();
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand com = new SqlCommand("GetTimeTable", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@schoolId",SqlDbType.NVarChar).Value= Session["SchoolId"].ToString();
                connection.Open();
                SqlDataAdapter Da = new SqlDataAdapter(com);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                foreach(DataRow datarow in Dt.Rows)
                {
                    TtableConfig ttcon = new TtableConfig();
                    ttcon.day = datarow["day"].ToString();
                    ttcon.startTime= datarow["statrtTime"].ToString();
                    ttcon.config= datarow["Config"].ToString();

                    ttconfig.Add(ttcon);
                }
                return ttconfig.ToArray();
            }
        }
    }

    public class TtableConfig
    {
        public string day { get; set; }
        public string startTime { get; set; }
        public string config { get; set; }
    }
}
