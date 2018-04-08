using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabExamples.Models;

namespace LabExamples.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new TaskDbContext())
            {
                var tasks = db.Tasks.ToList();

                return View(tasks);
            }
        }

        public ActionResult Nums()
        {
            return View();
        }

        public ActionResult Numbers(int count = 5)
        {
            ViewBag.Count = count;
            return View();
        }

    }
}