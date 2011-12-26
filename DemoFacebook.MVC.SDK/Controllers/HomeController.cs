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
            return View();
        }

    }
}
