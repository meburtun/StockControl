using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbDenemeEntities db = new MvcDbDenemeEntities();

        [Authorize]
        public ActionResult Index(/*string p,int sayfa=1*/)
        {
            var degerler = db.TblMusteri.ToList();
            //var degerler = db.TblMusteri.ToList().ToPagedList(sayfa,4);

            //var degerler = from d in db.TblMusteri select d;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    degerler = degerler.Where(m => m.MusterıAd.Contains(p));
            //}
            //return View(degerler.ToList().ToPagedList(sayfa, 4));
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TblMusteri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var mus = db.TblMusteri.Find(id);
            db.TblMusteri.Remove(mus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TblMusteri.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(TblMusteri p1)
        {
            var mus = db.TblMusteri.Find(p1.MusterıId);
            mus.MusterıAd = p1.MusterıAd;
            mus.MusterıSoyad = p1.MusterıSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}