using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook.Web.Mvc;
using Facebook.Web;
using Facebook;
using System.Dynamic;

namespace DemoFacebook.MVC.SDK.Controllers
{
    public class HomeController : Controller
    {
        private const string ExtendedPermissions = "user_about_me,publish_stream";
        
        [FacebookAuthorize(Permissions = ExtendedPermissions, LoginUrl = "/Home/LogOn?ReturnUrl=~/Home")]
        public ActionResult Index()
        {
            var fb = new FacebookWebClient();
            dynamic me = fb.Get("me");

            ViewBag.ProfilePictureUrl = string.Format("http://graph.facebok.com/{0}/picture", me.id);
            ViewBag.Name = me.name;
            ViewBag.FirstName = me.first_name;
            ViewBag.LastName = me.last_name;

            ViewBag.MessagePostSuccess = Request.QueryString.AllKeys.Contains("success") &&
                                         Request.QueryString["success"] == "True";

            return View();
        }

        [HttpPost]
        [FacebookAuthorize(Permissions = ExtendedPermissions, LoginUrl = "/Home/LogOn?ReturnUrl=~/Home")]
        public ActionResult MensagemPost(string message)
        {
            return RedirectToAction("Index", new { success = true });
        }

        public ActionResult LogOn(string returnUrl)
        {
            var fbWebContext = new FacebookWebContext(FacebookApplication.Current, ControllerContext.HttpContext);

            if (fbWebContext.IsAuthorized(ExtendedPermissions.Split(',')))
            {
                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return new RedirectResult(returnUrl);
                    }
                }
                
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.ExtendedPermissions = ExtendedPermissions;
            return View();
        }

    }
}
