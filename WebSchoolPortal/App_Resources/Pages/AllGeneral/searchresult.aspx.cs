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

namespace WebSchoolPortal
{
    public partial class searchresult : System.Web.UI.Page
    {
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SearchBox.Text != "")
            {
                Session["SPin"] = SearchBox.Text;
            }
            getFees();
            getAttaindance();
            getBasicinfo();
        }


        private void getFees()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    string spin = Session["SPin"].ToString();
                    SqlCommand c = new SqlCommand("DirectFeesRecords", connection) { CommandType = CommandType.StoredProcedure };
                    c.Parameters.AddWithValue("@SecreatPassWord", SqlDbType.NVarChar).Value = spin;
                    connection.Open();
                    SqlDataAdapter Sda = new SqlDataAdapter(c);
                    DataTable Dt = new DataTable();
                    Sda.Fill(Dt);
                    PaymentDetails.DataSource = Dt;
                    PaymentDetails.DataBind();
                    connection.Close();
                }
                catch(Exception ex)
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

        private void getAttaindance()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                string spin = Session["SPin"].ToString();
                SqlCommand cm = new SqlCommand("DirectAttaindanceRecord", connection) { CommandType = CommandType.StoredProcedure };
                cm.Parameters.AddWithValue("@SecreatPassWord", SqlDbType.NVarChar).Value = spin;
                connection.Open();
                SqlDataAdapter Sda = new SqlDataAdapter(cm);
                DataTable Dt = new DataTable();
                Sda.Fill(Dt);
                ShowAttaindance.DataSource = Dt;
                ShowAttaindance.DataBind();
                connection.Close();
            }
        }

        private void getBasicinfo()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                string spin = Session["SPin"].ToString();
                SqlCommand com = new SqlCommand("SelectMultipleRecords", connection) { CommandType = CommandType.StoredProcedure };
                com.Parameters.AddWithValue("@SecreatPassWord", SqlDbType.NVarChar).Value = spin;
                connection.Open();
                SqlDataAdapter Sda = new SqlDataAdapter(com);
                DataTable Dt = new DataTable();
                Sda.Fill(Dt);
                BasicProfile.DataSource = Dt;
                BasicProfile.DataBind();

                Studentpix.DataSource = Dt;
                Studentpix.DataBind();

                SchoolImage.DataSource = Dt;
                SchoolImage.DataBind();
                connection.Close();
            }
        }

        protected void PaymentDetails_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            PaymentDetails.PageIndex = e.NewPageIndex;
            PaymentDetails.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Session["SPin"] = SearchBox.Text;
            
        }
    }
}