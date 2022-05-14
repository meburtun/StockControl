using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcDbDenemeEntities db = new MvcDbDenemeEntities();
        [Authorize]
        public ActionResult Index()
        {
            listegetir();

            return View("Index");
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {

            return View("Index");
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatislar p1)
        {
            listegetir();
            var urn = db.TblUrunler.Where(m => m.UrunId == p1.TblUrunler.UrunId).FirstOrDefault();
            p1.TblUrunler = urn;
            var mus = db.TblMusteri.Where(m => m.MusterıId == p1.TblMusteri.MusterıId).FirstOrDefault();
            p1.TblMusteri = mus;
            var stk = db.TblUrunler.FirstOrDefault(s => s.UrunId == p1.TblUrunler.UrunId);
            int quantity = (int)p1.Adet;
            int miktar = (int)stk.Stok;
            int sum=  miktar - quantity;
            if (sum < 0) { TempData["msg"] = "<script>alert('Yetersiz stok nedeniyle işlem yapılamıyor');</script>"; }
            else {
                stk.Stok = Convert.ToByte(sum);
                db.TblSatislar.Add(p1);
                db.SaveChanges();
            }
            return View("Index");
        }
        public void listegetir()
        {
            List<SelectListItem> deger1 = (from i in db.TblUrunler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.UrunAd,
                                               Value = i.UrunId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TblMusteri.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MusterıAd + " " + i.MusterıSoyad,
                                               Value = i.MusterıId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
           
            List<TblSatislar> tblsat = db.TblSatislar.ToList();
            ViewBag.data = tblsat;
        }
    }
}