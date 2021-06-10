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
    public class AboutController : Controller
    {
        // GET: About
        MyContext _db;
        public AboutController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult About()
        {
            
            return View(_db.AboutUss.ToList());
        }
    }
}