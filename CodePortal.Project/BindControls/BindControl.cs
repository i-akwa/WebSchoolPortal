using CodePortal.Project.DbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CodePortal.Project.BindControls
{
    public class BindControl
    {
        public static void BindDefaultClassDropDown(System.Web.UI.WebControls.DropDownList ddl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("Select ClassId, class FROM ClassesTable where SchoolId='A488-28-PRV' and class !='OLD_STUD' and class !='New-St' and class !='S-New-St' and class !='Bor-St'", connection);
                    connection.Open();
                    SqlDataAdapter adt = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    adt.Fill(Dt);
                    ddl.DataSource = Dt;
                    ddl.DataTextField = "class";
                    ddl.DataValueField = "ClassId";
                    ddl.DataBind();
                    connection.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void BindFeesClassDropDown(System.Web.UI.WebControls.DropDownList ddl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("Select ClassId, class FROM ClassesTable where SchoolId='A488-28-PRV' and class !='OLD_STUD'", connection);
                    connection.Open();
                    SqlDataAdapter adt = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    adt.Fill(Dt);
                    ddl.DataSource = Dt;
                    ddl.DataTextField = "class";
                    ddl.DataValueField = "ClassId";
                    ddl.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void BindTableNames(System.Web.UI.WebControls.DropDownList ddl)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'SchoolPortal'", connection);
                    connection.Open();
                    SqlDataAdapter adt = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    adt.Fill(Dt);
                    ddl.DataSource = Dt;
                    ddl.DataTextField = "TABLE_NAME";
                    
                    ddl.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static void BindTableColumns(System.Web.UI.WebControls.DropDownList ddl, System.Web.UI.WebControls.DropDownList ddl2)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionClass.getConnection))
            {
                try
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM SchoolPortal.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME =@tabName", connection);
                    com.Parameters.AddWithValue("@tabName", SqlDbType.NVarChar).Value = ddl2.SelectedItem.Text;
                    connection.Open();
                    SqlDataAdapter adt = new SqlDataAdapter(com);
                    DataTable Dt = new DataTable();
                    adt.Fill(Dt);
                    ddl.DataSource = Dt;
                    ddl.DataTextField = "COLUMN_NAME";

                    ddl.DataBind();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
