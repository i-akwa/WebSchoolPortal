using System;
using System.Configuration;

namespace CodePortal.Project.DbConnection
{
    public class ConnectionClass
    { 
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public static string getConnection
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to establish Database Connection. Contact the site Administrator " + ex);
                }
            }
        }
    }

    public class ID
    {
        public string SchoolId { get; set; }
    }
}
