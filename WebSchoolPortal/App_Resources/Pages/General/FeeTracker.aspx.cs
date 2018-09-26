using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodePortal.Project.Students;
using System.Text;
using System.Data.SqlClient;
using CodePortal.Project.DbConnection;
using System.Data;
using System.Web.Security;
using CodePortal.Project.BindControls;

namespace WebSchoolPortal.App_Resources.Pages.School_Administrator
{
    public partial class FeeTracker : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Status.ReadOnly = true;
                balance.Enabled = false;
                ButtonUpdateFees.Visible = false;
                Master.HeaderLabel = "Track Fees";
                SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();
                BindControl.BindDefaultClassDropDown(ddlClass);

                if (Roles.IsUserInRole("Teacher"))
                {
                    ButtonUpdateFees.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int rows=Student_studentControl.PaymentGrid(SchoolId.Text, StudentId.Text, Year.Text, Term.Text, Tracker, ddlClass, Name, AmountPaied, ActualFees, Status);

            if (rows > 0)
            {
                string message = "Data Updated successfully";
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
                string message = "Try Again, Interoption in updating";
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

        protected void ButtonUpdateFees_Click(object sender, EventArgs e)
        {
            int rows= Student_studentControl.UpdateFees(Convert.ToDecimal(balance.Text), Status.Text, SchoolId.Text, Year.Text, StudentId.Text, Term.Text);
            balance.Text = "";
            AmountPaied.Text = "";
            ActualFees.Text = "";
            Status.Text = "";
            ButtonUpdateFees.Enabled = false;

            if (rows > 0)
            {
                string message = "Data Updated successfully";
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
                string message = "Try Again, Interoption in updating";
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", sb.ToString(), false);
            }
            Student_studentControl.PaymentGrid(SchoolId.Text, StudentId.Text, Year.Text, Term.Text, Tracker);
        }


        protected void ButtonClassSearch_Click(object sender, EventArgs e)
        {
            Student_studentControl.SelectPaymentByClass(SchoolId.Text, ddlClass.SelectedValue.ToString(), Year.Text, Term.Text, Tracker);
        }

        protected void Tracker_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (e.CommandName.Equals("edt"))
                    {
                        if (Roles.IsUserInRole("Teacher"))
                        {
                            ButtonUpdateFees.Visible = false;
                            string message = "Teachers can not update.";
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
                            balance.Enabled = true;
                            ButtonUpdateFees.Visible = true;
                            SqlCommand select = new SqlCommand("SelectPaymentDetails", connection) { CommandType = CommandType.StoredProcedure };
                            select.Parameters.AddWithValue("@StudentId", SqlDbType.NVarChar).Value = e.CommandArgument;
                            select.Parameters.AddWithValue("@Year", SqlDbType.NVarChar).Value = Year.Text;
                            select.Parameters.AddWithValue("@Term", SqlDbType.NVarChar).Value = Term.Text;
                            select.Parameters.AddWithValue("@schoolID", SqlDbType.NVarChar).Value = SchoolId.Text;

                            connection.Open();
                            SqlDataReader read = select.ExecuteReader();
                            if (read.Read())
                            {
                                StudentId.Text = read["studentRollnum"].ToString();
                                Name.Text = read["name"].ToString();
                                AmountPaied.Text = read["amountPaid"].ToString();
                                ActualFees.Text = read["Fees"].ToString();
                                Status.Text = read["Status"].ToString();
                            }
                            connection.Close();
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

        protected void balance_TextChanged(object sender, EventArgs e)
        {
            if ((Convert.ToDecimal(AmountPaied.Text) + Convert.ToDecimal(balance.Text))==Convert.ToDecimal(ActualFees.Text))
            {
                Status.Text = "Cleared";
            }
            else if ((Convert.ToDecimal(AmountPaied.Text) + Convert.ToDecimal(balance.Text)) > Convert.ToDecimal(ActualFees.Text))
            {
                Status.Text = "Credited";
            }
            else if ((Convert.ToDecimal(AmountPaied.Text) + Convert.ToDecimal(balance.Text)) < Convert.ToDecimal(ActualFees.Text))
            {
                Status.Text = "Not Cleared";
            }
        }

    }
}