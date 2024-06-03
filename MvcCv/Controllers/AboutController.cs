using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(TblHakkimda p)
        {
            var t = repo.Find(x => x.ID == 1); ;
            t.Ad = p.Ad;
            t.Soyad = p.Soyad;
            t.Adres = p.Adres;  
            t.Mail= p.Mail;   
            t.Aciklama = p.Aciklama;    
            t.Telefon = p.Telefon;  
            t.Resim = p.Resim;  
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}