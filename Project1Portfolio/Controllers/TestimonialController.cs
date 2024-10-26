using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]

        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]

        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.TestimonialId);
            value.Name = testimonial.Name;
            value.Title = testimonial.Title;
            value.Comment = testimonial.Comment;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}