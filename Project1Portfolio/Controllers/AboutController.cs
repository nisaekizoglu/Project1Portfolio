using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult AboutList()
        {
            var values = context.About.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateAbout(About about)
        {
            context.About.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = context.About.Find(id);
            context.About.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]

        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutId);
            value.Title = about.Title;
            value.Detail = about.Detail;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}