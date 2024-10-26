using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project1Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfoliosEntities context = new MyPortfoliosEntities();
        public PartialViewResult PartialContactSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialContactAddress()
        {
            ViewBag.description = context.Profile.Select(a =>a.Description).FirstOrDefault();
            ViewBag.address = context.Profile.Select(a => a.Adress).FirstOrDefault();
            ViewBag.email = context.Profile.Select(a => a.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(a => a.PhoneNumber).FirstOrDefault();

            return PartialView();
        }
        public PartialViewResult PartialContactLocation() 
        {
            ViewBag.mapLocation = context.Profile.Select(x => x.MapLocation).FirstOrDefault();
            return PartialView();
        }
    }
}