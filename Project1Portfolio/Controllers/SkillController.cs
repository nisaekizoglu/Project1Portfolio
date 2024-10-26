using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    
    public class SkillController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();

        public ActionResult SkillList()
        {
            var values = context.Skills.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSkill() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skills skills) 
        {
            context.Skills.Add(skills);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value=context.Skills.Find(id);
            context.Skills.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]

        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skills.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateSkill(Skills skills)
        {
            var value = context.Skills.Find(skills.SkillId);
            value.Title = skills.Title;
            value.Value = skills.Value;
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}