using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using CodePortal.Project.DbConnection;
using System.Web.Services;
using System.Security;
using System.Web.Security;
using CodePortal.Project.Students;
using System.Threading;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class ManageFees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            Insert.Visible = true;
            lblClass.Visible = false;

            if (!IsPostBack)
            {
                BindControl.BindFeesClassDropDown(ClassList);
                SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();
                Master.HeaderLabel = "Fees Management";
                fillGrid();
            }
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    connection.Close();
                    SqlCommand insert = new SqlCommand("InsertNewFees", connection) { CommandType = CommandType.StoredProcedure };
                    insert.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                    insert.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(InsertFees.Text);
                    insert.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = ClassList.SelectedValue.ToString();
                    connection.Open();
                    insert.ExecuteNonQuery();
                    connection.Close();
                    fillGrid();
                }
                catch (Exception ex)
                {
                    string message = "There is either no data inserted, inputed string not valid or a fee is repeted for a particular class " + ex.Message;
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
                }
                finally
                {
                    InsertFees.Text = "";
                }
            }
        }

        private void fillGrid()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand select = new SqlCommand("SELECTFEES", connection) { CommandType=CommandType.StoredProcedure};
                select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                connection.Open();
                SqlDataReader re = select.ExecuteReader();
                grid1.DataSource = re;
                grid1.DataBind();
                connection.Close();
            }
        }

        protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (e.CommandName.Equals("Edt"))
                    {
                        ClassList.Visible = false;
                        lblClass.Visible = true;                       
                        btnUpdate.Visible = true;
                        Insert.Visible = false;
                        SqlCommand selcom = new SqlCommand("Select Amount, ClassesTable.class, feesTable.Class from feesTable left outer join ClassesTable on ClassesTable.ClassId=feesTable.Class where FeesId=@FeesId", connection);
                        selcom.Parameters.AddWithValue("@FeesId", SqlDbType.NVarChar).Value = e.CommandArgument;
                        connection.Open();
                        SqlDataReader reed = selcom.ExecuteReader();
                        if (reed.Read())
                        {
                            string clas = reed["Class"].ToString();

                            lblClass.Text = reed["class"].ToString(); ;
                            HiddenClassId.Value = clas;
                            InsertFees.Text = reed["Amount"].ToString();
                        }
                        connection.Close();
                    }
                    if (e.CommandName.Equals("Del"))
                    {
                        int id= Convert.ToInt32(e.CommandArgument);
                        SqlCommand deldata = new SqlCommand("Delete feesTable where FeesId=@FeesId", connection);
                        deldata.Parameters.AddWithValue("@FeesId", SqlDbType.Int).Value = id;
                        connection.Open();
                        deldata.ExecuteNonQuery();
                        connection.Close();
                        fillGrid();
                    }
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (ClassList.SelectedItem.Text== "" || InsertFees.Text.Trim() == "")
                    {
                        string message = "Please Fill The Textboxes";
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
                    {
                        SqlCommand update = new SqlCommand("Update feesTable set Amount=@Amount where SchoolId=@SchoolId and Class=@Class", connection);
                        update.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                        update.Parameters.AddWithValue("@Class", SqlDbType.NVarChar).Value = HiddenClassId.Value.ToString();
                        update.Parameters.AddWithValue("@Amount", SqlDbType.NVarChar).Value = Convert.ToDecimal(InsertFees.Text);
                        connection.Open();
                        update.ExecuteNonQuery();
                        connection.Close();
                        InsertFees.Text = "";
                        ClassList.Visible = true;
                        fillGrid();
                    }
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

        protected void ClassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ClassCheck.Checked)
            {
                using (SqlConnection con = new SqlConnection(ConnectionClass.getConnection))
                {
                    SqlCommand cmd = new SqlCommand("GettClasses", con) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                  
                    if (Dt != null)
                    {
                        ClassList.Items.Clear();
                        ClassList.DataSource = Dt;
                        ClassList.DataValueField = "ClassId";
                        ClassList.DataTextField = "class";
                        ClassList.DataBind();
                    }
                    else if (Dt == null)
                    {
                        string message = "Please go to settings and input classes if you are a nusery/primary school.";
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
            else if (ClassCheck.Checked == false)
            {
                ClassList.Items.Clear();
                BindControl.BindFeesClassDropDown(ClassList);
            }
        }
    }
}