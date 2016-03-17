using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.UnitTesting.Models;
using DotNet.UnitTesting.DAL;
using DotNet.UnitTesting.Logic;

namespace DotNet.UnitTesting.Web.Controllers
{
    public class HomeController : Controller
    {
        Repository repo = null;

        public HomeController() {

        }

        public HomeController(Repository repo) {
            this.repo= repo;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Lazy title for Unit Testing presentation.";

            return View();
        }

        public ActionResult MakePayment()
        {
            PaymentModel pay = new PaymentModel();

            return View(pay);
        }

        [HttpPost]
        public ActionResult MakePayment(PaymentModel pay)
        {
            
            LoanLogic loanLogic = new LoanLogic(repo);

            ViewBag.PaymentResult = loanLogic.AttemptPayment(pay);

            return View(pay);
        }

        //Code adapted from Art of Unit Testing
        public ActionResult LogAnalyzer()
        {
            LoanLogic loanLogic = new LoanLogic(repo);

            string fileName = string.Format("{0}", "hmm.foo");

            //bool original = loanLogic.IsValidLogFileName(fileName);
            bool refactored = loanLogic.IsValidLogFileNameREFACTORED(fileName);


            return View();
        }
    }
}
