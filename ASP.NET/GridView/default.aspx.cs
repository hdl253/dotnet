using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridView
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<object> objs = new List<object>();
                for (int i = 0; i < 10; i++)
                {
                    objs.Add(new { a = "a", b = "b", c = "c", d = "d" });
                }
                gvTemp.DataSource = objs;
                gvTemp.DataBind();
                gvTemp.EditIndex = 2;
            }
        }

        protected void gvTemp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTemp.EditIndex = e.NewEditIndex;
        }
    }
}