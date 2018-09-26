using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebSchoolPortal.App_Resources.FileHandlers
{
    /// <summary>
    /// Summary description for PicturePreview
    /// </summary>
    public class PicturePreview : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            //Checking whether the imagebytes session variable have anything else not doing anything
            if ((context.Session["ProfilePictureImageBytes"]) != null)
            {
                byte[] image = (byte[])(context.Session["ProfilePictureImageBytes"]);
                context.Response.ContentType = "image/JPEG";
                context.Response.BinaryWrite(image);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}