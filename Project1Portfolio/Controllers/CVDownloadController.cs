using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class CVDownloadController : Controller
    {
        // GET: CVDownload
        public ActionResult CvDownload()
        {
            string filePath = Server.MapPath("~/Content/NisaCV.pdf");

            byte[] fileBytes=System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/pdf");
        }
    }
}