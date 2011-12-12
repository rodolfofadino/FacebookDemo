using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoFacebook.BL;

namespace DemoFacebook.Web
{
    public partial class CallbackFacebook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
            AuthFacebook oAuth = new AuthFacebook();


            if (Request["code"] == null)
            {
                Response.Redirect(oAuth.GetAuthorizationLink());
            }
            else
            {
                oAuth.GetAccessToken(Request["code"]);

                if (oAuth.Token.Length > 0)
                {
                    Session["token"] = oAuth.Token;
                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}