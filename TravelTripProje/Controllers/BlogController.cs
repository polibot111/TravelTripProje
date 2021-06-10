using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Project.DAL;
using TravelTripProje.Models.SingletonPattern;
using Bogus.DataSets;
using TravelTripProje.Models.Project.Entities;
using TravelTripProje.Models.Classes_DTO;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        MyContext _db;
        public BlogController()
        {
            _db = DBTool.DBInstance;
        }
        public ActionResult Index()
        {
            BlogsCommentDTO bc = new BlogsCommentDTO
            {
                Blogs = _db.Blogs.OrderByDescending(x=>x.ID).ToList(),
                LastBlogs = _db.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList(),
                Comments = _db.Comments.OrderByDescending(x=>x.ID).Take(5).ToList(),
            };
            return View(bc);
        }

        public ActionResult BlogDetail(int id)
        {
            Blogs bl = _db.Blogs.FirstOrDefault(x => x.ID == id);
            return View(bl);
        }
        [HttpGet]
        public PartialViewResult Review(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Review(Comments nc)
        {
            _db.Comments.Add(nc);
            _db.SaveChanges();
            return PartialView();
        }
    }
}