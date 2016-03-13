using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNet.UnitTesting.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Lazy title for Unit Testing presentation.";

            return View();
        }

        public ActionResult MakePayment()
        {
           
            return View();
        }

        
    }
}
