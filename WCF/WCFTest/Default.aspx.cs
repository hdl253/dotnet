using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFTest
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSVRef_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            Test.Service1Client sv = new WCFTest.Test.Service1Client();
            lblResult.Text = sv.GetData(1);
            
        }

        protected void btnWebRef_Click(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            localhost.Service1 sv = new WCFTest.localhost.Service1();
            lblResult.Text = sv.GetData(2,true);
            lblResult.Text += "||" + sv.GetData(2, false);

        }

        protected void btnASMXWebRef_Click(object sender, EventArgs e)
        {

            lblResult.Text = string.Empty;
            localhostASMX.WebService1 asmxSV = new WCFTest.localhostASMX.WebService1();

            lblResult.Text = asmxSV.HelloWorld();


        }

        protected void btnAsmxSVRef_Click(object sender, EventArgs e)
        {
            asmxSVRef.WebService1SoapClient sv = new WCFTest.asmxSVRef.WebService1SoapClient();
            lblResult.Text = sv.HelloWorld();
            
        }
    }
}
