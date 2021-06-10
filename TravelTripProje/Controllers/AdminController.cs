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
    //Todo: Veri tabanından aktif verileri çekmek için statik bir sınıf yaz. Onu kullan.
    [Authorize]
    public class AdminController : Controller
    {
        MyContext _db;
        public AdminController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Messate = TempData["Onay"];
            List<Blogs> bb = _db.Blogs.OrderByDescending(x=>x.ID).ToList();
            return View(bb);
            
        }

        public ActionResult AddNewBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blogs nb)
        {
            //Blogs addb = new Blogs();
            //addb.LayoutBlog = nb.LayoutBlog;
            //addb.BlogDescription = nb.BlogDescription;
            //addb.BlogImage = nb.BlogImage;
            //addb.BlogPuan = nb.BlogPuan;
            _db.Blogs.Add(nb);
            TempData["Onay"] = "Blog Başarılı Bir Şekilde Eklendi";
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blogs bb = _db.Blogs.Find(id);
            _db.Blogs.Remove(bb);
            _db.SaveChanges();
            TempData["Onay"] = "Silme İşlemi Başarılı Bir Şekilde Gerçekleşti";
            return RedirectToAction("Index");
        }
        public ActionResult UpdateBlog(int id)
        {
            Blogs bb = _db.Blogs.Find(id);
            return View("UpdateBlog", bb);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blogs z)
        {
            Blogs bb = _db.Blogs.Find(z.ID);
            bb.LayoutBlog = z.LayoutBlog;
            bb.VisitTime = z.VisitTime;
            bb.BlogDescription = z.BlogDescription;
            bb.BlogPuan = z.BlogPuan;
            bb.BlogImage = z.BlogImage;
            bb.Modification = DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogComment()
        {
            return View(_db.Comments.ToList());
        }
        public ActionResult DeleteComment(int id)
        {
            Comments bb = _db.Comments.Find(id);
            _db.Comments.Remove(bb);
            _db.SaveChanges();
            return RedirectToAction("BlogComment");
        }
        public ActionResult UpdateComment(int id)
        {
            Comments bb = _db.Comments.Find(id);
            return View("UpdateComment", bb);
        }
        [HttpPost]
        public ActionResult UpdateComment(Comments z)
        {
            Comments bb = _db.Comments.Find(z.ID);
            bb.Commentator = z.Commentator;
            bb.CommentTor = z.CommentTor;
            bb.Mail = z.Mail;
            bb.Modification = DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction("BlogComment");
        }
    }
}