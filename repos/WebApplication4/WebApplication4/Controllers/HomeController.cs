using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        
        MusteriServis _musteriServis;
        SiparisServis _siparisServis;

        public HomeController()
        {
            _musteriServis = new MusteriServis();
            _siparisServis = new SiparisServis();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            Musteri musteri = new Musteri();
            return View(musteri);
        }

        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            _musteriServis.MusterEkle(musteri);
            return RedirectToAction("Create");
        }

        public JsonResult Ara(string musteriAd)
        {
            try
            {
                var sonuc = _musteriServis.MusteriAra(musteriAd);
                return Json(sonuc);
            }
            catch (Exception ex)
            {
                return Json("");
            }
           
        }

        public JsonResult Rapor(string musteriAd)
        {
            var sonuc = string.IsNullOrEmpty(musteriAd) ? _siparisServis.SiparisOzet() : _siparisServis.SiparisOzet(musteriAd);
            return Json(sonuc);

        }
    }
}