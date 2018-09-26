using CodePortal.Project.BindControls;
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



namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class ViewAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HeaderLabel = "View Attendance";
            schoolId.Text = Request.Cookies["SchoolId"].Value;
            schoolId.ReadOnly = true;
            if(!Page.IsPostBack)
            {
                BindControl.BindFeesClassDropDown(clas);
            }
        }

        void BindAttGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand Selcom = new SqlCommand("SelectClassAttain", connection) { CommandType = CommandType.StoredProcedure };
                    Selcom.Parameters.AddWithValue("@SchoolID", SqlDbType.NVarChar).Value = schoolId.Text;
                    Selcom.Parameters.AddWithValue("@Date", SqlDbType.NVarChar).Value = Convert.ToDateTime(RadDatePicker1.SelectedDate).ToString("dd/MM/yyyy");
                    Selcom.Parameters.AddWithValue("@ArmsId", SqlDbType.Int).Value = arm.SelectedItem.Value;
                    Selcom.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = clas.SelectedItem.Text;
                   
                    connection.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(Selcom);
                    DataTable DT = new DataTable();
                    Da.Fill(DT);
                    viewAttaindance.DataSource = DT;
                    viewAttaindance.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
            }
        }

        protected void viewAttaindance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewAttaindance.PageIndex = e.NewPageIndex;
            viewAttaindance.DataBind();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (RadDatePicker1.SelectedDate == null)
            {
                string message = "Please Select Date !!!!";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
            else
            BindAttGrid();
        }

        protected void ClasCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClasCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    if(Dt!=null)
                    {
                        clas.Items.Clear();
                        clas.DataSource = Dt;
                        clas.DataTextField = "class";
                        clas.DataValueField = "ClassId";
                        clas.DataBind();
                    }
                    else
                    {

                    }
                 
                }
            }
            else if (ClasCheck.Checked == false)
            {
                BindControl.BindFeesClassDropDown(clas);

            }
        }
    }
    
}