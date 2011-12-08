using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;

namespace DemoFacebook.BL
{
    public class AuthFacebook
    {
        public enum Method { GET, POST };
        public const string Authorize = "https://graph.facebook.com/oauth/authorize";
        public const string Access_Token = "https://graph.facebook.com/oauth/access_token";
        public string CallBack_Url = "";

        private string _aplicationKey="";
        private string _aplicationSecret = "";
        private string _token = "";

        public string AplicationKey{ get; set; }

        public string AplicationSecret { get; set; }

        public string Token{ get; set; }

        public string GetAuthorizationLink()
        {
            return "";
        }

        public string GetAuthorizationLinkPopup()
        {
            return "";
        }

        public void GetAccessToken(string authToken)
        {

        }

        public string Request(Method method, string url, string postData)
        {
            return "";
        }

        public  string GetWebResponse(HttpWebRequest webRequest)
        {
            return "";
        }
    }
}
