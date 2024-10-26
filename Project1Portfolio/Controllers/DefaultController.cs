﻿using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    
    public class DefaultController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.CategoryName,
                                               Value=x.CategoryId.ToString()

                                           }).ToList();
            ViewBag.v=values;
            return View();
        }

        [HttpPost]
        public ActionResult Index (Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar() 
        {
            return PartialView();
        }
        public PartialViewResult PartialHeader()
        {
            ViewBag.title = context.About.Select(x => x.Title).FirstOrDefault();
            ViewBag.detail = context.About.Select(x => x.Detail).FirstOrDefault();
            ViewBag.imageUrl = context.About.Select(x => x.ImageUrl).FirstOrDefault();

            ViewBag.adress = context.Profile.Select(x => x.Adress).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github = context.Profile.Select(x => x.GithubLink).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Profile.Select(x =>x.Title).FirstOrDefault();
            ViewBag.description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.imageUrl = context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialSkill()
        {
            var values = context.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x=> x.Status==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialExperience()
        {
            var values = context.Experiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values=context.Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialWork()
        {
            var values=context.Work.ToList();
            return PartialView(values);
        }
    }
}