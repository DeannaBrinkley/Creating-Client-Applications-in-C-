using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SendCard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendCard(Models.BirthdayCard birthdayCard)
        {
            if (ModelState.IsValid)
            {
                return View("CardSent", birthdayCard);
            }
            else
            {
                return View();
            }
        }
    }
}