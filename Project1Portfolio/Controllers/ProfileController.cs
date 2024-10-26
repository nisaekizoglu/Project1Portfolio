using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();

        public ActionResult ProfileList()
        {
            var values = context.Profile.ToList();
            return View(values);
        }
        [HttpGet]

        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateProfile(Profile profile)
        {
            context.Profile.Add(profile);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        public ActionResult DeleteProfile(int id)
        {
            var value = context.Profile.Find(id);
            context.Profile.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        [HttpGet]

        public ActionResult UpdateProfile(int id)
        {
            var value = context.Profile.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateProfile(Profile profile)
        {
            var value = context.Profile.Find(profile.ProfileId);
            value.Title = profile.Title;
            value.Description = profile.Description;
            value.Adress = profile.Adress;
            value.Email = profile.Email;
            value.PhoneNumber = profile.PhoneNumber;
            value.GithubLink = profile.GithubLink;
            context.SaveChanges();
            return RedirectToAction("ProfileList");
        }
    }
}