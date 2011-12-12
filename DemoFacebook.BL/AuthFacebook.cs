using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;

namespace DemoFacebook.BL
{
    public class AuthFacebook
    {
        public enum Method { GET, POST };
        public const string Authorize = "https://graph.facebook.com/oauth/authorize";
        public const string Access_Token = "https://graph.facebook.com/oauth/access_token";
        public string CallBack_Url = ConfigurationManager.AppSettings["Facebook_CallbackUrl"];

        private string _aplicationKey = "";
        private string _aplicationSecret = "";
        private string _token = "";

        public string AplicationKey
        {
            get
            {
                if (_aplicationKey.Length == 0)
                {
                    _aplicationKey = ConfigurationManager.AppSettings["Facebook_aplicationKey"];
                }
                return _aplicationKey;
            }
            set { _aplicationKey = value; }
        }

        public string AplicationSecret
        {
            get
            {
                if (_aplicationSecret.Length == 0)
                {
                    _aplicationSecret = ConfigurationManager.AppSettings["Facebook_aplicationSecret"];
                }
                return _aplicationSecret;
            }
            set { _aplicationSecret = value; }
        }

        public string Token { get; set; }

        public string GetAuthorizationLink()
        {
            return string.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}",
                Authorize, AplicationKey, CallBack_Url, "publish_stream");
        }

        public string GetAuthorizationLinkPopup()
        {
            return string.Format("{0}?client_id={1}&display=popup&redirect_uri={2}&scope={3}",
                Authorize, AplicationKey, CallBack_Url, "publish_stream");
        }

        public void GetAccessToken(string authToken)
        {
            this.Token = authToken;
            string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
            Access_Token, this.AplicationKey, CallBack_Url, this.AplicationSecret, authToken);

            string response = Request(Method.GET, accessTokenUrl, String.Empty);

            if (response.Length > 0)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(response);

                if (qs["access_token"] != null)
                {
                    this.Token = qs["access_token"];
                }
            }
        }

        public string Request(Method method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "[Seu user agent]";
            webRequest.Timeout = 20000;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());

                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = GetWebResponse(webRequest);
            webRequest = null;
            return responseData;
        }

        public string GetWebResponse(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }
    }
}
