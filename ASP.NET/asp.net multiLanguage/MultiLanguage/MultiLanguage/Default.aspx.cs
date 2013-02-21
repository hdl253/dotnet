using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;

namespace MultiLanguage
{
    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            foreach (string lan in Request.UserLanguages)
            {
                //Response.Write(lan+"<br/>");
                //Response.Write(System.Globalization.CultureInfo.CurrentCulture.DisplayName + "<br/>");
                //Response.Write(System.Globalization.CultureInfo.CurrentCulture.EnglishName + "<br/>");
                //Response.Write(System.Globalization.CultureInfo.CurrentCulture.CultureTypes.ToString() + "<br/>");
                //Response.Write(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.YearMonthPattern + "<br/>");
            }
            
        }
    }
}
