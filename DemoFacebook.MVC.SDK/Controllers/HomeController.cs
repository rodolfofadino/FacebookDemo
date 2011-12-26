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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
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
