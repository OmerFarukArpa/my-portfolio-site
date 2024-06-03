using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult AddEducation(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation"); 
            }
            repo.TAdd(p);
            return RedirectToAction("Index");  
        }
        public ActionResult RemoveEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
            repo.TDelete(education);
            return RedirectToAction("Index");  
        }
        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var education = repo.Find(x => x.ID == id);
           
            return View(education);
        }
        [HttpPost]
        public ActionResult EditEducation(TblEgitimlerim t)
        {
            if (!ModelState.IsValid)
            {
                return View("EditEducation");
            }
            var m=repo.Find(x => x.ID ==t.ID);
            m.Baslik=t.Baslik;
            m.AltBaslik1 = t.AltBaslik1;    
            m.AltBaslik2 = t.AltBaslik2;    
            m.Tarih=t.Tarih;    
            m.GNO=t.GNO;    
            repo.TUpdate(m);
            return RedirectToAction("Index");
        }
    }
}