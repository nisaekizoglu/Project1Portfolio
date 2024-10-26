using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project1Portfolio.Controllers
{
    public class GraficController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult Index()
        {
            var skills = context.Skills.ToList();

            return View(skills);
        }
    }
}