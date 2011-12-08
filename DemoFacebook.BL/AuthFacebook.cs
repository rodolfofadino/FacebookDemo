using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DemoFacebook.BL
{
    public class AuthFacebook
    {
        public enum Method { GET, POST };
        public const string Authorize = "";
        public const string Access_Token = "";
        public string CallBack_Url = "";

        public string AplicationKey { get; set; }
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
