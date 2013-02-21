using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace MultiLanguage
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.Equals(new System.Globalization.CultureInfo("zh-CN")))
                lnkbtnLang.Text = "English";
            else
                lnkbtnLang.Text = "中文";

        }

        protected void lnkbtnLang_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/lang.ashx?lang=" + (lnkbtnLang.Text == "English" ? "en-US" : "zh-CN") + "&url=" + Server.UrlEncode(Request.Url.PathAndQuery), true);
        }
        
    }
}
