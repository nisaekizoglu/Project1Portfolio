using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class WorkController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult WorkList()
        {
            var values = context.Work.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateWork()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateWork(Work work)
        {
            context.Work.Add(work);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        public ActionResult DeleteWork(int id)
        {
            var value = context.Work.Find(id);
            context.Work.Remove(value);
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }

        [HttpGet]

        public ActionResult UpdateWork(int id)
        {
            var value = context.Work.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateWork(Work work)
        {
            var value = context.Work.Find(work.WorkId);
            value.Title = work.Title;
            value.Description = work.Description;
            context.SaveChanges();
            return RedirectToAction("WorkList");
        }
    }
}