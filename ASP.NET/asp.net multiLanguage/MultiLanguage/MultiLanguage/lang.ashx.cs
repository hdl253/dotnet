using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiLanguage
{
    /// <summary>
    /// lang 的摘要说明
    /// </summary>
    public class lang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Cookies["Sto.UserLocale"].Value = context.Request["lang"];
            context.Response.Cookies["Sto.UserLocale"].Expires = DateTime.Now.AddDays(1000);
            context.Response.Redirect(context.Request["url"]);
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