using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Project.DAL;
using TravelTripProje.Models.Project.Entities;
using TravelTripProje.Models.SingletonPattern;

namespace TravelTripProje.Controllers
{
    public class HomeController : Controller
    {
        MyContext _db;
        public HomeController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult Index()
        {
            return View(_db.Blogs.OrderByDescending(x=>x.ID).Take(4).ToList());
        }

        public PartialViewResult Partial1()
        {
            List<Blogs> bb = _db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(bb);
        }
        public PartialViewResult Partial2()
        {
            List<Blogs> bb = _db.Blogs.OrderByDescending(x=>x.ID).Take(10).ToList();
            return PartialView(bb);
        }
        public PartialViewResult Partial3()
        {
            List<Blogs> bb = _db.Blogs.OrderByDescending(x => x.BlogPuan).Take(6).ToList();
            return PartialView(bb);
        }
    }
}