using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Deneyim
        DeneyimRepository repo= new DeneyimRepository();    
        public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblDeneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveExperience(int id)
        {
            TblDeneyimlerim t = repo.Find(x =>x.ID==id);
            repo.TDelete(t);
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult BringExperience(int id)
        {
            TblDeneyimlerim t = repo.Find(x =>x.ID==id);
            
            return View(t);   
        }

        [HttpPost]
        public ActionResult BringExperience(TblDeneyimlerim p)
        {
            TblDeneyimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik=p.Baslik;
            t.AltBaslik=p.AltBaslik;
            t.Tarih=p.Tarih;
            t.Aciklama=p.Aciklama;  
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}