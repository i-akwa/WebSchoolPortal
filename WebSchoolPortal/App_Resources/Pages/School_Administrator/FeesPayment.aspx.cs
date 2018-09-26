using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CodePortal.Project.Students;
using CodePortal.Project.School_Admin;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class FeesPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.HeaderLabel = "Fees Payment";
                SchoolId.Text = Request.Cookies["SchoolId"].Value;
                DateTime a = System.DateTime.Now;
                date.Text = a.ToString();
            }
        }

        protected void StudentRollNum_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand select = new SqlCommand("GetName", connection) { CommandType = CommandType.StoredProcedure };
                select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                select.Parameters.AddWithValue("@StudentId", SqlDbType.NVarChar).Value = StudentRollNum.Text;
                connection.Open();
                SqlDataReader read = select.ExecuteReader();
                if (read.Read())
                {
                    StudentName.Text = read["Names"].ToString();
                    clas.Text = read["PresentClass"].ToString();
                }
                AmountPaied.ReadOnly = false;
            }
        }

        protected void AmountPaied_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (lblFees.Text=="")
                    {
                        SqlCommand select = new SqlCommand("GetFees", connection) { CommandType = CommandType.StoredProcedure };
                        select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                        select.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = clas.Text;
                        connection.Open();
                        SqlDataReader read = select.ExecuteReader();
                        if (read.Read())
                        {
                            if (FullFees.Text == "")
                            {
                                FullFees.Text = Convert.ToString(0);
                            }

                            lblFees.Text = read["actualfees"].ToString();
                            decimal a = Convert.ToDecimal(FullFees.Text) + Convert.ToDecimal(lblFees.Text);
                            FullFees.Text = a.ToString();
                        }
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

        protected void chkIsBorder_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand select = new SqlCommand("Select Amount as BordersFees  from feesTable where Class='Bor-St' and SchoolId=@SchoolId;", connection);
                select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                select.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = "Bor-St";
                if (FullFees.Text == "")
                {
                    FullFees.Text = Convert.ToString(0);
                }
                
                decimal realfees = Convert.ToDecimal(FullFees.Text);
                
                connection.Open();
                SqlDataReader read = select.ExecuteReader();
                if(read.Read())
                {
                    decimal bordFees= Convert.ToDecimal(read["BordersFees"].ToString());
                    if (chkIsBorder.Checked)
                    {
                        FullFees.Text =Convert.ToString(bordFees+realfees);
                    }
                    decimal realfee = Convert.ToDecimal(FullFees.Text);

                    if (chkIsBorder.Checked == false)
                    {
                        FullFees.Text = Convert.ToString(realfee - bordFees);
                    }
                }
                connection.Close();
            }
        }

        protected void chkIsNewStudent_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand select = new SqlCommand("Select Amount as NewStudentFees  from feesTable where Class='New-St' and SchoolId=@SchoolId;", connection);
                select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                select.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = "New-St";
                if (FullFees.Text == "")
                {
                    FullFees.Text = Convert.ToString(0);
                }

                decimal realfees = Convert.ToDecimal(FullFees.Text);

                connection.Open();
                SqlDataReader read = select.ExecuteReader();
                if (read.Read())
                {
                    decimal newFees = Convert.ToDecimal(read["NewStudentFees"].ToString());
                    if (chkIsNewStudent.Checked)
                    {
                        FullFees.Text = Convert.ToString(newFees + realfees);
                    }
                    decimal realfee = Convert.ToDecimal(FullFees.Text);
                    if (chkIsNewStudent.Checked == false)
                    {
                        FullFees.Text = Convert.ToString(realfee - newFees);
                    }
                }
                connection.Close();
            }
        }

        protected void btnBalance_Click(object sender, EventArgs e)
        {
            try
            {
                if (FullFees.Text == "" || AmountPaied.Text == "")
                {
                    string message = "Make Sure You Insert The Amount paying";
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
                    decimal val1 = Convert.ToDecimal(FullFees.Text);
                    decimal val2 = Convert.ToDecimal(AmountPaied.Text);
                    decimal balance = val1 - val2;
                    Balance.Text = balance.ToString();
                }

            if(Convert.ToInt32(Balance.Text) == 0)
            {
                Status.Text = "Cleared";
            }
            else if (Convert.ToInt32(Balance.Text) > 0)
            {
                Status.Text = "Not Cleared";
            }
            else
            {
                Status.Text = "Credited";
            }
            }
            catch (Exception ex)
            {
                string message = ex.Message + " Please Make Sure You Insert The Amount Paying ";
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

        protected void Pay_Click(object sender, EventArgs e)
        {
           int row= Student_studentControl.PayFees(SchoolId.Text, StudentName.Text, StudentRollNum.Text, Convert.ToDateTime(date.Text), clas.Text, Convert.ToDecimal(FullFees.Text), Convert.ToDecimal(AmountPaied.Text), Term.Text, Status.Text);

           if (row != 0)
           {
               string message = "Fee Have been Paied Successfuly";
               StringBuilder sb = new StringBuilder();
               sb.Append("<script type = 'text/javascript'>");
               sb.Append("window.onload=function(){");
               sb.Append("alert('");
               sb.Append(message);
               sb.Append("')};");
               sb.Append("</script>");
               ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
               Session["PayDate"] = Convert.ToDateTime(date.Text);
               Session["Rol"] = StudentRollNum.Text;

               Response.Redirect("~/App_Resources/Pages/School_Administrator/ReciptPage.aspx");
           }
           else
           {
               string message = "Contact Application Admin if this problem persist";
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



        protected void ChkNewSenior_CheckedChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                SqlCommand select = new SqlCommand("Select Amount as NewSeniorStudentFees  from feesTable where Class='S-New-St' and SchoolId=@SchoolId;", connection);
                select.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = SchoolId.Text;
                select.Parameters.AddWithValue("@class", SqlDbType.NVarChar).Value = "New-St";
                if (FullFees.Text == "")
                {
                    FullFees.Text = Convert.ToString(0);
                }

                decimal realfees = Convert.ToDecimal(FullFees.Text);

                connection.Open();
                SqlDataReader read = select.ExecuteReader();
                if (read.Read())
                {
                    decimal newFees = Convert.ToDecimal(read["NewSeniorStudentFees"].ToString());
                    if (ChkNewSenior.Checked)
                    {
                        FullFees.Text = Convert.ToString(newFees + realfees);
                    }
                    decimal realfee = Convert.ToDecimal(FullFees.Text);
                    if (ChkNewSenior.Checked == false)
                    {
                        FullFees.Text = Convert.ToString(realfee - newFees);
                    }
                }
                connection.Close();
            }
        }


    }
}