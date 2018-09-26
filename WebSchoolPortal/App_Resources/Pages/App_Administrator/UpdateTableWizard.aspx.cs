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

namespace WebSchoolPortal.App_Resources.Pages.App_Administrator
{
    public partial class UpdateTableWizard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                BindControl.BindDefaultClassDropDown(ddlCllasses);
                BindControl.BindTableNames(ddlTabName);
            }

        }

        protected void ddlTabName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindControl.BindTableColumns(ddlColumnName, ddlTabName);
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("UpdateClassId", connection) { CommandType=CommandType.StoredProcedure};
                    com.Parameters.AddWithValue("@tabname", SqlDbType.NVarChar).Value = ddlTabName.SelectedItem.Text;
                    com.Parameters.AddWithValue("@colName", SqlDbType.NVarChar).Value = ddlColumnName.SelectedItem.Text;
                    com.Parameters.AddWithValue("@FieldId", SqlDbType.Int).Value = ddlCllasses.SelectedItem.Value;
                    com.Parameters.AddWithValue("@FieldName", SqlDbType.NVarChar).Value = ddlCllasses.SelectedItem.Text;
                    connection.Open();
                    int rollsAffected = com.ExecuteNonQuery();
                    connection.Close();
                    string message = rollsAffected+" Roll(s) Affected";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
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
    }
}