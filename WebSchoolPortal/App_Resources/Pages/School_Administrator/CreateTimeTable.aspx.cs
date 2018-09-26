using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebSchoolPortal.App_Resources.Pages.AllGeneral
{
    public partial class CreateTimeTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SchoolId.Text= Session["SchoolId"].ToString();
            if (!IsPostBack)
            {
                addPeriods.Visible = false;
                HowLongInMins.Visible = false;
            }
            if (Config.Text!="")
            {

                FirstPeriodTime.Visible = false;
                FirstPeriodTime.Text = "";
            }          
        }

        
        
        protected void addPeriods_Click(object sender, EventArgs e)
        {
            lblSchoolStart.Text = "Next Period Start Time";
            Config.Text += HowLongInMins.Text + ":";
            string input = Config.Text;
            string[] result = input.Split(new string[] { ":" }, StringSplitOptions.None);
            nextTime.Text = HiddenValue.Value;
            if (result.Count() == Convert.ToInt32(NumbersOfPeriods.Text)+1)
            {
                string message = result.Count().ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                addPeriods.Visible = false;
                FirstPeriodTime.Visible = true;
                MakeDefault.Visible = true;
                using (SqlConnection conect = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand com = new SqlCommand("TimeTable", conect) { CommandType = CommandType.StoredProcedure };
                    com.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                    com.Parameters.AddWithValue("@day", SqlDbType.NVarChar).Value = day.SelectedItem.Text;
                    com.Parameters.AddWithValue("@StartTime", SqlDbType.NVarChar).Value = StartTime.Text;
                    com.Parameters.AddWithValue("@Config", SqlDbType.NVarChar).Value = Config.Text;
                    conect.Open();
                    int insert=com.ExecuteNonQuery();
                    conect.Close();
                    if (insert > 0)
                    {
                        StartTime.Text = "";
                        Config.Text = "";
                        nextTime.Text = "";
                        NumbersOfPeriods.Text = "";
                    }
                }
            }
        }
        
        protected void MakeDefault_Click(object sender, EventArgs e)
        {
            lblSchoolStart.Text = "First Period Start Time";

            addPeriods.Visible = true;
            HowLongInMins.Visible = true;
            MakeDefault.Visible = false;
            StartTime.Text = FirstPeriodTime.Text;
            nextTime.Text = FirstPeriodTime.Text;
            FirstPeriodTime.Visible = false;
        }
    }

    public class TTable
    {
        public string  day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string PName { get; set; }
    }


}