using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfoliosEntities context =new MyPortfoliosEntities();
        public ActionResult Index()
        {
            int MessageCount = context.Message.Count();
            int MessageCountIsReadByTrue = context.Message.Where(x => x.IsRead == true).Count();
            int MessageCountIsReadByFalse = context.Message.Where(x => x.IsRead == false).Count();
            int skillCount = context.Skills.Count();
            var totalSkillValue = context.Skills.Sum(x => x.Value);
            var AverageSkillValue = context.Skills.Average(x => x.Value);
            var getEmailFromProfile = context.Profile.Select(x => x.Email).FirstOrDefault();
            var getLastCategoryId = context.Category.Max(x => x.CategoryId);
            var getLastCategoryName = context.Category.Where(x => x.CategoryId==getLastCategoryId).Select(y=> y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = MessageCount;
            ViewBag.MessageCountIsReadByTrue = MessageCountIsReadByTrue;
            ViewBag.MessageCountIsReadByFalse = MessageCountIsReadByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.AverageSkillValue = AverageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName = getLastCategoryName;


            return View();
        }
    }
}