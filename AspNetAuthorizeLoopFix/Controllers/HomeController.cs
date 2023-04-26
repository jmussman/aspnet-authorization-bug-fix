using IdentityModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace OktaAspNetExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = "NobodyHasThisRole")]
        public ActionResult Secured() {

            string name = "";

            if (HttpContext.User.Identity.IsAuthenticated) {

                name = HttpContext.User.Identity.Name;
            }

            ViewBag.Message = $"User Name: {name}";

            return View();
        }
    }
}