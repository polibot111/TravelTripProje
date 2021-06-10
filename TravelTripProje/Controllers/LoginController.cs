using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Project.DAL;
using TravelTripProje.Models.Project.Entities;
using TravelTripProje.Models.SingletonPattern;

namespace TravelTripProje.Controllers
{
    public class LoginController : Controller
    {
        MyContext _db;
        public LoginController()
        {
            _db = DBTool.DBInstance;

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Adminss ad)
        {
            Adminss bb = _db.Adminss.FirstOrDefault(x => x.UserName == ad.UserName && x.Password == ad.Password);
            if(bb != null)
            {
                FormsAuthentication.SetAuthCookie(bb.UserName, false);
                Session["Kullanici"] = bb.UserName.ToString();
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Yanlis = "Kullanıcı Adı ve Şifre Yanlış";
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Login");
        }
    }
}