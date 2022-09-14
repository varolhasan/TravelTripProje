using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProjee.Models.Siniflar;

namespace TravelTripProjee.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.AdresBlogs.ToList();
            return View(deger);
        }
        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult MesajGonder(Iletisim i)
        {
            var deger = c.Iletisims.Add(i);
            c.SaveChanges();
            return PartialView();
        }
    }
}