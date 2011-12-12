using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoFacebook.BL;

namespace DemoFacebook.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthFacebook oAuth = new AuthFacebook();
            oAuth.CallBack_Url = "http://localhost:1789/CallbackFacebook.aspx";

            if (Session["token"] == null)
            {
                Response.Redirect(oAuth.GetAuthorizationLink());
            }
            else
            {
                oAuth.Token = Session["token"].ToString();

                var url = "https://graph.facebook.com/me?access_token=" + oAuth.Token;
                string json = oAuth.Request(AuthFacebook.Method.GET, url, String.Empty);
                ltrJson.Text = json;
            }
        }
    }
}
