using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MultiLanguage
{
    public class PageBase:System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            if (Request.Cookies["Sto.UserLocale"] != null && !string.IsNullOrEmpty(Request.Cookies["Sto.UserLocale"].Value))
            {
                setCulture(Request.Cookies["Sto.UserLocale"].Value);
            }
            base.InitializeCulture();
        }
        private void setCulture(string lang)
        {
            UICulture = lang;
            Culture = lang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lang);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
            

        }
    }
}