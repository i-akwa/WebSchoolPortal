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

namespace WebSchoolPortal.App_Resources.Pages.General
{
    public partial class ResultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HeaderLabel = "View Result";
            if (!IsPostBack)
            {
                BindControl.BindDefaultClassDropDown(ddlClass);
                if (Roles.IsUserInRole("SchoolAdmin"))
                {
                    SchoolId.Text = Request.Cookies["SchoolId"].Value.ToString();
                    using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                    {
                        try
                        {
                            SqlCommand SelectArms = new SqlCommand("select Arm, ArmsId from armsTable where SchoolId=@SchoolId", connection);
                            SelectArms.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString();
                            connection.Open();
                            SqlDataReader re = SelectArms.ExecuteReader();
                            Arms.DataSource = re;
                            Arms.DataTextField = "Arm";
                            Arms.DataValueField = "ArmsId";
                            Arms.DataBind();
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
                else if (Roles.IsUserInRole("Teacher"))
                {
                    SchoolId.Text = Session["TESchoolId"].ToString();
                    using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
                    {
                        try
                        {
                            SqlCommand SelectArms = new SqlCommand("select Arm, ArmsId from armsTable where SchoolId=@SchoolId", connection);
                            SelectArms.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Session["TESchoolId"].ToString();
                            connection.Open();
                            SqlDataReader re = SelectArms.ExecuteReader();
                            Arms.DataSource = re;
                            Arms.DataValueField = "ArmsId";
                            Arms.DataTextField = "Arm";
                            Arms.DataBind();
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
            }
        }

        protected void Viewresult_Click(object sender, EventArgs e)
        {
            TextBox To = ResultList.FindControl("Total") as TextBox;
            Student_studentControl.ViewResult(ResultList, SchoolId.Text, Year.Text, Term.Text, ddlClass.SelectedValue.ToString(), Convert.ToInt32(Arms.SelectedItem.Value));
        }

        protected void ResultList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                ResultList.PageIndex = e.NewPageIndex;
                ResultList.PageIndex = e.NewPageIndex;
                ResultList.DataBind();
            }
            catch (Exception exc)
            {
                string message = exc.Message.ToString();
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

        public List<IdScores> GetScores()
        {
            List<IdScores> getscores = new List<IdScores>();
            int numOfSub = 0;
            foreach (GridViewRow row in ResultList.Rows)
            {
                IdScores idscores = new IdScores();
                idscores.Id = row.Cells[0].Text;
                idscores.scores = Convert.ToDecimal(row.Cells[5].Text);
                numOfSub= Convert.ToInt32(row.Cells[7].Text);
                getscores.Add(idscores);
            }
            Session["ScoreList"]= getscores.OrderByDescending(x => x.scores).ToList();
            Session["numOfsub"] = numOfSub;
            return getscores.OrderByDescending(x=>x.scores).ToList();
        }
       
        protected void ResultList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    if (e.CommandName.Equals("view"))
                    {
                        Session["Id"] = e.CommandArgument;
                        Session["date"] = Year.Text;
                        Session["Term"] = Term.Text;
                        Session["armId"]= Arms.SelectedValue.ToString();
                        Session["cls"] = ddlClass.SelectedItem.Text;
                        Session["clsid"] = ddlClass.SelectedValue.ToString();
                        GetScores();
                        Response.Redirect("~/App_Resources/Pages/General/resultview.aspx");
                    }
                }
                catch (Exception ex)
                {
                    string message = "Please Note That Result Is Not Yet Available For This Student,";
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
                    cmd.Parameters.AddWithValue("@SchoolId", SqlDbType.NVarChar).Value = Request.Cookies["SchoolId"].Value.ToString(); ;
                    con.Open();
                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);

                    if (Dt != null)
                    {
                        ddlClass.Items.Clear();
                        ddlClass.DataSource = Dt;
                        ddlClass.DataValueField = "ClassId";
                        ddlClass.DataTextField = "class";
                        ddlClass.DataBind();
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
                ddlClass.Items.Clear();
                BindControl.BindFeesClassDropDown(ddlClass);
            }

        }
    }

    public class IdScores
    {
        public string  Id { get; set; }
        public decimal scores { get; set; }
    }
}