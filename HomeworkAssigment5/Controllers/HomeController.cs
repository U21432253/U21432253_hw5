using HomeworkAssigment5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkAssigment5.Controllers
{
    public class HomeController : Controller
    {
        private LibraryService dataService = LibraryService.getInstance();
        public ActionResult Index()
        {
            return View(dataService.Books());
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
    }
}