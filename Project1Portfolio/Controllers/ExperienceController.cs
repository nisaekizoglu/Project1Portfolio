using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult ExperienceList()
        {
            var values = context.Experiences.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateExperience() 
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateExperience(Experiences experiences) 
        {
            context.Experiences.Add(experiences);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public ActionResult DeleteExperience(int id) 
        { 
            var value = context.Experiences.Find(id);
            context.Experiences.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]

        public ActionResult UpdateExperience(int id) 
        {
            var value =context.Experiences.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateExperience(Experiences experiences)
        {
            var value = context.Experiences.Find(experiences.ExperienceId);
            value.Title = experiences.Title;
            value.Description = experiences.Description;
            value.WorkDate = experiences.WorkDate;
            value.CompanyName = experiences.CompanyName;
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

    }
}