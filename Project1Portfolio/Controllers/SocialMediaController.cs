using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            context.SocialMedia.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]

        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.SocialMediaId);
            value.Title = socialMedia.Title;
            value.Status = socialMedia.Status;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult SocialMediaStatusChangeToTrue(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }
        public ActionResult SocialMediaStatusChangeToFalse(int id)
        {
            var value = context.SocialMedia.Where(x => x.SocialMediaId == id).FirstOrDefault();
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");

        }
    }
}