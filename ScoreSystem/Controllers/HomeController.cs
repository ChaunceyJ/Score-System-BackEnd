using ScoreSystem.Services.AdminManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoreSystem.Controllers
{
    public class HomeController : Controller
    {
        [CustAuthorize("vip")]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
