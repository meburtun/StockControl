using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using System.Web.Security;
namespace MvcStok.Controllers
{
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        MvcDbDenemeEntities db = new MvcDbDenemeEntities();
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(TblKullanici p1)
        {
            var bilgi = db.TblKullanici.FirstOrDefault(x => x.Ad == p1.Ad && x.Sifre == p1.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Ad,false);
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                ViewBag.LoginError = "Hatalı kullanıcı adı veya şifre";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}