using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSchoolPortal.App_Resources.UserControl
{
    public partial class Calender1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            else
            {
                var al = new ArrayList();
                al.Add("*Year*");
                for (var i = 1900; i <= 2011; i++)
                {
                    al.Add(i);
                }
                Ddyear.DataSource = al;
                Ddyear.DataBind();
            }
        }

        protected void cal1_DayRender(object sender, DayRenderEventArgs e)
        {
            HyperLink hlnk = new HyperLink();
            hlnk.Text = ((LiteralControl)e.Cell.Controls[0]).Text;
            hlnk.Attributes.Add("href", "javascript:SetDate('" +
            e.Day.Date.ToString("dd/MM/yyyy") + "')");
            e.Cell.Controls.Clear();
            e.Cell.Controls.Add(hlnk);
        }

        protected void DdyearSelectedIndexChanged(object sender, EventArgs e)
        {
            var syear = DateTime.Now.Year;
            var smonth = DateTime.Now.Month;
            if (Ddmonth.SelectedValue != "00")
            {
                smonth = Convert.ToInt32(Ddmonth.SelectedValue);
            }
            if (Ddyear.SelectedValue != "*Year*")
            {
                syear = Convert.ToInt32(Ddyear.SelectedValue);
            }
            var date = smonth + "/" + DateTime.Now.Day + "/" + syear;
            var dateTime = Convert.ToDateTime(date);
            cal1.VisibleDate = dateTime;
        }

        protected void DdmonthSelectedIndexChanged(object sender, EventArgs e)
        {
            var smonth = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            if (Ddyear.SelectedValue != "*Year*")
            {
                year = Convert.ToInt32(Ddyear.SelectedValue);
            }
            if (Ddmonth.SelectedValue != "00")
            {
                smonth = Convert.ToInt32(Ddmonth.SelectedValue);
            }
            var sdate = smonth + "/" + DateTime.Now.Day + "/" + year;
            cal1.VisibleDate = Convert.ToDateTime(sdate);
        }



        #region Regular expressions
        private static Regex regPrevMonth = new Regex(
                @"(?<PrevMonth><a.*?><</a>)",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );

        private static Regex regNextMonth = new Regex(
                @"(?<NextMonth><a.*?>></a>)",
                RegexOptions.IgnoreCase
                | RegexOptions.Singleline
                | RegexOptions.CultureInvariant
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );
        #endregion

        protected override void Render(HtmlTextWriter writer)
        {
            // turn user control to html code
            string output = Calender1.RenderToString(cal1);

            MatchEvaluator mevm = new MatchEvaluator(AppendMonth);
            output = regPrevMonth.Replace(output, mevm);

            MatchEvaluator mevb = new MatchEvaluator(AppendYear);
            output = regNextMonth.Replace(output, mevb);
            // output the modified code
            writer.Write(output);
        }

        public static string RenderToString(Control c)
        {
            bool previousVisibility = c.Visible;
            c.Visible = true; // make visible if not

            // get html code for control
            System.IO.StringWriter sw = new System.IO.StringWriter();
            HtmlTextWriter localWriter = new HtmlTextWriter(sw);
            c.RenderControl(localWriter);
            string output = sw.ToString();

            // restore visibility
            c.Visible = previousVisibility;

            return output;
        }

        private string AppendMonth(Match m)
        {
            return Calender1.RenderToString(Ddmonth) + "&nbsp ";
        }

        private string AppendYear(Match m)
        {
            return "&nbsp " + Calender1.RenderToString(Ddyear);
        }

        public DateTime? SelectedDate
        {
            get
            {
                // null date stored or not set
                if (ViewState["SelectedDate"] == null)
                {
                    return null;
                }
                return (DateTime)ViewState["SelectedDate"];
            }
            set
            {
                ViewState["SelectedDate"] = value;
                if (value != null)
                {
                    cal1.SelectedDate = (DateTime)value;
                    cal1.VisibleDate = (DateTime)value;
                }
                else
                {
                    cal1.SelectedDate = new DateTime(0);
                    cal1.VisibleDate = DateTime.Now.Date;
                }
            }
        }


    }
}